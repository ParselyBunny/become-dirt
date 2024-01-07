using UnityEngine;

public static class EnumExtensions
{
    public static bool IsCurrent(this Zone.Room roomType, in Vector3 origin)
    {
        Physics.Raycast(origin, Vector3.down, out var hitInfo, Mathf.Infinity, ~LayerMask.NameToLayer(Zone.LAYER));
        if (hitInfo.collider.TryGetComponent<Zone>(out var zone))
        {
            return zone.RoomType == roomType;
        }
        Debug.LogWarning("Less efficient `IsCurrent()` hit object with no Zone component. Something may be wrong.");
        return false;
    }

    public static bool IsCurrent(this Zone.Room roomType, in Ray ray, out RaycastHit hitInfo)
    {
        Physics.Raycast(ray, out hitInfo, 3, ~LayerMask.NameToLayer(Zone.LAYER));
        if (hitInfo.collider.TryGetComponent<Zone>(out var zone))
        {
            return zone.RoomType == roomType;
        }
        return false;
    }
}