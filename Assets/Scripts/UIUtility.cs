using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static UIUtility instance;

    [SerializeField] private bool _debugMouseEvents;

    private UnityEngine.Events.UnityEvent _OnDestroy = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("UIUtility initialized.");
        }
        else
        {
            Debug.LogWarning("UIUtility already instanced, destroying self.", gameObject);
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
        SaveStateManager.ApplyLoadedFileToScene();
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_debugMouseEvents)
        {
            Debug.Log("OnPointerEnter " + gameObject.name);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_debugMouseEvents)
        {
            Debug.Log("OnPointerExit " + gameObject.name);
        }
    }
}