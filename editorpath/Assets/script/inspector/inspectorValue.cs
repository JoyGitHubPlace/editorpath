using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inspectorValue : MonoBehaviour {

	public int width
	{
		get
		{
			return _width;
		}
		set
		{
			_width = value;
		}
	}
	[SerializeField]
	private int _width;


	//测试设置数值约束
	public int LuckyPoint;
	public int ATK;
}
