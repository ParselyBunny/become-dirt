using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JTools;

// Code sourced from this Raycast Interactions vid: https://www.youtube.com/watch?app=desktop&v=gPPGnpV1Y1c

/// <summary>
/// Interactable scripts should inherit from this class.
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    [Tooltip("Message to display when interacted with.")] public string PromptMessage = "Default message.";
    [Tooltip("Sound that plays when the object is interacted with.")] public AudioClip InteractSound;

    /// <summary>
    /// Perform some interaction.
    /// </summary>
    public virtual void Interact()
    {
        Debug.Log("You just interacted with me, my name is: " + this.name);
        AudioManager.PlayOneShot(InteractSound);
    }
}
