using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teststart3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("start3");////测试：不同物体的同一层级对应的start是乱序的
		Debug.Log(singleItem.Instance.globalNum);
		singleItem.Instance.globalNum = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
