using UnityEngine;
using UnityEngine.UI;

public class LoadGameUtility : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<Button>().interactable = SaveStateManager.TryLoadSaveFile();
    }
}