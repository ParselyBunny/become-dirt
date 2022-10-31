using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioManager.MixerLabel _mixerLabel;
    [SerializeField, Tooltip("OPTIONAL: Text field for displaying value of slider.")]
    private Text _sliderValueDisplay;

    private Slider _slider;

    private void Awake()
    {
        this._slider = this.GetComponent<Slider>();
    }

    private void OnEnable()
    {
        this._slider.value = AudioManager.GetVolumeNormalized(this._mixerLabel);
        this._slider.onValueChanged.AddListener(UpdateMixerVolume);
        if (this._sliderValueDisplay != null)
        {
            this._slider.onValueChanged.AddListener(UpdateSliderText);
        }
    }

    private void OnDisable()
    {
        this._slider.onValueChanged.RemoveAllListeners();
    }

    private void UpdateMixerVolume(float val)
    {
        AudioManager.SetVolume(_mixerLabel, val);
    }

    // TODO: Add proper formatting for 0-1 values
    private void UpdateSliderText(float val)
    {
        this._sliderValueDisplay.text = val.ToString();
    }
}