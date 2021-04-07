using UnityEngine;
using UnityEditor;

/// <summary>
/// 查看默认的gui skin样式
/// </summary>
public class baseStyles : EditorWindow
{
    private Vector2 scrollPosition = Vector2.zero;
    private string search = string.Empty;

    [MenuItem("myEditor/baseEditor")]    //脑子不好使，整下来基于样式方便复制粘贴style名，哈哈哈
    static void Init()
    {
        var window = EditorWindow.GetWindow<baseStyles>();
        window.title = "baseEditor list";
        window.Show();

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal("HelpBox");
        GUILayout.Label("我是一个label", "label");
        GUILayout.FlexibleSpace();
        GUILayout.Label("查找:");
        search = EditorGUILayout.TextField(search);
        GUILayout.EndHorizontal();

        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

        foreach (GUIStyle style in GUI.skin)
        {
            //过滤
            if (style.name.ToLower().Contains(search.ToLower()))
            {
                //设置奇偶行不同背景
                GUILayout.BeginHorizontal("PopupCurveSwatchBackground");
                GUILayout.Space(20);//左边留白20
                if (GUILayout.Button(style.name, style))
                {
                    //把名字存储在剪粘板 
                    EditorGUIUtility.systemCopyBuffer = style.name; 
                }
                GUILayout.FlexibleSpace();
                EditorGUILayout.SelectableLabel("\"" + style.name + "\"");
                GUILayout.EndHorizontal();
                GUILayout.Space(20);//右边留白20
            }
        }

        GUILayout.EndScrollView();
    }
}