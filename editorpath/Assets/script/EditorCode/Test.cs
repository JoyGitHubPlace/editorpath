using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	[HideInInspector] [SerializeField] private Rect pRectValue;
	public Rect mRectValue
    {
		get {
			return pRectValue;
        }
		set {
			pRectValue = value;
		}
	}
	[HideInInspector] [SerializeField] private Texture pTex;
	public Texture tex
	{
		get
		{
			return pTex;
		}
		set
		{
			pTex = value;
		}
	}
}
