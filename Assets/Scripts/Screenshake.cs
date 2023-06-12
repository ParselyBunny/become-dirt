using System.Collections;
using UnityEngine;
using JTools;

/// <summary>
/// Shake shake the screen!!!
/// </summary>
public class Screenshake : MonoBehaviour {
    public bool Start = false;
    public float Strength = 0.2f;
    
    void Update() {
        if (Start) {
            Start = false;
            ImpactController.current.cameraComponent.screenshake = Strength;
        }
    }
}