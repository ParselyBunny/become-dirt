using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _choicesObjects;
    public GameObject becomeDirt;

    private void Awake()
    {
        DisableChoices();
    }

    public void DisplayChoices(List<Choice> choices)
    {
        Debug.Log("Refreshing choices list.");

        List<string> currentTag = new();
        Dictionary<string, string> sanitizedChoiceTags = new();
        for (int i = 0; i < choices.Count; i++)
        {
            Debug.Log("C" + choices[i].index + ": " + choices[i].text);
            int index = choices[i].index;


            if (choices[i].tags != null)
            {
                foreach (string tag in choices[i].tags)
                {
                    currentTag = tag.Split('$').ToList();
                    var tagAction = InkManager.ChoiceTagMethod(currentTag[0]);
                    if (currentTag.Count > 1)
                    {
                        sanitizedChoiceTags.Add(currentTag[0], currentTag[1]);
                        tagAction?.Invoke(currentTag[1]);
                    }
                    else
                    {
                        tagAction?.Invoke("");
                    }
                }
                currentTag.Clear(); // cleanup
            }

            if (sanitizedChoiceTags.ContainsKey("sigil"))
            {
                becomeDirt.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Sigil Activated."); SelectChoice(index); });
                becomeDirt.GetComponent<Button>().interactable = true;
                // TODO: Swap sigil graphic based on `sanitizedTags["sigil"]`
            }
            else
            {
                _choicesObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i].text;
                _choicesObjects[i].GetComponent<Button>().onClick.AddListener(() => { SelectChoice(index); });
                _choicesObjects[i].GetComponent<Button>().interactable = true;
            }

            sanitizedChoiceTags.Clear();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<EventSystem>().SetSelectedGameObject(_choicesObjects[0]);
    }

    private void SelectChoice(int index)
    {
        // TODO: Special UI for when Ability trigger is required via tags
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InkManager.ChooseChoice(index);
        DisableChoices();
    }

    private void DisableChoices()
    {
        for (int i = 0; i < _choicesObjects.Length; i++)
        {
            _choicesObjects[i].GetComponent<Button>().interactable = false;
            _choicesObjects[i].GetComponent<Button>().onClick.RemoveAllListeners();
            _choicesObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
        }

        becomeDirt.GetComponent<Button>().interactable = false;
        becomeDirt.GetComponent<Button>().onClick.RemoveAllListeners();
        becomeDirt.GetComponent<Animator>().SetTrigger("Disabled");
    }
}
