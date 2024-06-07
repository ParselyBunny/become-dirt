using System.Collections;
using JTools;
using UnityEngine;

public class ImpactComponent_Addon_Transporter : ImpactComponent_Addon
{
    public static Zone.Floor CurrentFloor = Zone.Floor.Ground;

    public float TeleportDuration = 2.5f;

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
        // var current = Zone.GetCurrent(transform.position);
        ImpactController.current.inputComponent.ChangeLockState(true);

        CurrentFloor = targetLocation.FloorType;
        if (targetLocation.FloorType == Zone.Floor.Basement)
        {
            UIMenus.SetActiveMenu("TransDown");
        }
        else
        {
            UIMenus.SetActiveMenu("TransUp");
        }

        yield return null;
        var tp = ZoneManager.GetTeleportPoint(targetLocation);
        transform.SetPositionAndRotation(tp.position, tp.rotation);
        ZoneManager.OnTeleport?.Invoke(targetLocation);

        // TODO: screen transition UI part 1
        yield return new WaitForSecondsRealtime(TeleportDuration);

        // TODO: screen transition UI loop

        // TODO: screen transition UI part 2

        UIMenus.SetActiveMenu("Reticle");
        yield return new WaitForSecondsRealtime(0.5f);
        ImpactController.current.inputComponent.ChangeLockState(false);
        yield return null;
    }
}