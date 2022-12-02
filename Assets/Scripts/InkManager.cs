using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;
using System.Collections;
using System.Text.RegularExpressions;

/// <summary>
/// Manage Ink Story.
/// </summary>
[RequireComponent(typeof(ChoiceDisplayer))]
public class InkManager : MonoBehaviour
{
    public static System.Action OnDialogueEnd;
    public static bool IsPlaying { get; private set; }

    private static InkManager _instance;

    [SerializeField]
    private TextAsset _inkJSONAsset;
    [SerializeField, Tooltip("Drag the TMPro text UI object for the name of the speaker in here to have it updated.")]
    private TextMeshProUGUI NameText;
    [SerializeField, Tooltip("Drag the TMPro text UI object for dialogue content in here to have it updated.")]
    private TextMeshProUGUI DialogueText;

    private ChoiceDisplayer _choiceDisplayer;

    private static Story _story;
    private static NPC _speakingNPC;
    private static bool _continuePlaying;
    private static bool _processingChoices;

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

        _choiceDisplayer = GetComponent<ChoiceDisplayer>();
        _story = new Story(_inkJSONAsset.text);
        SetName("");
    }

    public static void StopCoroutines()
    {
        _instance.StopAllCoroutines();
        if (IsPlaying)
        {
            EndDialogue(true);
        }
    }

    /// <summary>
    /// Return value of a boolean Ink variable.
    /// Returns false and logs a warning if the
    /// variable is not a boolean or the variable
    /// is null.
    /// </summary>
    public static bool CheckVariable(string inkVariable)
    {
        object obj = _story.variablesState[inkVariable];
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

    public static void PlayNext(string knotName)
    {
        if (IsPlaying)
        {
            _continuePlaying = true;
        }
        else
        {
            Debug.LogFormat("Starting dialogue from knot {0}", knotName);
            _story.ChoosePathString(knotName);
            _instance.StartCoroutine(_instance.ContinueFromStory());
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
            Debug.LogFormat("Starting dialogue from knot {0} from {1}", knotName, nextSpeakingNPC.Name);
            _speakingNPC = nextSpeakingNPC;
            _story.ChoosePathString(knotName);
            _instance.StartCoroutine(_instance.ContinueFromStory());
        }
    }

    public static void PlayNext(int choiceIndex)
    {
        if (!IsPlaying)
        {
            Debug.LogWarning("Called PlayNext with choice when no story is playing.");
            return;
        }

        _story.ChooseChoiceIndex(choiceIndex);
        _processingChoices = false;
        _continuePlaying = true;
    }

    private IEnumerator ContinueFromStory()
    {
        StartDialogue();

        string text;
        while (_story.canContinue || _processingChoices)
        {
            if (_continuePlaying && !_processingChoices)
            {
                text = _story.Continue();
                ParseNPCName(ref text);
                SetDialogue(text);

                _processingChoices = false;
                _continuePlaying = false;

                if (_story.currentChoices.Count > 0)
                {
                    _processingChoices = true;
                    _instance._choiceDisplayer.DisplayChoices(_story.currentChoices);
                }
            }
            yield return null;
        }

        // We don't have any more text, but we gotta wait to close the dialogue
        while (!_continuePlaying)
        {
            yield return null;
        }

        EndDialogue(false);
    }

    public static void DisplayObjectText(string objectName, string[] text)
    {
        if (text.Length == 0)
        {
            Debug.Log("DisplayObjectText was called with no text.");
            return;
        }

        if (IsPlaying)
        {
            _continuePlaying = true;
        }
        else
        {
            SetName(objectName);
            _instance.StartCoroutine(_instance.DisplayText(text));
        }
    }

    private IEnumerator DisplayText(string[] text)
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

        // We don't have any more text, but we gotta wait to close the dialogue
        while (!_continuePlaying)
        {
            yield return null;
        }

        EndDialogue(false);
    }

    private static void StartDialogue()
    {
        Debug.Log("Starting dialogue.");

        JTools.ImpactController.current.inputComponent.ChangeLockState(true);
        IsPlaying = true;
        _continuePlaying = true;
        UIMenus.GetMenu("Reticle").SetAlwaysEnabledOverride(false);
        UIMenus.GetMenu("Dialogue").SetAlwaysEnabledOverride(true);
        UIMenus.SetActiveMenu("Dialogue");
    }

    private static void EndDialogue(bool manuallyTerminated)
    {
        Debug.Log("Ending dialogue.");

        _instance.DialogueText.text = "";
        if (_speakingNPC != null)
        {
            _speakingNPC.SetAllowInteractSound(true);
            _speakingNPC = null;
        }

        if (!manuallyTerminated)
        {
            UIMenus.GetMenu("Dialogue").SetAlwaysEnabledOverride(false);
            UIMenus.GetMenu("Reticle").SetAlwaysEnabledOverride(true);
            UIMenus.SetActiveMenu("Reticle");
        }
        IsPlaying = false;

        if (OnDialogueEnd != null)
        {
            OnDialogueEnd();
            OnDialogueEnd = null;
        }

        JTools.ImpactController.current.inputComponent.ChangeLockState(false);
    }

    // private static readonly Regex nameRegex = new Regex("SISTER:|GRANDMOTHER:|BROTHER:|MOTHER:");
    private const string NAME_REGEX = @"(SISTER:|GRANDMOTHER:|BROTHER:|MOTHER:) ";
    private static void ParseNPCName(ref string text)
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
        Debug.LogFormat("Setting Dialogue to {0}", newText);

        _instance.DialogueText.text = newText;
    }
}