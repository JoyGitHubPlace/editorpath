
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using UnityEditor.SceneManagement;

public class getPrefabpath : Editor {
    [MenuItem("myEditor/getPrefabPath")]
    static void getPrefabPathFunction()
    {
        //确保鼠标右键选择的是一个Prefab
        if (Selection.gameObjects.Length != 1)
        {
            return;
        }
        //遍历所有游戏场景
        LoopUIScene((uiRoot, uiName) =>
        {
            //获取场景中的所有游戏对象,包括隐藏的
            var childs = uiRoot.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in childs)
            {
                //判断GameObject的type是否是Prefab的引用
                if (PrefabUtility.GetPrefabType(child) == PrefabType.PrefabInstance)
                {
                    //transform是在Hierarchy视图的，转成project的prefab
                    UnityEngine.Object parentObject = PrefabUtility.GetPrefabParent(child);
                    string path = AssetDatabase.GetAssetPath(parentObject);
                    //判断GameObject的Prefab是否和右键选择的Prefab是同一路径。
                    if (path == AssetDatabase.GetAssetPath(Selection.activeGameObject))
                    {
                        //输出场景名，以及Prefab引用的路径
                        Debug.Log("场景名: " + uiName + "  引用路径: " + GetGameObjectPath(child.gameObject));
                    }
                }
            }
        });
    }

    public static void LoopUIScene(Action<Transform, string> uiWindow)
    {
        //当前这个工程的全部UI场景放在Assets/UI/TestScene下
        foreach (var uiScene in Directory.GetFiles("Assets/scenes/getPrefab", "*.unity"))
        {
            EditorSceneManager.OpenScene(uiScene);

            //这个节点的设置就很有自主管理可控的感觉，所以建议根节点放在一个空对象上面处理
            var uiRoot = GameObject.Find("rootNode").transform;   
            uiWindow(uiRoot, uiScene);
        }
    }
    public static string GetGameObjectPath(GameObject obj)
    {
        string path = "/" + obj.name;
        //一直往上找
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name + path;
        }
        return path;
    }

}
