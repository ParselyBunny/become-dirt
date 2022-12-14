using System.Collections;
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
        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
        yield return null; // AudioManager needs a frame to load cause we don't have dependency injection

        this._slider.onValueChanged.AddListener(UpdateMixerVolume);
        if (this._sliderValueDisplay != null)
        {
            this._slider.onValueChanged.AddListener(UpdateSliderText);
        }
        this._slider.value = AudioManager.GetVolumeNormalized(this._mixerLabel);
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