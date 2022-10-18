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
    [Tooltip("Name of a trigger to activate on this object's animator component.")] public string TriggerName = "openClose";
    private Animator _Animator;

    void Start() {
        _Animator = (GetComponent<Animator>() != null) ? GetComponent<Animator>() : new Animator();
    }

    protected override void Interact()
    {
        base.Interact();

        _Animator.SetTrigger(TriggerName);
    }
}
