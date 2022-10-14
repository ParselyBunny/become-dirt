using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code sourced from this Raycast Interactions vid: https://www.youtube.com/watch?app=desktop&v=gPPGnpV1Y1c

/// <summary>
/// Interactable scripts should inherit from this class.
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    [Tooltip("Message to display when interacted with.")] public string promptMessage = "Default message.";
    [Tooltip("How loud the interactable's sounds are.")] [Range(0f, 1f)] public float soundVolume = 1f;
    [Tooltip("Sound that plays when the object is interacted with.")] public AudioClip interactSound;

    /// <summary>
    /// Call from the player controller
    /// to trigger an interaction.
    /// </summary>
    public void BaseInteract() {
        Interact();
    }

    /// <summary>
    /// Perform some interaction.
    /// </summary>
    protected virtual void Interact() {
        Debug.Log("You just interacted with me, my name is:" + this.name);
    }
}