using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Inventory inventory = (Inventory)target;

        EditorGUILayout.HelpBox("These Two Buttons blah blah blah.", MessageType.Info);
        GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save Inventory"))
            {
                string path = EditorUtility.SaveFilePanel("Save JSON", "", "inventory", "json");
                if (path != "")
                    inventory.SaveToFile(path);
            }

            if (GUILayout.Button("Load Inventory"))
            {
                string path = EditorUtility.OpenFilePanel("Select JSON File", "", "json");
                if(path != "")
                    inventory.LoadJsonArray(path);
            }
        GUILayout.EndHorizontal();

        
    }
}
