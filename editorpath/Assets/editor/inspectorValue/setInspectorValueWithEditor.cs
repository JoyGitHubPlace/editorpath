using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(inspectorValue))]
public class setInspectorValueWithEditor : Editor {
	inspectorValue item;

	public int ATKProp;
	public int LuckyPointProp;

	void OnEnable()
	{
		inspectorValue inspectorValueIten = target as inspectorValue;
		ATKProp = inspectorValueIten.ATK;
		LuckyPointProp = inspectorValueIten.LuckyPoint;
	}
	public override void OnInspectorGUI()
	{
		item = target as inspectorValue;
		int width = EditorGUILayout.IntField("Width", item.width);   //编辑器对应的值重设为mono中类对象操作的值
		if (item.width != width)
		{
			item.width = width;
		}

		ATKProp = EditorGUILayout.IntSlider("ATK", ATKProp, 0, 100);
		ProgressBar((ATKProp / 100.0f), "ATK");

		LuckyPointProp = EditorGUILayout.IntSlider("Lucky Point", LuckyPointProp, 0, 5);
		ProgressBar((LuckyPointProp / 5.0f), "Lucky Point");


		base.DrawDefaultInspector();
	}

	private void ProgressBar(float value, string label)
	{
		//定义 Rect
		Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
		//创建progressbar
		EditorGUI.ProgressBar(rect, value, label);
		//添加一个空行
		EditorGUILayout.Space();
	}

}
