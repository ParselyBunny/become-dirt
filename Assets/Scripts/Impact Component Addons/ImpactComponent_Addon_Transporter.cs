using System.Collections;
using JTools;
using UnityEngine;

public class ImpactComponent_Addon_Transporter : ImpactComponent_Addon
{
    public static void TeleportPlayer(Zone targetLocation)
    {
        if (ImpactController.current == null)
        {
            Debug.LogError("No player controller defined, nothing to teleport.");
            return;
        }

        var transporter = ImpactController.current.GetComponent<ImpactComponent_Addon_Transporter>();
        if (transporter == null)
        {
            Debug.LogError("Transporter addon not found on player, cannot teleport");
            return;
        }

        transporter.StartCoroutine(transporter.Teleport(targetLocation));
    }

    public IEnumerator Teleport(Zone targetLocation)
    {
        var current = Zone.GetCurrent(transform.position);
        ImpactController.current.inputComponent.ChangeLockState(true);
        // TODO: await screen transition UI part 1
        var tp = ZoneManager.GetTeleportPoint(targetLocation);
        transform.SetPositionAndRotation(tp.position, tp.rotation);
        // TODO: await screen transition UI loop
        // TODO: await screen transition UI part 2
        ImpactController.current.inputComponent.ChangeLockState(false);
        yield return null;
    }
}