using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JTools;

/// <summary>
/// Attach this to an object to allow player
/// to toggle it open and closed.
/// </summary>
public class Openable : Interactable
{
    public bool isOpen = false;
    public Animator animator;

    void Start() {
        // if ? then : else
        animator = (GetComponent<Animator>() != null) ? GetComponent<Animator>() : new Animator();
    }

    protected override void Interact()
    {
        base.Interact();
        // TODO: trigger obj animation
        ImpactController.current.soundComponent.PlayOneShot(interactSound, soundVolume);   
    }
}
