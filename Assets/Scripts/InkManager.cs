using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;
using System.Collections;
using System.Text.RegularExpressions;

/// <summary>
/// Manage Ink Story.
/// </summary>
public class InkManager : MonoBehaviour
{
    private static InkManager _instance;

    public static System.Action OnDialogueEnd;
    public static bool IsPlaying { get; private set; }

    [SerializeField]
    private TextAsset _inkJSONAsset;
    [SerializeField, Tooltip("Drag the TMPro text UI object for the name of the speaker in here to have it updated.")]
    private TextMeshProUGUI NameText;
    [SerializeField, Tooltip("Drag the TMPro text UI object for dialogue content in here to have it updated.")]
    private TextMeshProUGUI DialogueText;

    private Story _story;
    private static bool _continuePlaying;
    private NPC _speakingNPC;

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

    /// <summary>
    /// Return value of a boolean Ink variable.
    /// Returns false and logs a warning if the
    /// variable is not a boolean or the variable
    /// is null.
    /// </summary>
    public static bool CheckVariable(string inkVariable)
    {
        object obj = _instance._story.variablesState[inkVariable];
        bool val = false;

        if (obj != null)
        {
            Type t = obj.GetType();

            if (t.Equals(typeof(bool)))
            {
                val = (bool)obj;
            }
            else
            {
                Debug.LogError(inkVariable + " is not a boolean. Please check that the correct variable is being defined in the editor.");
            }
        }
        else
        {
            Debug.LogError(inkVariable + " evaluates to null. Please check that the variable is defined in the Ink file and that the spelling in the editor is correct.");
        }

        return val;
    }


    private static void StartDialogue()
    {
        JTools.ImpactController.current.inputComponent.lockInput = true;
        IsPlaying = true;
        _continuePlaying = true;
        UIMenus.SetActiveMenu("Dialogue");
    }

    private static void EndDialogue()
    {
        _instance.DialogueText.text = "";
        if (_instance._speakingNPC != null)
        {
            _instance._speakingNPC.SetAllowInteractSound(true);
            _instance._speakingNPC = null;
        }
        // Unlock player input
        UIMenus.SetActiveMenu("Reticle");
        IsPlaying = false;
        OnDialogueEnd();
        JTools.ImpactController.current.inputComponent.lockInput = false;
    }

    public static void PlayNext(string knotName)
    {
        if (IsPlaying)
        {
            _continuePlaying = true;
        }
        else
        {
            _instance._story.ChoosePathString(knotName);
            _instance.StartCoroutine(_instance.ContinueStory());
        }
    }

    public static void PlayNext(string knotName, NPC nextSpeakingNPC)
    {
        if (IsPlaying)
        {
            _continuePlaying = true;
        }
        else
        {
            _instance._speakingNPC = nextSpeakingNPC;
            _instance._story.ChoosePathString(knotName);
            _instance.StartCoroutine(_instance.ContinueStory());
        }
    }

    private IEnumerator ContinueStory()
    {
        StartDialogue();

        // TODO: parse out name of character and set it
        // TODO: condition for pausing story-level ink execution (indicating when a dialogue box should end)
        string text;
        while (_instance._story.canContinue)
        {
            if (_continuePlaying)
            {
                text = _instance._story.Continue();
                ParseName(ref text);
                SetDialogue(text);
                _continuePlaying = false;
            }
            yield return null;
        }

        EndDialogue();
    }

    public static void ShowExamineText(string objectName, string[] text)
    {
        if (IsPlaying)
        {
            _continuePlaying = true;
        }
        else
        {
            SetName(objectName);
            _instance.StartCoroutine(_instance.ShowText(text));
        }
    }

    private IEnumerator ShowText(string[] text)
    {
        StartDialogue();

        var currentIndex = 0;
        while (currentIndex < text.Length)
        {
            if (_continuePlaying)
            {
                SetDialogue(text[currentIndex]);
                _continuePlaying = false;
                currentIndex++;
            }
            yield return null;
        }

        EndDialogue();
    }

    // private static readonly Regex nameRegex = new Regex("SISTER:|GRANDMOTHER:|BROTHER:|MOTHER:");
    private const string NAME_REGEX = @"(SISTER:|GRANDMOTHER:|BROTHER:|MOTHER:) ";
    private static void ParseName(ref string text)
    {
        if (text == "")
        {
            return;
        }

        // regex `SISTER:|GRANDMOTHER:|BROTHER:|MOTHER:`
        var match = Regex.Match(text, NAME_REGEX);
        string name = "";
        if (match.Success)
        {
            switch (match.Value)
            {
                case "SISTER: ":
                    name = "Sister";
                    goto default;
                case "GRANDMOTHER: ":
                    name = "Grandmother";
                    goto default;
                case "MOTHER: ":
                    name = "Mother";
                    goto default;
                case "BROTHER: ":
                    name = "Brother";
                    goto default;
                default:
                    _instance.NameText.text = name;
                    text = text.Substring(match.Value.Length);
                    break;
            }
        }
    }

    private static void SetName(string name)
    {
        _instance.NameText.text = name;
    }

    private static void SetDialogue(string newText)
    {
        _instance.DialogueText.text = newText;
    }
}