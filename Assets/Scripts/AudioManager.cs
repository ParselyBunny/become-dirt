using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public enum MixerLabel
    {
        Master,
        Music,
        SFX
    }

    private static AudioManager instance;

    [SerializeField]
    private AudioMixerGroup _masterMixer;
    [SerializeField]
    private AudioMixerGroup _musicMixer;
    [SerializeField]
    private AudioMixerGroup _sfxMixer;

    private int startingPoolSize = 16;
    private AudioSource _musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            Debug.Log("Audio Manager initialized.");
        }
        else
        {
            Debug.LogWarning("AudioManager already instanced, destroying self.", this.gameObject);
            Destroy(this);
        }

        _musicSource = GetComponent<AudioSource>();

        GameObject go;
        AudioSource source;
        ReturnToPool rtp;
        for (int i = 0; i < startingPoolSize; i++)
        {
            go = new GameObject("Pooled AudioSource");
            go.transform.SetParent(instance.transform);

            source = go.AddComponent<AudioSource>();

            rtp = go.AddComponent<ReturnToPool>();
            rtp.Source = source;
            rtp.AwaitRelease();

            StaticObjectPool.Push<AudioSource>(source);
        }
    }

    private void Start()
    {
        // TODO: Just loop over the enum keys
        AudioManager.SetVolume(MixerLabel.Master, AudioManager.GetVolumeNormalized(MixerLabel.Master));
        AudioManager.SetVolume(MixerLabel.Music, AudioManager.GetVolumeNormalized(MixerLabel.Music));
        AudioManager.SetVolume(MixerLabel.SFX, AudioManager.GetVolumeNormalized(MixerLabel.SFX));
    }

    public static void PlayOneShot(AudioClip clip)
    {
        instance.PlayPooledOneShot(clip);
    }

    public static void PlayOneShot(AudioClip clip, float delaySeconds)
    {
        instance.StartCoroutine(instance.PlayPooledOneShotWithDelay(clip, delaySeconds));
    }

    public static void PlayMusic(AudioClip clip)
    {
        instance._musicSource.Stop();
        instance._musicSource.clip = clip;
        instance._musicSource.Play();
    }

    private AudioSource tempSourceRef;
    private void PlayPooledOneShot(AudioClip clip)
    {
        var ok = StaticObjectPool.TryPop<AudioSource>(out tempSourceRef);
        if (!ok)
        {
            Debug.LogWarningFormat("Trying to play clip when pool is empty! {0}", clip.name);
            tempSourceRef = null;
            return;
        }

        Debug.Log("Using AudioSource from pool", tempSourceRef.gameObject);
        tempSourceRef.GetComponent<ReturnToPool>().AwaitRelease();
        tempSourceRef.clip = clip;
        tempSourceRef.Play();
    }

    private System.Collections.IEnumerator PlayPooledOneShotWithDelay(AudioClip clip, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        PlayPooledOneShot(clip);
    }

    public static void SetVolume(MixerLabel mixerLabel, float val)
    {
        switch (mixerLabel)
        {
            case MixerLabel.Master:
                instance._masterMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);
                break;
            case MixerLabel.Music:
                instance._musicMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);
                break;
            case MixerLabel.SFX:
                instance._sfxMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);

                break;
            default:
                Debug.LogErrorFormat("Call to SetVolume was made with invalid label - {0}", mixerLabel.ToString());
                return;
        }

        PlayerPrefs.SetFloat(mixerLabel.ToString(), val);
    }

    public static void SetVolumeWithoutSaving(MixerLabel mixerLabel, float val)
    {
        switch (mixerLabel)
        {
            case MixerLabel.Master:
                instance._masterMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);
                break;
            case MixerLabel.Music:
                instance._musicMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);
                break;
            case MixerLabel.SFX:
                instance._sfxMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);

                break;
            default:
                Debug.LogErrorFormat("Call to SetVolume was made with invalid label - {0}", mixerLabel.ToString());
                return;
        }
    }

    public static float GetVolumeNormalized(MixerLabel mixerLabel)
    {
        return PlayerPrefs.GetFloat(mixerLabel.ToString(), 1);
    }
}

// This component returns the AudioSource to the pool when the clip ends.
[RequireComponent(typeof(AudioSource))]
public class ReturnToPool : MonoBehaviour
{
    public AudioSource Source;

    public void AwaitRelease()
    {
        StartCoroutine(WaitForClipEnd());
    }

    private void OnDestroy()
    {
        StopCoroutine(WaitForClipEnd());
    }

    private System.Collections.IEnumerator WaitForClipEnd()
    {
        yield return new WaitUntil(() => Source.isPlaying);
        yield return new WaitUntil(() => !Source.isPlaying && Source.time == 0.0f);
        ReleaseSelf();
    }

    private void ReleaseSelf()
    {
        // Return to the pool
        Source.Stop();
        Source.clip = null;
        StaticObjectPool.Push<AudioSource>(Source);
    }
}