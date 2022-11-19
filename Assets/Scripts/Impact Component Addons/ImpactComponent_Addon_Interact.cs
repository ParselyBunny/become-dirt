using UnityEngine;

[DisallowMultipleComponent]
public class ImpactComponent_Addon_Interact : JTools.ImpactComponent_Addon
{
    [Tooltip("Whether or not interactions are enabled.")] public bool enableInteractions = true;
    [Tooltip("Range that the player can interact with things.")] public float distance = 3f;
    [Tooltip("The layers used for raycast physics.")] public LayerMask hitMask;
    [Tooltip("The player can only interact with objects on this layer.")] public LayerMask targetMask;

    private Reticle reticle;

    public override void ComponentInitialize(JTools.ImpactController player)
    {
        base.ComponentInitialize(player);

        reticle = UIMenus.GetMenuGameObject("Reticle").GetComponent<Reticle>();
        UIMenus.SetActiveMenu("Reticle");
    }

    private Interactable interactRef;
    public override void ComponentUpdate(JTools.ImpactController player)
    {
        base.ComponentUpdate(player);

        // Create a ray at the center of the camera going forward
        Ray ray = new Ray(owner.playerCamera.transform.position, owner.playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        // Store collision info
        RaycastHit hitInfo;

        // Check for collision with an object that has an Interactable component
        if (Physics.Raycast(ray, out hitInfo, distance, hitMask))
        {
            // Debug.LogFormat("{0} {1} {2} {3}",
            //     hitInfo.collider.gameObject.layer,
            //     (1 << hitInfo.collider.gameObject.layer),
            //     targetMask.value,
            //     ((1 << hitInfo.collider.gameObject.layer) & targetMask.value));
            if (((1 << hitInfo.collider.gameObject.layer) & targetMask.value) == targetMask.value)
            {
                interactRef = hitInfo.collider.GetComponent<Interactable>();
                if (interactRef == null)
                {
                    interactRef = hitInfo.collider.GetComponentInParent<Interactable>();
                }

                if (interactRef != null)
                {
                    // Change reticle state to show player is aiming at something interactable
                    reticle.SetFocus(true);

                    if (owner.inputComponent.inputData.pressedInteract)
                    {
                        Debug.Log("Input Locked? " + owner.inputComponent.lockInput);
                        Debug.Log(interactRef.PromptMessage, interactRef.gameObject);
                        interactRef.Interact();
                    }
                }
            }
            else
            {
                reticle.SetFocus(false);
            }
        }
        else
        {
            reticle.SetFocus(false);
        }
    }
}
