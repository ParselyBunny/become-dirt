using UnityEngine;

public class Examinable : NPC
{
    [SerializeField, Tooltip("Message to display when examined.")]
    private string[] _examineMessage = new string[] { };

    public override void Interact()
    {
        base.Interact();

        Debug.Log("You just examined me, my name is: " + this.name);

        if (_examineMessage.Length > 0)
        {
            base.SetAllowInteractSound(false);
            InkManager.OnDialogueEnd += () => base.SetAllowInteractSound(true);
            InkManager.OnDialogueEnd += () => InkManager.ToggleReticle(true);

            JTools.ImpactController.current.inputComponent.ChangeLockState(true);
            InkManager.ToggleReticle(false);
            InkManager.DisplayObjectText(base.Name, _examineMessage);
        }
    }
}
