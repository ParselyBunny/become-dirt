using UnityEngine;

[CreateAssetMenu]
public class InteractableData : ScriptableObject
{
    public AudioClip InteractSound { get => _interactSound; }

    [SerializeField, Tooltip("Sound that plays when the object is interacted with.")]
    private AudioClip _interactSound;
}