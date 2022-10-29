using UnityEngine;
using Ink.Runtime;
using TMPro;

/// <summary>
/// Manage Ink Story.
/// </summary>
public class InkManager : MonoBehaviour
{
    private static InkManager _instance;

    public static bool IsPlaying { get; private set; }

    [SerializeField]
    private TextAsset _inkJSONAsset;
    [SerializeField, Tooltip("Drag the TMPro text UI object for the name of the speaker in here to have it updated.")]
    private TextMeshProUGUI NameText;
    [SerializeField, Tooltip("Drag the TMPro text UI object for dialogue content in here to have it updated.")]
    private TextMeshProUGUI DialogueText;

    private Story _story;
    private static bool _continuePlaying;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            Debug.Log("Ink Manager initialized.");
        }
        else
        {
            Debug.LogWarning("InkManager already instanced, destroying self.", this.gameObject);
            Destroy(this);
        }

        _story = new Story(_inkJSONAsset.text);
    }

    public static void PlayNext()
    {
        if (IsPlaying)
        {
            _continuePlaying = true;
        }
        else
        {
            _instance.StartCoroutine(_instance.ContinueStory());
        }
    }

    private System.Collections.IEnumerator ContinueStory()
    {
        JTools.ImpactController.current.inputComponent.lockInput = true;
        IsPlaying = true;
        _continuePlaying = true;
        UIMenus.SetActiveMenu("Dialogue");

        // TODO: parse out name of character and set it
        // TODO: condition for pausing story-level ink execution (indicating when a dialogue box should end)
        while (_instance._story.canContinue)
        {
            if (_continuePlaying)
            {
                SetDialogue(_instance._story.Continue());
                _continuePlaying = false;
            }
            yield return null;
        }

        EndDialogue();

        // Unlock player input
        UIMenus.HideMenu("Dialogue");
        IsPlaying = false;
        JTools.ImpactController.current.inputComponent.lockInput = false;
    }

    private static void SetName(string newText)
    {
        _instance.NameText.text = newText;
    }

    private static void SetDialogue(string newText)
    {
        _instance.DialogueText.text = newText;
    }

    private static void EndDialogue()
    {
        _instance.DialogueText.text = "";
    }
}