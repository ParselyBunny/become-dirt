using UnityEngine;

[CreateAssetMenu]
public class OpenableData : InteractableData
{
    public string BoolName { get => _boolName; }
    public AudioClip OpenSound { get => _openSound; }
    public AudioClip CloseSound { get => _closeSound; }
    public AudioClip LockedSound { get => _lockedSound; }

    [SerializeField, Tooltip("Name of a trigger to activate on this object's animator component.")]
    private string _boolName = "isOpen";

    [SerializeField, Tooltip("Sound that plays when the object is opened.")]
    private AudioClip _openSound;

    [SerializeField, Tooltip("Sound that plays when the object is closed.")]
    private AudioClip _closeSound;

    [SerializeField, Tooltip("Sound that plays when the object is locked.")]
    private AudioClip _lockedSound;
}