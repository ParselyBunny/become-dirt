using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JTools;

public abstract class Examinable : Interactable
{
    [SerializeField, Tooltip("Message to display when examined.")]
    private string[] _examineMessage = "Object Examined.";

    public override void Interact()
    {
        base.Interact();
    }

    public virtual void Examine()
    {
        Debug.Log("You just examined me, my name is: " + this.name);

        InkManager.ShowExamineText(_examineMessage);
    }
}
