using UnityEngine;
using System.Collections;
using JTools;

/// <summary>
/// Attach this to the object that
/// will end the game.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Ending : Interactable
{
    public AudioClip EndingMusic;
    private float _musicVolume;
    public override void Interact()
    {
        base.Interact();
        base.SetAllowInteractSound(false);

        ImpactController.current.inputComponent.ChangeLockState(false);
        Destroy(ImpactController.current.gameObject);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _musicVolume = AudioManager.GetVolumeNormalized(AudioManager.MixerLabel.Music);
        AudioManager.SetVolumeWithoutSaving(AudioManager.MixerLabel.Music, -80.0f);
        UIMenus.GetMenu("Black Screen").SetAlwaysEnabledOverride(true);
        UIMenus.SetActiveMenu("Black Screen");

        GetComponent<Collider>().enabled = false;

        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(3);

        AudioManager.PlayMusic(EndingMusic, true);
        AudioManager.SetVolumeWithoutSaving(AudioManager.MixerLabel.Music, _musicVolume);
        UIMenus.GetMenu("Black Screen").SetAlwaysEnabledOverride(false);
        UIMenus.GetMenu("Ending").SetAlwaysEnabledOverride(true);
        UIMenus.SetActiveMenu("Ending");

        yield return new WaitForSecondsRealtime(13);

        UIMenus.SetActiveMenu("Thanks");
    }
}
