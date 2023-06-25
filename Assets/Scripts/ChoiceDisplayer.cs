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
        for (int i = 0; i < _choicesObjects.Length; i++)
        {
            _choicesObjects[i].SetActive(false);
            _choicesObjects[i].GetComponent<Button>().onClick.AddListener(
                () =>
                {
                    // TODO: Special UI for when Ability trigger is required via tags
                    DisableChoices();
                    InkManager.PlayNext(i);
                });
            _choicesObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
        }
    }

    public void DisplayChoices(List<Choice> choices)
    {
        DisableChoices();

        for (int i = 0; i < choices.Count; i++)
        {
            _choicesObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i].text;
        }
    }

    private void DisableChoices()
    {
        for (int i = 0; i < _choicesObjects.Length; i++)
        {
            _choicesObjects[i].SetActive(false);
        }
    }
}
