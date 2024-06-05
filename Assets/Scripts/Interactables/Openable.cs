using UnityEngine;

/// <summary>
/// Attach this to an object with an animator
/// that has a trigger to allow player
/// to toggle it. Intended for openable
/// objects like doors and drawers.
/// </summary>
[RequireComponent(typeof(Animator))]
public class Openable : Interactable
{
    [SerializeField]
    private OpenableData _data;
    [SerializeField, Tooltip("If this is true, the door is locked when closed.")]
    private bool _isLocked = false;

    private Animator _Animator;

    void Awake()
    {
        _Animator = (GetComponent<Animator>() != null) ? GetComponent<Animator>() : new Animator();
        SetAllowInteractSound(false);
    }

    public override void Interact()
    {
        base.Interact();

        if (_isLocked)
        {
            AudioManager.PlayOneShot(_data.LockedSound);
        }
        else
        {
            bool isOpen = _Animator.GetBool(_data.BoolName);
            _Animator.SetBool(_data.BoolName, !isOpen);

            if (!isOpen)
            {
                AudioManager.PlayOneShot(_data.OpenSound);
            }
            else
            {
                AudioManager.PlayOneShot(_data.CloseSound);
            }
        }

        base.PostInteract();
    }
}
