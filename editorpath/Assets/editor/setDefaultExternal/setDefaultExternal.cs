using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;   //需要引用这个库处理OnOpenAssetAttribute

public class setDefaultExternal  {

    [OnOpenAssetAttribute(1)]
    public static bool fun1(int instanceID, int line)
    {
        return false; 
    }
    //设置自己习惯的编辑器很重要，可以提高效率
    private static void openSystemProcess(string name, string path) {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = path;
        startInfo.Arguments = name;
        process.StartInfo = startInfo;
        process.Start();
    }
    // callback has an attribute with fun1, so will be called after fun1
    [OnOpenAssetAttribute(2)]
    public static bool callback(int instanceID, int line)
    {

        string path = AssetDatabase.GetAssetPath(EditorUtility.InstanceIDToObject(instanceID));
        string name = Application.dataPath + "/" + path.Replace("Assets/", "");

        if (name.EndsWith(".lua"))
        {
            openSystemProcess(name,"E:/Sublime Text 3/sublime_text.exe");
            return true;
        }else if (name.EndsWith(".txt"))
        {
            openSystemProcess(name, "E:/Notepad++/notepad++.exe");
            return true;
        }else if (name.EndsWith(".json"))
        {
            openSystemProcess(name, "E:/vscode/Code.exe");  
            return true;
        }
return false; 
    }
}
