using UnityEngine;

[System.Serializable]
public class Zone
{
    public enum Room
    {
        FrontRoom,
        LivingRoom,
        Kitchen,
        DiningRoom,
        Hallway,
        Bathroom,
        GrandmaRoom,
        MotherRoom,
        SiblingRoom,
    }

    public enum Floor
    {
        Ground,
        Basement,
    }

    public const string LAYER = "Floor";

    public Room RoomType => _roomType;
    public Floor FloorType => _floorType;

    [SerializeField] private Room _roomType;
    [SerializeField] private Floor _floorType;

    public Zone() { }
    public Zone(Room roomType, Floor floorType)
    {
        _roomType = roomType;
        _floorType = floorType;
    }

    public static Zone GetCurrent(in Vector3 origin)
    {
        Physics.Raycast(origin, Vector3.down, out var hitInfo, Mathf.Infinity, ~LayerMask.NameToLayer(LAYER));
        if (hitInfo.collider.TryGetComponent<ZoneDesignator>(out var zd))
        {
            return zd.DesignatedZone;
        }
        Debug.LogWarning("Less efficient `GetCurrent` hit object with no Zone component. Something may be wrong.");
        return null;
    }

    public static Zone GetCurrent(in Ray ray, out RaycastHit hitInfo)
    {
        Physics.Raycast(ray, out hitInfo, 3, ~LayerMask.NameToLayer(LAYER));
        if (hitInfo.collider.TryGetComponent<ZoneDesignator>(out var zd))
        {
            return zd.DesignatedZone;
        }
        Debug.LogWarning("GetCurrent raycast failed to find a Room.");
        return null;
    }
}

public static class ZoneExtensions
{
    public static Zone GetZoneAbove(this Zone zone)
    {
        // TODO: Change to enum indexing to reduce coupling against enum definition
        switch (zone.FloorType)
        {
            case Zone.Floor.Basement:
                return new Zone(zone.RoomType, Zone.Floor.Ground);
            case Zone.Floor.Ground:
                goto default;
            default:
                return null;
        }
    }

    public static Zone GetZoneBelow(this Zone zone)
    {
        // TODO: Change to enum indexing to reduce coupling against enum definition
        switch (zone.FloorType)
        {
            case Zone.Floor.Basement:
                goto default;
            case Zone.Floor.Ground:
                return new Zone(zone.RoomType, Zone.Floor.Basement);
            default:
                return null;
        }
    }
}