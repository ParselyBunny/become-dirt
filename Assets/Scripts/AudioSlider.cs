using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioManager.MixerLabel _mixerLabel;

    private Slider _slider;

    private void Awake()
    {
        this._slider = this.GetComponent<Slider>();
    }

    private void Start()
    {
        this._slider.value = AudioManager.GetVolumeNormalized(this._mixerLabel);
        this._slider.onValueChanged.AddListener(UpdateMixerVolume);
    }

    private void UpdateMixerVolume(float val)
    {
        AudioManager.SetVolume(_mixerLabel, val);
    }
}