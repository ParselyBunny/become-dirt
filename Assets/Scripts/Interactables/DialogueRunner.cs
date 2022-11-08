using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DialogueRunner : Interactable
{
    [SerializeField, Tooltip("If Ink flag is true, then objects in the lists are enabled/disabled. Leave empty if you don't want this choreography to be conditional on an Ink flag.")] private string _inkBoolName;
    [SerializeField, Tooltip("The Ink dialogue to play upon hitting this trigger. Leave empty if you don't want to trigger dialogue.")] private string _inkKnotName;

    public string InkBoolName { get => _inkBoolName; }
    public string InkKnotName { get => _inkKnotName; }

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

        InkManager.PlayNext(_inkKnotName);
    }
}
