using UnityEngine;

public class StateSerializer : MonoBehaviour
{
    public string UUID { get { return _uuid; } }

    [ReadOnly, SerializeField] private string _uuid;

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