using UnityEngine;
using Ink.Runtime;

/// <summary>
/// Manage Ink Story.
/// </summary>
public class InkManager : MonoBehaviour
{
    public static InkManager Instance { get { return _instance; } }
    private static InkManager _instance;
    public Story story { get { return _story; } }
    private Story _story;
    [SerializeField]
    private TextAsset inkJSONAsset;

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
        _story = new Story(inkJSONAsset.text);
    }
}