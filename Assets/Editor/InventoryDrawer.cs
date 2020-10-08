using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Equipment))]
public class InventoryDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // opens property
        label = EditorGUI.BeginProperty(position, label, property);

        // draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // don't intent child fields (sets indent but saves current indent (1?)
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var nameRect = new Rect(position.x, position.y, 110, position.height);
        var valueRect = new Rect(position.x + 115, position.y, 30, position.height);
        var rarityRect = new Rect(position.x + 150, position.y, 80, position.height);
        var slotRect = new Rect(position.x + 235, position.y, position.width - 235, position.height);

        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("itemName"), GUIContent.none);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("statValue"), GUIContent.none);
        EditorGUI.PropertyField(rarityRect, property.FindPropertyRelative("itemRarity"), GUIContent.none);
        EditorGUI.PropertyField(slotRect, property.FindPropertyRelative("itemSlot"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
