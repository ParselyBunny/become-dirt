using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

/// <summary>
/// Manage Ink Story.
/// </summary>
[RequireComponent(typeof(ChoiceDisplayer))]
public class InkManager : MonoBehaviour
{
    public static InkManager Instance { get; private set; }
    public static System.Action OnDialogueEnd;


    //Text Speed and Skipping Lines
    [Header("Text Display")]
    public float textspeed = .01f;
    public Dictionary<char, float> specialtextdelays = new Dictionary<char, float>();
    public AudioSource textnoise;
    public AudioClip[] textnoises;

    [Header("NonChar Lines")]
    public GameObject NameBoxChild;

    [Header("Character Visuals")]
    public List<CharNamePair> CharPortraits;
    public List<UiCharacter> CharVisuals;
    public GameObject CharVisualsPlacer;
    public GameObject CharacterPrefab;

    [Header("ContinueVisual")]
    public RectTransform continueindicator;
    private float boty = 20;
    private float topy = 90;

    private bool DisplayingLine;
    private bool SkipCalled;
    public static bool IsPlaying { get; private set; }

    private static Dictionary<string, System.Action<string>> TagActions = new Dictionary<string, Action<string>>();

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
    private static string _currentPath;

    private void Start()
    {
        specialtextdelays.Add(',', 10f);
        specialtextdelays.Add('-', 10f);
        specialtextdelays.Add(';', 10f);
        specialtextdelays.Add('.', 20f);
        specialtextdelays.Add('?', 20f);
        specialtextdelays.Add('!', 20f);

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    public void Update()
    {
        float target = DisplayingLine ? boty : topy;
        Vector3 targetpos = new Vector3(continueindicator.localPosition.x, target, continueindicator.localPosition.z);
        continueindicator.localPosition = Vector3.Lerp(continueindicator.localPosition, targetpos, Time.deltaTime * 10);

        if (DisplayingLine && !SkipCalled)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                SkipCalled = true;
            }
        }
    }

    private void OnDestroy()
    {
        Instance.StopAllCoroutines();
        if (IsPlaying)
        {
            EndDialogue(true);
        }
    }

    public string[] GetAllKnots()
    {
        Story story = _story;
        if (story == null)
        {
            story = new Story(this._inkJSONAsset.text);
        }

        var knotList = new List<string>();
        story.mainContentContainer.namedContent.ToList()
            .ForEach(knot =>
            {
                knotList.Add(knot.Key);
                story.ContentAtPath(new Path(knot.Key)).container.namedContent.ToList()
                    .ForEach(stitch => { knotList.Add(string.Format("{0}.{1}", knot.Key, stitch.Key)); });
            });

        // Action<Dictionary<string, INamedContent>> contentFunc = (Dictionary<string, INamedContent> knots) => { };
        // contentFunc = (Dictionary<string, INamedContent> knots) =>
        // {
        //     knots.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Debug.Log);
        //     foreach (var knot in knots)
        //     {
        //         knotList.Add(knot);
        //         story.ContentAtPath(new Path(knot.Key)).container.namedContent
        //         // contentFunc(story.ContentAtPath(new Path(knot.Key)).container.namedContent);
        //         // contentFunc(knot);
        //     }
        // };
        // var knots = story.mainContentContainer.namedContent;
        // contentFunc(knots);

        return knotList.ToArray();
    }

    public static void ToggleReticle(bool showReticle)
    {
        // TODO: Decouple reticle code from this file
        if (showReticle)
        {
            UIMenus.GetMenu("Dialogue").SetAlwaysEnabledOverride(false);
            UIMenus.GetMenu("Reticle").SetAlwaysEnabledOverride(true);
            UIMenus.SetActiveMenu("Reticle");
        }
        else
        {
            UIMenus.GetMenu("Reticle").SetAlwaysEnabledOverride(false);
            UIMenus.GetMenu("Dialogue").SetAlwaysEnabledOverride(true);
            UIMenus.SetActiveMenu("Dialogue");
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

    public static void AddTagChecker(string tag, Action<string> action)
    {
        if (TagActions.ContainsKey(tag) && TagActions[tag] != null)
        {
            TagActions[tag] += action;
        }
        else
        {
            TagActions.Add(tag, action);
        }
    }

    public static void RemoveTagChecker(string tag, Action<string> action)
    {
        if (TagActions.ContainsKey(tag) && TagActions[tag] != null)
        {
            TagActions[tag] -= action;
        }
    }

    public static void PlayNext()
    {
        if (IsPlaying)
        {
            _continuePlaying = true;
        }
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
            SetKnot(knotName);
            Instance.StartCoroutine(Instance.ContinueFromStory());
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
            SetKnot(knotName);
            Instance.StartCoroutine(Instance.ContinueFromStory());
        }
    }

    public static void ChooseChoice(int choiceIndex)
    {
        if (!IsPlaying)
        {
            Debug.LogWarning("Called ChooseChoice when no story is playing.");
            return;
        }

        Debug.Log(_story.currentChoices);
        Debug.Log(choiceIndex);

        _story.ChooseChoiceIndex(choiceIndex);
        _processingChoices = false;
    }

    public static void SetKnot(string knotName)
    {
        if (_currentPath != knotName)
        {
            Debug.LogFormat("Manually changing knot from {0} to {1}", _currentPath, knotName);
            _currentPath = knotName;
            _story.ChoosePathString(knotName);
        }
        else if (!_story.canContinue)
        {
            Debug.LogFormat("Resetting current path since story cannot continue", _currentPath, knotName);
            _story.ChoosePathString(knotName);
        }
    }

    private IEnumerator ContinueFromStory()
    {
        StartDialogue();

        string text;
        while (_story.canContinue || _story.currentChoices.Count > 0)
        {
            if (_continuePlaying)
            {
                if (_story.currentChoices.Count > 0)
                {
                    _processingChoices = true;
                    Instance._choiceDisplayer.DisplayChoices(_story.currentChoices);

                    while (_processingChoices)
                    {
                        yield return null;
                    }
                }

                text = _story.Continue();
                Debug.Log("Setting Name");
                ParseNPCName(ref text);

                foreach (string tag in _story.currentTags)
                {
                    if (TagActions[tag] != null)
                    {
                        TagActions[tag].Invoke(tag);
                    }
                }
                //New method of displaying text
                DisplayingLine = true;
                SetDialogue(text);
                yield return new WaitUntil(() => DisplayingLine == false);

                _continuePlaying = false;
            }
            yield return null;
        }

        // We don't have any more text, but dialogue shouldn't close until another input
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
            Debug.Log("DisplayObjectText Called");
            Instance.StartCoroutine(Instance.DisplayText(text));
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
                DisplayingLine = true;

                SetDialogue(text[currentIndex]);
                yield return new WaitUntil(() => DisplayingLine == false);
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

        IsPlaying = true;
        _continuePlaying = true;
    }

    private static void EndDialogue(bool forced)
    {
        Debug.LogFormat("Ending dialogue. Forced = {0}", forced);

        if (!forced)
        {
            if (OnDialogueEnd != null)
            {
                OnDialogueEnd();
            }
        }

        Instance.DialogueText.text = "";
        _speakingNPC = null;
        SetName("");

        for (int i = 0; i < Instance.CharVisuals.Count; i++)
        {
            Destroy(Instance.CharVisuals[i].gameObject);
        }
        Instance.CharVisuals.Clear();

        OnDialogueEnd = null;
        IsPlaying = false;
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
            Instance.NameBoxChild.SetActive(true);
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
                    Instance.NameText.text = name;
                    text = text.Substring(match.Value.Length);
                    break;
            }
        }
        else
        {
            Instance.NameBoxChild.SetActive(false);
        }
        Instance.updateCharVisuals(name);
    }

    private static void SetName(string name)
    {
        Instance.NameText.text = name;
    }

    public static void SetDialogue(string text)
    {
        Instance.StartCoroutine(Instance.SetDialogueIE(text));
    }

    private IEnumerator SetDialogueIE(string newText)
    {
        SkipCalled = false;
        DisplayingLine = true;
        Debug.LogFormat("Setting Dialogue to {0}", newText);

        DialogueText.maxVisibleCharacters = 0;
        DialogueText.text = newText;

        for (int i = 0; i < newText.Length; i++)
        {
            if (SkipCalled) break;
            DialogueText.maxVisibleCharacters = i + 1;


            float tempdelaytime = textspeed;
            if (specialtextdelays.ContainsKey(newText[i]))
                tempdelaytime *= specialtextdelays[newText[i]];
            yield return new WaitForSeconds(tempdelaytime);

            if (newText[i] != ' ')
                playpennoise();
        }

        DialogueText.maxVisibleCharacters = newText.Length + 1;
        playpennoise();
        DisplayingLine = false;

    }

    public void playpennoise()
    {
        textnoise.clip = textnoises[Random.Range(0, textnoises.Length)];
        textnoise.pitch = Random.Range(.9f, 1.1f);
        textnoise.Play();
    }

    public void updateCharVisuals(string activename)
    {
        if (!CharVisuals.Find(c => c.name == activename) && activename != "")
        {
            GameObject g = Instantiate(CharacterPrefab, CharVisualsPlacer.transform);
            UiCharacter c = g.GetComponent<UiCharacter>();
            c.name = activename;
            c.character.sprite = CharPortraits.Find(p => p.name.ToLower() == activename.ToLower()).image;
            CharVisuals.Add(c);
        }

        foreach (UiCharacter uic in CharVisuals)
        {
            uic.setActive(uic.name == activename);
        }
    }
}


[System.Serializable]
public class CharNamePair
{
    public string name;
    public Sprite image;
    public CharNamePair(string _name, Sprite _image)
    {
        name = _name;
        image = _image;
    }
}
