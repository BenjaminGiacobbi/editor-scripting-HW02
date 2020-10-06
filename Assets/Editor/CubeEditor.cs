using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Cube cube = (Cube)target;

        GUILayout.Label("Osscilates around a base size.");
        cube._baseSize = EditorGUILayout.Slider("Size:", cube._baseSize, .1f, 2f);
        cube.transform.localScale = Vector3.one * cube._baseSize;

        GUILayout.Label("Assigns a random color.");
        GUILayout.BeginHorizontal();
            if(GUILayout.Button("Generator Color"))
            {
                Debug.Log("Change Color");
                cube.GenerateColor();
            }

            if(GUILayout.Button("Reset Color"))
            {
                Debug.Log("Reset to white");
                cube.ResetColor();
            }
        GUILayout.EndHorizontal();
    }
}
