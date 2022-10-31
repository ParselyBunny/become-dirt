using UnityEngine;

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

        DontDestroyOnLoad(this.gameObject);
        _isInitialized = true;
        _OnDestroy.AddListener(() => { _isInitialized = false; });
    }

    private void OnDestroy()
    {
        _OnDestroy.Invoke();
    }

    public void LoadScene(int sceneIndex)
    {
        UIUtils.LoadScene(sceneIndex);
    }
    public void LoadSceneAdditive(int sceneIndex)
    {
        UIUtils.LoadSceneAdditive(sceneIndex);
    }
    public void QuitGame()
    {
        UIUtils.QuitGame();
    }
}