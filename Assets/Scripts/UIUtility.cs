using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private bool _debugMouseEvents;

    private UnityEngine.Events.UnityEvent _OnDestroy = new();

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