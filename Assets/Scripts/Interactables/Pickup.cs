using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JTools;

/// <summary>
/// Attach this to an object to allow player
/// to pick it up.
/// </summary>
public class Pickup : Interactable
{
    protected override void Interact()
    {
        base.Interact();

        ImpactController.current.soundComponent.PlayOneShot(interactSound, soundVolume);        
        Destroy(this.gameObject);
    }
}
