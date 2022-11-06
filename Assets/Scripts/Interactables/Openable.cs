using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to an object with an animator
/// that has a trigger to allow player
/// to toggle it. Intended for openable
/// objects like doors and drawers.
/// </summary>
public class Openable : Interactable
{
    [Tooltip("Name of a trigger to activate on this object's animator component.")] public string BoolName = "isOpen";
    [Tooltip("If this is true, the door is locked when closed.")] public bool IsLocked = false;
    [Tooltip("Sound that plays when the object is opened.")] public AudioClip OpenSound;
    [Tooltip("Sound that plays when the object is closed.")] public AudioClip CloseSound;
    [Tooltip("Sound that plays when the object is locked.")] public AudioClip LockedSound;
    private Animator _Animator;

    void Start()
    {
        _Animator = (GetComponent<Animator>() != null) ? GetComponent<Animator>() : new Animator();
        base.SetAllowInteractSound(false);
    }

    public override void Interact()
    {
        base.Interact();

        if (IsLocked) {
            AudioManager.PlayOneShot(LockedSound);
        } else {
            bool isOpen = _Animator.GetBool(BoolName);
            _Animator.SetBool(BoolName, !isOpen);

            if (!isOpen)
            {
                AudioManager.PlayOneShot(OpenSound);
            } else {
                AudioManager.PlayOneShot(CloseSound);
            }
        }
    }
}
