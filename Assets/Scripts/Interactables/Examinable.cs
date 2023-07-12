using UnityEngine;

public class Examinable : Interactable
{
    [SerializeField]
    private ExaminableData _data;

    public override void Interact()
    {
        base.Interact();

        Debug.Log("You just examined me, my name is: " + this.name);

        if (_data.ExamineMessage != null && _data.ExamineMessage.Length > 0)
        {
            if (!InkManager.IsPlaying)
            {
                base.SetAllowInteractSound(false);
                InkManager.OnDialogueEnd += () => base.SetAllowInteractSound(true);
                InkManager.OnDialogueEnd += () => InkManager.ToggleReticle(true);

                JTools.ImpactController.current.inputComponent.ChangeLockState(true);
                InkManager.ToggleReticle(false);
            }

            InkManager.DisplayObjectText(_data.Name, _data.ExamineMessage);
        }
    }
}
