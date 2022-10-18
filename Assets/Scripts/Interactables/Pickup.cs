using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to an object to allow player
/// to pick it up.
/// </summary>
public class Pickup : Interactable
{
    protected override void Interact()
    {
        base.Interact();
              
        Destroy(this.gameObject);
    }
}
