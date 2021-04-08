using System.IO;
using UnityEngine;
using UnityEditor;

public class serializeWindow : EditorWindow
{
    private string savePath = "Assets/Serialization/Serialization_Data.asset";
    private serializeBase m_serializeBase;

    [MenuItem("myEditor/Serialization")]
    static void Init()
    {
        var window = GetWindow(typeof(serializeWindow));
        window.title = "Serialization";
        window.Show();
    }

    void OnEnable()
    {
        if (m_serializeBase == null)
        {
            m_serializeBase = ScriptableObject.CreateInstance<serializeBase>();
        }

        if (File.Exists(savePath))
        {
            m_serializeBase = AssetDatabase.LoadAssetAtPath(savePath, typeof(Object)) as serializeBase;
        }
        else
        {
            AssetDatabase.CreateAsset(m_serializeBase, savePath);
            AssetDatabase.SaveAssets();
        }
    }

    void OnGUI()
    {
        GUILayout.Label("m_serializeBase info", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox("Serialized this  config save to \"Assets/Serialization/Serialization_Data.asset\"", MessageType.Info);
        m_serializeBase.OnGUI();

        if (GUI.changed)
        {
            //存盘数据
            EditorUtility.SetDirty(m_serializeBase);
        }
    }
}