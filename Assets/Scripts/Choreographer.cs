using System.Collections.Generic;
using UnityEngine;
using JTools;

/// <summary>
/// Activate and deactivate NPCs
/// and other key story objects.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Choreographer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ObjectsToDisable;
    [SerializeField]
    private List<GameObject> ObjectsToEnable;
    [SerializeField]
    private Transform LookTarget;
    [SerializeField]
    private float LookSpeed = 1.0f; // TODO: UNUSED

    [SerializeField, Tooltip("Create a child object with a DialogueRunner")] private DialogueRunner dialogueRunner;
    [SerializeField, Tooltip("If true, this component always triggers even if the Ink flag is false.")] private bool AlwaysTrigger;
    [SerializeField, Tooltip("If true, destroy this component so it only does its arrangement once.")] private bool DestroyOnTrigger;

    private bool _canTrigger = false;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player hit a choreo trigger.");

            if (dialogueRunner == null)
            {
                Debug.LogWarning("Running choreo with no DialogueRunner.", this);
            }

            if (AlwaysTrigger)
            {
                _canTrigger = AlwaysTrigger;
            }
            else if (dialogueRunner?.InkBoolName != "")
            {
                _canTrigger = InkManager.CheckVariable(dialogueRunner.InkBoolName);
            }

            if (!_canTrigger)
            {
                return;
            }

            Debug.Log(name + " Choreographer was triggered. Rearranging scene.");

            foreach (GameObject obj in ObjectsToDisable)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }

            foreach (GameObject obj in ObjectsToEnable)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }

            if (dialogueRunner?.InkKnotName != "")
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
                dialogueRunner?.EnableInteraction();

                if (DestroyOnTrigger)
                {
                    InkManager.OnDialogueEnd += DestroySelf;
                }
                else
                {
                    InkManager.OnDialogueEnd += EnableSelf;
                }

                InkManager.PlayNext(dialogueRunner?.InkKnotName);
            }
            else if (DestroyOnTrigger)
            {
                Destroy(this.gameObject);
            }

            _canTrigger = false;
        }
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
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
