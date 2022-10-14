using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JTools
{
    public class ImpactComponent_Addon_Interact : ImpactComponent_Addon
    {
        [Tooltip("Whether or not interactions are enabled.")] public bool enableInteractions = true;
        [Tooltip("Range that the player can interact with things.")] [SerializeField] public float distance = 3f;
        [Tooltip("The player can only interact with objects on this layer.")] [SerializeField] public LayerMask mask;
        private Reticle reticle;

        public override void ComponentInitialize(ImpactController player)
        {
            base.ComponentInitialize(player);

            reticle = FindObjectOfType<Reticle>();
        }

        public override void ComponentUpdate(ImpactController player)
        {
            base.ComponentUpdate(player);

            Debug.Log("Drawing Ray.");
            // Create a ray at the center of the camera going forward
            Ray ray = new Ray(owner.playerCamera.transform.position, owner.playerCamera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance);
            // Store collision info
            RaycastHit hitInfo;

            // Check for collision with an object that has an Interactable component
            if (Physics.Raycast(ray, out hitInfo, distance, mask)) {
                if (hitInfo.collider.GetComponent<Interactable>() != null) {
                    Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);

                    // Change reticle state to show player is aiming at something interactable
                    reticle.focus = true;

                    if (owner.inputComponent.inputData.pressedInteract) {
                        hitInfo.collider.GetComponent<Interactable>().BaseInteract();
                    }
                }
            } else {
                reticle.focus = false;
            }
        }
    }
}