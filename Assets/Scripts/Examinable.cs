using UnityEngine;

public abstract class Examinable : Interactable
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

        InkManager.ShowExamineText(this.gameObject.name, _examineMessage);
    }
}
