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

    private const int STARTING_POOL_SIZE = 16;

    private static AudioManager STATIC;

    [SerializeField]
    private AudioMixerGroup _masterMixer;
    [SerializeField]
    private AudioMixerGroup _musicMixer;
    [SerializeField]
    private AudioMixerGroup _sfxMixer;

    private AudioSource _musicSource;

    private void Awake()
    {
        if (STATIC == null)
        {
            STATIC = this;
            Debug.Log("Audio Manager initialized.");
        }
        else
        {
            Debug.LogWarning("AudioManager already instanced, destroying self.", gameObject);
            Destroy(this);
        }

        _musicSource = GetComponent<AudioSource>();

        GameObject go;
        AudioSource source;
        ReturnToPool rtp;
        for (int i = 0; i < STARTING_POOL_SIZE; i++)
        {
            go = new GameObject("Pooled AudioSource");
            go.transform.SetParent(STATIC.transform);

            source = go.AddComponent<AudioSource>();

            rtp = go.AddComponent<ReturnToPool>();
            rtp.Source = source;
            rtp.AwaitRelease();

            StaticObjectPool.Push(source);
        }
    }

    private void Start()
    {
        // TODO: Just loop over the enum keys
        SetVolume(MixerLabel.Master, GetVolumeNormalized(MixerLabel.Master));
        SetVolume(MixerLabel.Music, GetVolumeNormalized(MixerLabel.Music));
        SetVolume(MixerLabel.SFX, GetVolumeNormalized(MixerLabel.SFX));
    }

    public static void PlayOneShot(AudioClip clip)
    {
        if (STATIC == null)
        {
            Debug.LogError("failed to PlayOneShot, AudioManager not initialized");
            return;
        }
        STATIC.PlayPooledOneShot(clip);
    }

    public static void PlayOneShot(AudioClip clip, float delaySeconds)
    {
        STATIC.StartCoroutine(STATIC.PlayPooledOneShotWithDelay(clip, delaySeconds));
    }

    // INSPECTOR METHOD
    public static void PlayMusic(AudioClip clip)
    {
        STATIC._musicSource.Stop();
        if (clip == null)
        {
            Debug.LogWarning("Trying to play music with null clip selected.");
            return;
        }
        STATIC._musicSource.clip = clip;
        STATIC._musicSource.Play();
    }

    public static void PlayMusic(AudioClip clip, bool shouldLoop)
    {
        STATIC._musicSource.Stop();
        if (clip == null)
        {
            Debug.LogWarning("Trying to play music with null clip selected.");
            return;
        }
        STATIC._musicSource.clip = clip;
        STATIC._musicSource.loop = shouldLoop;
        STATIC._musicSource.Play();
    }

    private AudioSource tempSourceRef;
    private void PlayPooledOneShot(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Failed to play requested audio clip, clip is null");
            return;
        }

        var ok = StaticObjectPool.TryPop(out tempSourceRef);
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
                STATIC._masterMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);
                break;
            case MixerLabel.Music:
                STATIC._musicMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);
                break;
            case MixerLabel.SFX:
                STATIC._sfxMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);

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
                STATIC._masterMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);
                break;
            case MixerLabel.Music:
                STATIC._musicMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);
                break;
            case MixerLabel.SFX:
                STATIC._sfxMixer.audioMixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(val) * 20);

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
        StaticObjectPool.Push(Source);
    }
}