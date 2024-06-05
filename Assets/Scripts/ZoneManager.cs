using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class ZoneManager : MonoBehaviour
{
    private static ZoneManager Instance;

    [System.Serializable]
    public class ZoneEntry
    {
        public Zone zone;
        public Transform teleportPoint;
    }

    public List<ZoneEntry> zones = new();

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

    [ContextMenu("Reset Zone List")]
    private void ResetZones()
    {
        zones = new();

        var floors = EnumExtensions.GetNumbers<Zone.Floor>();
        var rooms = EnumExtensions.GetNumbers<Zone.Room>();

        for (int i = 0; i < floors.Count; i++)
        {
            for (int j = 0; j < rooms.Count; j++)
            {
                zones.Add(new ZoneEntry()
                {
                    zone = new Zone(rooms[j], floors[i])
                });
            }
        }
    }

    public static Transform GetTeleportPoint(Zone targetZone)
    {
        foreach (var entry in Instance.zones)
        {
            if (entry.zone.RoomType == targetZone.RoomType && entry.zone.FloorType == targetZone.FloorType)
            {
                return entry.teleportPoint;
            }
        }

        Debug.LogWarningFormat("Teleport Point not defined for {0} {1}", targetZone.FloorType, targetZone.RoomType);
        return null;
    }
}