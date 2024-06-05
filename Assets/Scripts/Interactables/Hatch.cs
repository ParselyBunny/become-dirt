using UnityEngine;

public class Hatch : Interactable
{
    [SerializeField]
    private Zone targetZone;

    public override void Interact()
    {
        base.Interact();

        ImpactComponent_Addon_Transporter.TeleportPlayer(targetZone);

        base.PostInteract();
    }
}