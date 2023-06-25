using UnityEngine;

public class StateSerializer : MonoBehaviour
{
    public string UUID { get { return this._uuid; } }

    [ReadOnly, SerializeField] private string _uuid;

    public StateSerializer()
    {
        RegenerateUUID();
    }

    [ContextMenu("Regenerate UUID")]
    public void RegenerateUUID()
    {
        this._uuid = System.Guid.NewGuid().ToString();
    }
}