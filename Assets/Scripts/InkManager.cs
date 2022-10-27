using UnityEngine;
using Ink.Runtime;
using TMPro;

/// <summary>
/// Manage Ink Story.
/// </summary>
public class InkManager : MonoBehaviour
{
    public static InkManager Instance { get { return _instance; } }
    private static InkManager _instance;
    private Story _story;
    [SerializeField]
    private TextAsset _inkJSONAsset;
    [Tooltip("Drag the TMPro text UI object for the name of the speaker in here to have it updated.")] public TextMeshProUGUI NameText;
    [Tooltip("Drag the TMPro text UI object for dialogue content in here to have it updated.")] public TextMeshProUGUI DialogueText;

    void Awake()
    {
        _instance = this;
        StartStory();
    }

    /// <summary>
    /// Create a new Story object.
    /// </summary>
    void StartStory()
    {
        _story = new Story(_inkJSONAsset.text);
    }

    public void Continue() {
        //TODO: do while Continue(), afterward unlock player input and hide Dialogue menu
        //TODO: parse out name of character and set it
        SetDialogue(_story.Continue());

        // Unlock player input
        JTools.ImpactController.current.inputComponent.lockInput = false;
    }

    public void SetName(string newText) {
        NameText.text = newText;
    }

    public void SetDialogue(string newText) {
        DialogueText.text = newText;
    }
}