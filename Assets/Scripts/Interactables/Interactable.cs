using System;
using UnityEngine;

/// <summary>
/// Perform some interaction.
/// Code sourced from this Raycast Interactions vid: https://www.youtube.com/watch?app=desktop&v=gPPGnpV1Y1c
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    public Action OnInteract = () => { };
    public Action OnPostInteract = () => { };

    private bool AllowInteractSound = true;

    public virtual void Interact()
    {
        Debug.Log("Interact target: " + name);
        OnInteract.Invoke();
    }

    public virtual void PostInteract()
    {
        Debug.Log("Post-interaction target: " + name);
        OnPostInteract.Invoke();
    }

    protected void PlayInteractSound(AudioClip audio)
    {
        if (AllowInteractSound)
        {
            if (audio == null)
            {
                Debug.LogWarning("failed to play interaction sound for object", this);
                return;
            }
            AudioManager.PlayOneShot(audio);
        }
    }

    /// <summary>
    /// Set whether interact sounds should be played or not.
    /// Use this in your specific interactable implementations
    /// to control when interact sounds are allowed to be played.
    /// </summary>
    protected void SetAllowInteractSound(bool isAllowed)
    {
        AllowInteractSound = isAllowed;
    }
}
