using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour
{
    private static UIUtility instance;

    private UnityEngine.Events.UnityEvent _OnDestroy = new UnityEngine.Events.UnityEvent();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("UIUtility initialized.");
        }
        else
        {
            Debug.LogWarning("UIUtility already instanced, destroying self.", this.gameObject);
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        _OnDestroy.Invoke();
    }

    public void ReloadCurrentScene()
    {
        SaveStateManager.ResetCache();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif
    }

    public void ApplyFileToScene()
    {
        SaveStateManager.ApplyFileToScene();
    }

    public static void SaveGame()
    {
        instance.StartCoroutine(instance.SaveGameAfterFrame());
    }

    public IEnumerator SaveGameAfterFrame()
    {
        yield return null; // Wait a frame before saving
        SaveStateManager.SaveGame();
    }
}