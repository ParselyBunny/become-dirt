using UnityEngine;

/// <summary>
/// Attach this to an object with an animator
/// that has a trigger to allow player
/// to toggle it. Intended for openable
/// objects like doors and drawers.
/// </summary>
public class NPC : Interactable
{
    public string Name { get { return _data.Name; } }

    [SerializeField]
    private NPCData _data;

    public override void Interact()
    {
        base.Interact();

        if (_data.InkKnot == "")
        {
            Debug.LogError("Interacting with NPC without InkKnot set.", this);
            return;
        }

        PlayInteractSound(_data.InteractSound);
        SetAllowInteractSound(false);
        InkManager.OnDialogueEnd += () => base.SetAllowInteractSound(true);
        InkManager.PlayNext(_data.InkKnot, this);
    }
}
