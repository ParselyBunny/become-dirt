using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour
{
    private static bool _isInitialized = false;

    private UnityEngine.Events.UnityEvent _OnDestroy = new UnityEngine.Events.UnityEvent();

    private void Awake()
    {
        if (_isInitialized)
        {
            Debug.LogWarning("UIUtility already initialized, destroying self.");
            Destroy(this.gameObject);
            return;
        }

        _isInitialized = true;
        _OnDestroy.AddListener(() => { _isInitialized = false; });
    }

    private void OnDestroy()
    {
        _OnDestroy.Invoke();
    }

    public void ReloadCurrentScene()
    {
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
}