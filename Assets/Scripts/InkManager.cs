using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;

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
        } else {
            _instance.StartCoroutine(_instance.ContinueStory());
        }
    }

    /// <summary>
    /// Check if a string 
    /// </summary>
    public static bool CheckVariable(string inkVariable) {
        object obj = _instance._story.variablesState[inkVariable];
        bool val = false;

        if (obj != null) {
            Type t = obj.GetType();
            
            if (t.Equals(typeof(bool))) {
                val = (bool)obj;
            } else {
                Debug.LogWarning(inkVariable + " is not a boolean. Please check that the correct variable is being defined in the editor.");
            }
        } else {
            Debug.LogWarning(inkVariable + " evaluates to null. Please check that the variable is defined in the Ink file and that the spelling in the editor is correct.");
        }

        return val;
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