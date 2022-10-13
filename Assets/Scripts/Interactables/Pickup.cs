using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    protected override void Interact()
    {
        base.Interact();

        Debug.Log("I, " + this.name + ", am being picked up!");
        Destroy(this);
    }
}
