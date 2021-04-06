using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class rightProgress : EditorWindow {

    [MenuItem("Game/Open Window")]
    static void Init()
    {
        var window = (rightProgress)EditorWindow.GetWindow(typeof(rightProgress), true, "sceneObjectInfo");
        window.Show();
    }

    void Callback(Object obj)
    {
        Debug.Log("Selected: " + obj);
    }

    void OnGUI()
    {
       Event Event = Event.current;
        Rect contextRect = new Rect(10, 10, 100, 100);

        if (Event.type == EventType.ContextClick)
        {
            Vector2 mousePos = Event.mousePosition;
            if (contextRect.Contains(mousePos))
            {
            }
        }
    }
}
