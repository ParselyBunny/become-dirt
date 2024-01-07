using System.Collections.Generic;
using UnityEngine;
using JTools;

/// <summary>
/// Activate and deactivate NPCs
/// and other key story objects.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Choreographer : StateSerializer
{
    [SerializeField]
    private List<StateSerializer> ObjectsToDisable;
    [SerializeField]
    private List<StateSerializer> ObjectsToEnable;
    [SerializeField]
    private Transform LookTarget;
    [SerializeField]
    private float LookSpeed = 1.0f; // TODO: UNUSED

    [SerializeField, Tooltip("Create a child object with a DialogueRunner")] private DialogueRunner dialogueRunner;
    [SerializeField, Tooltip("If true, this component always triggers even if the Ink flag is false.")] private bool AlwaysTrigger;
    [SerializeField, Tooltip("If true, destroy this component so it only does its arrangement once.")] private bool DestroyPostTrigger;
    [SerializeField, Tooltip("If true, initiate auto-save after choreo execution.")] private bool SavePostTrigger;

    private bool _canTrigger = false;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();

        SaveStateManager.MarkObjectForSaving(this);
        for (int i = 0; i < ObjectsToDisable.Count; i++)
        {
            SaveStateManager.MarkObjectForSaving(ObjectsToDisable[i]);
        }
        for (int i = 0; i < ObjectsToEnable.Count; i++)
        {
            SaveStateManager.MarkObjectForSaving(ObjectsToEnable[i]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Player hit a choreo trigger.");

            if (dialogueRunner == null)
            {
                Debug.LogWarning("Running choreo with no DialogueRunner.", this);
            }

            if (AlwaysTrigger)
            {
                _canTrigger = AlwaysTrigger;
            }
            else if (dialogueRunner.InkBoolName != "")
            {
                _canTrigger = InkManager.CheckVariable(dialogueRunner.InkBoolName);
            }

            if (!_canTrigger)
            {
                return;
            }

            // Debug.Log(name + " Choreographer was triggered. Rearranging scene.");

            foreach (StateSerializer obj in ObjectsToDisable)
            {
                if (obj != null)
                {
                    obj.gameObject.SetActive(false);
                }
            }

            foreach (StateSerializer obj in ObjectsToEnable)
            {
                if (obj != null)
                {
                    obj.gameObject.SetActive(true);
                }
            }

            if (dialogueRunner.InkKnotName != "")
            {
                if (LookTarget != null)
                {
                    if (ImpactController.current != null && ImpactController.current.cameraComponent != null)
                    {
                        // TODO: Add a check for direction facing using quaternions?
                        ImpactController.current.cameraComponent.SetLookTarget(LookTarget);
                        InkManager.OnDialogueEnd += StopLookAt;
                    }
                    else
                    {
                        Debug.LogError("Trying to use LookTarget when ImpactController Camera is not set up!", this);
                    }
                }

                _collider.enabled = false;
                dialogueRunner.EnableInteraction();

                if (DestroyPostTrigger)
                {
                    InkManager.OnDialogueEnd += DestroySelf;
                }
                else
                {
                    InkManager.OnDialogueEnd += EnableSelf;
                }

                if (SavePostTrigger)
                {
                    InkManager.OnDialogueEnd += UIUtility.SaveGame;
                }

                InkManager.OnDialogueEnd += () => InkManager.ToggleReticle(true);

                ImpactController.current.inputComponent.ChangeLockState(true);
                InkManager.ToggleReticle(false);
                InkManager.PlayNext(dialogueRunner.InkKnotName);
            }
            else if (DestroyPostTrigger)
            {
                Destroy(gameObject);
            }

            _canTrigger = false;
        }
    }

    private void DestroySelf()
    {
        // Debug.LogFormat("Choreo destroying self {0}", this.gameObject.name);
        Destroy(gameObject);
    }

    private void EnableSelf()
    {
        _collider.enabled = true;
    }

    private void StopLookAt()
    {
        ImpactController.current.cameraComponent.SetLookTarget(null);
    }
}
