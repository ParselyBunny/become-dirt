using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    private static ZoneManager Instance;

    public Dictionary<Zone, Transform> zones = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("ZoneManager: Disabled self.");
            gameObject.SetActive(false);
        }
    }

    public static Transform GetTeleportPoint(Zone targetZone)
    {
        foreach (var zone in Instance.zones)
        {
            if (zone.Key.RoomType == targetZone.RoomType && zone.Key.FloorType == targetZone.FloorType)
            {
                return zone.Value;
            }
        }
        return null;
    }
}