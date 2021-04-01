using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(objEditorTest))]
public class editorscene : Editor{
	[DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
	static void DrawGameObjectName(Transform tran, GizmoType gizmoType) //场景刷新绘制的时候执行一次
	{
		if (singleItem.Instance.isopenSeneInfo) {
			Vector3 pos = tran.position;
			string itemName = tran.name;
			Handles.Label(pos, itemName + "/" + gizmoType);
			singleItem.Instance.globalNum++;
			Debug.Log("singleItem.Instance.globalNum" + singleItem.Instance.globalNum);
		}
		
	}
	void OnSceneGUI()    //需要选中才可以响应展示
	{
		//得到test脚本的对象
		objEditorTest Ctest = (objEditorTest)target;
		drawSceneInfo(Ctest);
	}

	void drawSceneInfo(objEditorTest item) {

			string gameName = item.transform.name;
			string labeltext = gameName + " : " + item.transform.position.ToString();
			Vector3 labelpos = item.transform.position + Vector3.up;
			//绘制文本框
			Handles.Label(labelpos, labeltext);

			//开始绘制GUI
			Handles.BeginGUI();

			//规定GUI显示区域
			GUILayout.BeginArea(new Rect(100, 100, 300, 100));

			//GUI绘制一个按钮
			if (GUILayout.Button("这是一个按钮!", GUILayout.Width(200)))
			{
				Debug.Log("my click gameobject:" + gameName);
			}
			//GUI绘制文本框
			GUILayout.Label("我在编辑Scene视图的" + gameName);

			GUILayout.EndArea();

			Handles.EndGUI();
		
		
	}

}
