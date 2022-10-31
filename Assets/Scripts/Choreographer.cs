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
    [Tooltip("If this is true, destroy this component so it only does its arrangement once.")] public bool DestroyOnChoreograph;
    [Tooltip("Name of a boolean variable defined in Ink story. If variable is true, then objects in the lists are enabled/disabled.")] public string InkBoolName;
    private bool _canRearrange = false;
    
    void Update()
    {
        // TODO: Add a check for direction facing using quaternions?
        if (_canRearrange) {
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

            _canRearrange = false;

            if (DestroyOnChoreograph) {
                Destroy(this);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            Debug.Log("Player hit a trigger.");
            _canRearrange = InkManager.CheckVariable(InkBoolName);
            
            if (_canRearrange) {
                Debug.Log(name + " Choreographer was triggered. Rearranging scene.");
            }
        }
    }
}
