using UnityEditor;
using UnityEngine;

// Attribute logic from: https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html
public class ReadOnlyAttribute : PropertyAttribute
{

}

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}

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