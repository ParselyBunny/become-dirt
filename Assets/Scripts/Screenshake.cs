using System;
using UnityEngine;
using JTools;

/// <summary>
/// Shake shake the screen!!!
/// </summary>
public class Screenshake : MonoBehaviour {
    [HideInInspector]
    public static bool StartShake = false;
    [HideInInspector]
    public Action<string> ShakeScreen;
    public float Strength = 0.2f;

    void Start()
    {
        ShakeScreen = _shakeScreen;
        InkManager.AddTagChecker("shake", _shakeScreen);
    }

    void Update()
    {
        if (StartShake)
        {
            StartShake = false;
            ImpactController.current.cameraComponent.screenshake = Strength;
        }
    }

    static void _shakeScreen(string tag)
    {
        StartShake = true;
    }
}