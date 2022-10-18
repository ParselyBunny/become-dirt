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
        }
        else
        {
            Debug.LogWarning("Audio Manager already has instance assigned.", instance);
            Destroy(this.gameObject);
        }
    }

    public static void SetVolume(MixerLabel mixerLabel, float value)
    {
        instance._mixer.SetFloat(mixerLabel.ToString(), Mathf.Log10(value) * 20);
    }

    public static float GetVolume(MixerLabel mixerLabel)
    {
        instance._mixer.GetFloat(mixerLabel.ToString(), out float val);
        return val;
    }

    public static float GetVolumeNormalized(MixerLabel mixerLabel)
    {
        instance._mixer.GetFloat(mixerLabel.ToString(), out float val);
        return (val / 20f) + 1;
    }
}