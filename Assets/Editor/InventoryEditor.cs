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

        GUILayout.Space(50);

        EditorGUILayout.HelpBox("Save or load JSON representations of the inventory script for external editing", MessageType.Info);
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
