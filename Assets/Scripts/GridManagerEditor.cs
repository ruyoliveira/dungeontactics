using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/*
[CustomEditor(typeof(GridManager))]
[CanEditMultipleObjects]
public class GridManagerEditor : Editor
{
    SerializedProperty width;
    SerializedProperty height;
    int x = 0;
    int y  = 0;

    void OnEnable()
    {
        width = serializedObject.FindProperty("width");
        height = serializedObject.FindProperty("height");

    }
    public override void OnInspectorGUI()
    {


        serializedObject.Update();
        EditorGUILayout.PropertyField(width);
        EditorGUILayout.PropertyField(height);

        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Generate"))
        {
            GridManager obj = (GridManager)target;
            obj.GenerateGrid(width.intValue,height.intValue);
        }

        if (GUILayout.Button("Clear"))
        {
            GridManager obj = (GridManager)target;
            obj.ClearGrid();
        }


        x = EditorGUILayout.IntField("X: ", x);
        y = EditorGUILayout.IntField("Y: ", y);
        if (GUILayout.Button("Select tile"))
        {
            GridManager obj = (GridManager)target;
            obj.SelectTile(x,y);
        }

    }
}
*/