using UnityEngine;

public class ZoneDesignator : MonoBehaviour
{
    public Zone DesignatedZone => _zone;

    [SerializeField] private Zone _zone;
}