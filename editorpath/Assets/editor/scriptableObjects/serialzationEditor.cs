using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(serialzationInspector))]
public class serialzationEditor : EditorWindow {

    private string savePath = "Assets/Serialization/Serialization_Data1.asset";
    private serialzationInspector m_serializeBase;
	private string text;
    [MenuItem("myEditor/serialzationAction")]
    static void AddWindow()
    {
        //创建窗口
        Rect wr = new Rect(0, 0, 500, 500);
        serialzationEditor window = (serialzationEditor)EditorWindow.GetWindowWithRect(typeof(serialzationEditor), wr, true, "widowbase");
        window.Show();

    }
    void OnEnable()
    {
        if (File.Exists(savePath))
        {
            m_serializeBase = AssetDatabase.LoadAssetAtPath(savePath, typeof(Object)) as serialzationInspector;
        }
        text = m_serializeBase.string1;
    }
    void OnGUI()
	{
		//输入框控件
		text = EditorGUILayout.TextField("输入文字:", text);

		if (GUILayout.Button("设置", GUILayout.Width(200)))
		{
            AssetDatabase.DeleteAsset(savePath);   //需要先清除原有的部分
            if (m_serializeBase == null)
                {
                    m_serializeBase = ScriptableObject.CreateInstance<serialzationInspector>();
                }
                m_serializeBase.string1 = text;
                 
            
                AssetDatabase.CreateAsset(m_serializeBase, savePath);
                AssetDatabase.SaveAssets();
            
        }

		if (GUILayout.Button("读取", GUILayout.Width(200)))
		{
            if (File.Exists(savePath))
            {
                m_serializeBase = AssetDatabase.LoadAssetAtPath(savePath, typeof(Object)) as serialzationInspector;
            }
            Debug.Log(m_serializeBase.num1);
            Debug.Log(m_serializeBase.string1);

        }


		if (GUILayout.Button("关闭窗口", GUILayout.Width(200)))
		{
			//关闭窗口
			this.Close();
		}

	}
	



}
