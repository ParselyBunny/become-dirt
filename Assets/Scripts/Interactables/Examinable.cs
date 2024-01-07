using UnityEngine;

public class Examinable : Interactable
{
    [SerializeField]
    private ExaminableData _data;
    private int _index = 0;

    public override void Interact()
    {
        base.Interact();

        if (_data.InkKnots != null && _data.InkKnots.Length > 0)
        {
            if (!InkManager.IsPlaying)
            {
                SetAllowInteractSound(true);
                InkManager.ToggleReticle(false);
                InkManager.OnDialogueEnd += () => InkManager.ToggleReticle(true);
                JTools.ImpactController.current.inputComponent.ChangeLockState(true);
            }

            InkManager.DisplayObjectText(_data.InkKnots[_index]);

            _index++;

            if (_index > (_data.InkKnots.Length - 1))
                _index = 0;
        }
    }
}
