using UnityEngine.SceneManagement;

public static class UIUtils
{
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public static void LoadSceneAdditive(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Additive);
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif
    }
}