using UnityEngine;
using UnityEngine.UI;

public class LoadGameUtility : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Button>().interactable = SaveStateManager.TryLoadSaveFile();
    }
}