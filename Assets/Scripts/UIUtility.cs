public class UIUtility : UnityEngine.MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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