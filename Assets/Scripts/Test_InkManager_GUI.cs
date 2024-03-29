#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Test_InkManager.Knot))]
public class Test_InkManager_GUI : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var buttonRect = new Rect(position.x, position.y, 250, position.height);
        // var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
        // var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        // var style = new GUIStyle();
        // style.alignment = TextAnchor.MiddleLeft;
        if (GUI.Button(buttonRect, "Inject"))
        {
            Test_InkManager.PlayNext(label.text);
        }

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        // EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("_name"), GUIContent.none);
        // EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("unit"), GUIContent.none);
        // EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
#endif