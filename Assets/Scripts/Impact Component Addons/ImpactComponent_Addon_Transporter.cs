using System.Collections;
using JTools;

public class ImpactComponent_Addon_Transporter : ImpactComponent_Addon
{
    public IEnumerator Teleport(Zone targetLocation)
    {
        var current = Zone.GetCurrent(transform.position);
        ImpactController.current.inputComponent.ChangeLockState(true);
        // TODO: await screen transition UI part 1
        var tp = ZoneManager.GetTeleportPoint(targetLocation);
        transform.SetPositionAndRotation(tp.position, tp.rotation);
        // TODO: await screen transition UI loop
        // TODO: await screen transition UI part 2
        ImpactController.current.inputComponent.ChangeLockState(true);
        yield return null;
    }
}