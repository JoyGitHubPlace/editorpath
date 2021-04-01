using UnityEditor;
using UnityEngine;

//自定义Tset脚本
[CustomEditor(typeof(Test))]
//在编辑模式下执行脚本，这里用处不大可以删除。
[ExecuteInEditMode]
//请继承Editor
public class Myeditor : Editor
{
	//在这里方法中就可以绘制面板。
	public override void OnInspectorGUI()
	{
		//得到Test对象
		Test test = (Test)target;
		//绘制一个窗口
		test.mRectValue = EditorGUILayout.RectField("windowRect",
				test.mRectValue);
		//绘制一个贴图槽
		test.tex = EditorGUILayout.ObjectField("add a texture", test.tex, typeof(Texture), true) as Texture;

	}
}