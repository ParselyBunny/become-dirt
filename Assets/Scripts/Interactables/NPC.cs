using UnityEngine;

/// <summary>
/// Attach this to an object with an animator
/// that has a trigger to allow player
/// to toggle it. Intended for openable
/// objects like doors and drawers.
/// </summary>
public class NPC : Interactable
{
    [Tooltip("Name of the NPC to be displayed on the screen.")] public string Name = "Unknown";
    [Tooltip("The knot to jump to in the Ink Story.")] public string InkKnot = "Intro";
    private Animator _animator;

    void Start()
    {
        _animator = (GetComponent<Animator>() != null) ? GetComponent<Animator>() : new Animator();
    }

    public override void Interact()
    {
        base.Interact();
        base.SetAllowInteractSound(false);

        InkManager.PlayNext(InkKnot, this);
    }
}
