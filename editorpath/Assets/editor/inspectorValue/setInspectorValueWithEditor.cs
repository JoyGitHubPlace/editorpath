using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(inspectorValue))]
public class setInspectorValueWithEditor : Editor {
	inspectorValue item;
	public override void OnInspectorGUI()
	{
		item = target as inspectorValue;
		int width = EditorGUILayout.IntField("Width", item.width);   //编辑器对应的值重设为mono中类对象操作的值
		if (item.width != width)
		{
			item.width = width;
		}
		base.DrawDefaultInspector();
	}

}
