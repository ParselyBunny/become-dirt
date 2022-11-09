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

        ImpactController.current.inputComponent.lockInput = true;
        _musicVolume = AudioManager.GetVolumeNormalized(AudioManager.MixerLabel.Music);
        AudioManager.SetVolume(AudioManager.MixerLabel.Music, -80.0f);
        UIMenus.SetActiveMenu("Black Screen");

        GetComponent<Collider>().enabled = false;
        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(3);

        AudioManager.PlayMusic(EndingMusic);
        AudioManager.SetVolume(AudioManager.MixerLabel.Music, _musicVolume);
        UIMenus.SetActiveMenu("Ending");

        StartCoroutine(Quit());
    }

    private IEnumerator Quit()
    {
        yield return new WaitForSecondsRealtime(13);

        UIUtils.QuitGame();
    }
}
