using UnityEngine;

[CreateAssetMenu]
public class DialogueData : ScriptableObject
{
    public string InkKnotName { get => _inkKnotName; }
    public string InkBoolName { get => _inkBoolName; }

    [SerializeField, Tooltip("The Ink dialogue to play upon hitting this trigger. Leave empty if you don't want to trigger dialogue.")]
    private string _inkKnotName;
    [SerializeField, Tooltip("If Ink flag is true, then objects in the lists are enabled/disabled. Leave empty if you don't want this choreography to be conditional on an Ink flag.")]
    private string _inkBoolName;
}
