using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DialogueRunner : Interactable
{
    public string InkBoolName { get => _data.InkBoolName; }
    public string InkKnotName { get => _data.InkKnotName; }

    [SerializeField]
    private DialogueData _data;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }

    public void EnableInteraction()
    {
        _collider.enabled = true;
    }

    public override void Interact()
    {
        base.Interact();

        if (!InkManager.IsPlaying)
        {
            InkManager.OnDialogueEnd += () => InkManager.ToggleReticle(true);
            JTools.ImpactController.current.inputComponent.ChangeLockState(true);
            InkManager.ToggleReticle(false);
        }

        InkManager.PlayNext(_data.InkKnotName);
    }
}
