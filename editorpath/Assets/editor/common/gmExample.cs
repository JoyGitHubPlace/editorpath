using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class gmExample : EditorWindow
{

    [MenuItem("myEditor/GM指令")]
    static void Init()
    {
        var window = EditorWindow.GetWindow<gmExample>();
        window.title = " GM指令";
        window.Show();
    }

    private int newExp = 0, newMoney = 0, newVip = 0,  newCoin = 0;
    private string uuid = "";
    private int maxHp = 0, maxVp = 0, maxHurt = 0, newVp = 0, newSpirts = 0;

    private int nMapId = 0;

    public void OnGUI()
    {
        EditorGUILayout.LabelField("== 加数值 指令 ==");

        GUILayout.BeginHorizontal();
        GUILayout.Label("用户id:");
        uuid = EditorGUILayout.TextField(uuid, GUILayout.ExpandWidth(true), GUILayout.MinHeight(20));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("经验:");
        newExp = EditorGUILayout.IntField(newExp, GUILayout.ExpandWidth(true), GUILayout.MinHeight(20));
        if (GUILayout.Button("加经验", GUILayout.MinWidth(100), GUILayout.MaxHeight(20)))
        {
            if (uuid=="") {
                Debug.LogWarning("uuid不能为空");
            }
            //AddExp(newExp,uuid);
        }
        //-------
        GUILayout.Label("VIP钱:");
        newVip = EditorGUILayout.IntField(newVip, GUILayout.ExpandWidth(true), GUILayout.MinHeight(20));
        if (GUILayout.Button("加VIP", GUILayout.MinWidth(100), GUILayout.MaxHeight(20)))
        {
            if (uuid == "")
            {
                Debug.LogWarning("uuid不能为空");
            }
            //AddVip(newVip,uuid);
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("金币:");
        newCoin = EditorGUILayout.IntField(newCoin);
        if (GUILayout.Button("加金币", GUILayout.MinWidth(100), GUILayout.MaxHeight(20)))
        {
            if (uuid == "")
            {
                Debug.LogWarning("uuid不能为空");
            }
            //AddCoin(newCoin,uuid);
        }
        //-------
        GUILayout.Label("元宝");
        newMoney = EditorGUILayout.IntField(newMoney);
        if (GUILayout.Button("加元宝", GUILayout.MinWidth(100), GUILayout.MaxHeight(20)))
        {
            if (uuid == "")
            {
                Debug.LogWarning("uuid不能为空");
            }
            //AddMoney(newMoney,uuid);
        }
        GUILayout.EndHorizontal();
        //自主扩展
    }
}