using UnityEngine;

public class NullInteract : Interactable
{
    public override void Interact()
    {
        base.Interact();
        base.PostInteract();
    }
}