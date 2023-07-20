using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _choicesObjects;

    private void Awake()
    {
        DisableChoices();
    }

    public void DisplayChoices(List<Choice> choices)
    {
        Debug.Log("Refreshing choices list.");

        for (int i = 0; i < choices.Count; i++)
        {
            Debug.Log(choices[i].index);
            Debug.Log(choices[i].text);
            int index = choices[i].index;
            _choicesObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i].text;
            _choicesObjects[i].GetComponent<Button>().onClick.AddListener(() => { SelectChoice(index); });
            _choicesObjects[i].SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
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
            _choicesObjects[i].SetActive(false);
            _choicesObjects[i].GetComponent<Button>().onClick.RemoveAllListeners();
            _choicesObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
        }
    }
}
