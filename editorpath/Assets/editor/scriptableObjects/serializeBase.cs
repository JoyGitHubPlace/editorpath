using UnityEditor;
using UnityEngine;


[System.Serializable]

public class serializeBase : ScriptableObject {

    [SerializeField]
    private string stringParam = "test";
    [SerializeField]
    private int intParam = 5;

    public void OnGUI()
    {
        stringParam = EditorGUILayout.TextField("Name", stringParam);
        intParam = EditorGUILayout.IntSlider("Value", intParam, 0, 10);
    }
}
