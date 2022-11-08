using UnityEngine;

// Code sourced from this Raycast Interactions vid: https://www.youtube.com/watch?app=desktop&v=gPPGnpV1Y1c

/// <summary>
/// Interactable scripts should inherit from this class.
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    [Tooltip("Message to display when interacted with.")] public string PromptMessage = "Default message.";
    [Tooltip("Sound that plays when the object is interacted with.")] public AudioClip InteractSound;
    [Tooltip("If true, play interact sound.")] public bool AllowInteractSound = true;

    /// <summary>
    /// Perform some interaction.
    /// </summary>
    public virtual void Interact()
    {
        Debug.Log("You just interacted with me, my name is: " + this.name);

        if (AllowInteractSound)
        {
            if (InteractSound == null)
            {
                Debug.LogWarning("Trying to play Interact sound without clip.", this);
            }
            else
            {
                AudioManager.PlayOneShot(InteractSound);
            }
        }
    }

    /// <summary>
    /// Set whether interact sounds should be played or not.
    /// Use this in your specific interactable implementations
    /// to control when interact sounds are allowed to be played.
    /// </summary>
    public void SetAllowInteractSound(bool isAllowed)
    {
        AllowInteractSound = isAllowed;
    }
}
