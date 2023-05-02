using UnityEngine;

/// <summary>
/// Attach this to an object with an animator
/// that has a trigger to allow player
/// to toggle it. Intended for openable
/// objects like doors and drawers.
/// </summary>
public class NPC : Interactable
{
    [Tooltip("Name of the NPC to be displayed on the screen.")]
    public string Name = "Unknown";

    [Tooltip("The knot to jump to in the Ink Story.")]
    public string InkKnot = "";

    public override void Interact()
    {
        base.Interact();

        if (InkKnot == "")
        {
            Debug.LogError("Interacting with NPC without InkKnot set.", this);
            return;
        }

        base.SetAllowInteractSound(false);
        InkManager.PlayNext(InkKnot, this);
    }
}
