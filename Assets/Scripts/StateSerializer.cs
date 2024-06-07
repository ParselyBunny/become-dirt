using UnityEngine;

[DisallowMultipleComponent]
public class StateSerializer : MonoBehaviour
{
    public string UUID { get { return _uuid; } }

    public bool SkipSave { get { return _skipSave; } }

    [ReadOnly, SerializeField] private string _uuid;
    [SerializeField] private bool _skipSave;

    public StateSerializer()
    {
        RegenerateUUID();
    }

    [ContextMenu("Regenerate UUID")]
    public void RegenerateUUID()
    {
        _uuid = System.Guid.NewGuid().ToString();
    }
}