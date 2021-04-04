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
}
