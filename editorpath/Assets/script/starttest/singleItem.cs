using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Common.Base;

public class singleItem : Singleton<singleItem>
{
    public int globalNum = 0;   //暂时设置全局计数id
	public bool isopenSeneInfo = false;  //设置是否打开场景中对象信息展示
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
