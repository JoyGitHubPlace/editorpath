using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class myEditorWindow_SceneInfo : EditorWindow {

	[MenuItem("myEditor/sceneInfo")]
	static void AddWindow()
	{
		//创建窗口
		Rect winRect = new Rect(0, 0, 500, 500);
		myEditorWindow_SceneInfo window = (myEditorWindow_SceneInfo)EditorWindow.GetWindowWithRect(typeof(myEditorWindow_SceneInfo), winRect, true, "sceneObjectInfo");
		window.Show();

	}

	
	public float Tnum = 0;   //坑爹呀，editor里面不支持invoke，写了很不情愿的计时器
	public bool isopennatification = false;

	public void Awake()
	{
		Tnum = 0;
	}
	void closedNotification() {
		this.RemoveNotification();
		Tnum = 0;
	}
	//绘制窗口时调用
	void OnGUI()
	{
		if (isopennatification) {
			if (Tnum>100) {
				isopennatification = false;
				this.closedNotification();
			}
		}
		if (GUILayout.Button("打开场景信息展示", GUILayout.Width(200)))
		{
			singleItem.Instance.isopenSeneInfo = true;
			this.ShowNotification(new GUIContent("场景信息展示开关已打开"));
			isopennatification = true;
		}

		if (GUILayout.Button("关闭场景信息展示", GUILayout.Width(200)))
		{
			singleItem.Instance.isopenSeneInfo = false;
			this.ShowNotification(new GUIContent("场景信息展示开关已关闭"));
			isopennatification = true;
		}
	
		EditorGUILayout.LabelField("场景物体信息开关:", singleItem.Instance.isopenSeneInfo+"");
		
		if (GUILayout.Button("关闭窗口", GUILayout.Width(200)))
		{
			//关闭窗口
			this.Close();
		}

	}

	//更新
	void Update()
	{
		if (isopennatification) {
			Tnum += Time.deltaTime;

		}
	}

	

	void OnInspectorUpdate()
	{
		//Debug.Log("窗口面板的更新");
		//这里开启窗口的重绘，不然窗口信息不会刷新
		this.Repaint();
	}

	void OnSelectionChange()
	{
		//当窗口出去开启状态，并且在Hierarchy视图中选择某游戏对象时调用
		foreach (Transform t in Selection.transforms)
		{
			//有可能是多选，这里开启一个循环打印选中游戏对象的名称
			Debug.Log("OnSelectionChange" + t.name);
		}
	}

	void OnDestroy()
	{
		Debug.Log("当窗口关闭时调用");
	}
}
