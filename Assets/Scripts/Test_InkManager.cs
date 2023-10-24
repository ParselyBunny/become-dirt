using UnityEngine;

[RequireComponent(typeof(InkManager))]
public class Test_InkManager : MonoBehaviour
{
    [System.Serializable]
    public class Knot
    {
        public string _name;

        public Knot(string name)
        {
            this._name = name;
        }
    }

    [SerializeField, InspectorButton("Continue")]
    private bool ContinueStory; // typing here is irrelevant, just used for the name

    // Custom button to refresh knot list
    [SerializeField, InspectorButton("LoadKnotList")]
    private bool ReloadKnotList; // typing here is irrelevant, just used for the name

    [SerializeField]
    private Knot[] _content = new Knot[] { };

    private static bool _loaded = false;

    private void Start()
    {
        if (InkManager.Instance == null)
        {
            Debug.LogError("cannot use InkManager_test runtime features, InkManager not initialized");
        }

        _loaded = true;
    }

    private void LoadKnotList()
    {
        Debug.Log("Reloading knot list.");
        var newContent = this.GetComponent<InkManager>().GetAllKnots();
        _content = new Knot[newContent.Length];
        for (int i = 0; i < newContent.Length; i++)
        {
            _content[i] = new Knot(newContent[i]);
        }

        // this._content.Select(i => $"{i}").ToList().ForEach(Debug.Log);
    }

    private void Continue()
    {
        if (!_loaded)
        {
            Debug.LogWarning("Cannot execute runtime-intended method Continue while not in runtime");
            return;
        }

        InkManager.PlayNext();
    }

    public static void PlayNext(string knotName)
    {
        if (!_loaded)
        {
            Debug.LogWarning("Cannot execute runtime-intended method PlayNext while not in runtime");
            return;
        }

        InkManager.SetKnot(knotName);
        InkManager.PlayNext(knotName);
    }
}
