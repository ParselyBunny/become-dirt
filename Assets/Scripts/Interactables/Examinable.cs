using UnityEngine;

public class Examinable : Interactable
{
    [SerializeField, Tooltip("Message to display when examined.")]
    private string[] _examineMessage = new string[] { "Object Examined." };

    public override void Interact()
    {
        base.Interact();
    }

    public virtual void Examine()
    {
        Debug.Log("You just examined me, my name is: " + this.name);

        InkManager.DisplayObjectText(this.gameObject.name, _examineMessage);
    }
}
