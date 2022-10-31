using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    private AudioMixer _mixer;

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
    }

    public static void SetVolume(MixerLabel mixerLabel, float value)
    {
        instance._mixer?.SetFloat(mixerLabel.ToString(), Mathf.Log10(value) * 20);
    }

    public static float GetVolume(MixerLabel mixerLabel)
    {
        float val = 0;
        instance?._mixer?.GetFloat(mixerLabel.ToString(), out val);
        return val;
    }

    public static float GetVolumeNormalized(MixerLabel mixerLabel)
    {
        float val = 0;
        instance?._mixer?.GetFloat(mixerLabel.ToString(), out val);
        // This math is wrong lol
        return (val / 20f) + 1;
    }
}