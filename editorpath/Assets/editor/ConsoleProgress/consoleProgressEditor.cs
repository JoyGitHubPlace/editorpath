using System.Reflection;  //必须引用的库
using UnityEditor;

public class consoleProgressEditor : Editor {

	[MenuItem("myEditor/clearConsole")]
	static void clearConsole() {
		var assembly = Assembly.GetAssembly(typeof(UnityEditor.ActiveEditorTracker));  //已经封装好的库可以全局映射索引到对应类，获取对应方法名然后invoke执行
		var type = assembly.GetType("UnityEditorInternal.LogEntries");
		var method = type.GetMethod("Clear");
		method.Invoke(new object(), null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
