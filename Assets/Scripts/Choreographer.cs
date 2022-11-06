using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Activate and deactivate NPCs
/// and other key story objects.
/// </summary>
public class Choreographer : MonoBehaviour
{
    public List<GameObject> ObjectsToDisable;
    public List<GameObject> ObjectsToEnable;
    [Tooltip("If this is true, this component always triggers even if the Ink flag is false.")] public bool AlwaysTrigger = false;
    [Tooltip("If this is true, destroy this component so it only does its arrangement once.")] public bool DestroyOnTrigger;
    [Tooltip("If Ink flag is true, then objects in the lists are enabled/disabled. Leave empty if you don't want this choreography to be conditional on an Ink flag.")] public string InkBoolName = "";
    [Tooltip("The Ink dialogue to play upon hitting this trigger. Leave empty if you don't want to trigger dialogue.")] public string InkKnotName = "";
    private bool _canTrigger = false;
    
    void Update()
    {
        // TODO: Add a check for direction facing using quaternions?
        if (_canTrigger) {
            Debug.Log(name + " Choreographer was triggered. Rearranging scene.");

            foreach(GameObject obj in ObjectsToDisable){
                if (obj != null) {
                    obj.SetActive(false);
                }
            }

            foreach(GameObject obj in ObjectsToEnable){
                if (obj != null) {
                    obj.SetActive(true);
                }
            }

            _canTrigger = false;

            if (InkKnotName != "") {
                InkManager.PlayNext(InkKnotName);
            }

            if (DestroyOnTrigger) {
                Destroy(this);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            Debug.Log("Player hit a trigger.");
            
            if (AlwaysTrigger) {
                _canTrigger = AlwaysTrigger;
            } else if (InkBoolName != "") {
                _canTrigger = InkManager.CheckVariable(InkBoolName);
            }
        }
    }
}
