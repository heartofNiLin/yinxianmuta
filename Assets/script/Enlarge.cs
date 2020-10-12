﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour {

	Vector2 oldPos1;
	Vector2 oldPos2;

	public float maxScale = 0.1f;
	public float minScale = 0.008f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 2)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
			{
				Vector2 timePos1 = Input.GetTouch(0).position;
				Vector2 timePos2 = Input.GetTouch(1).position;
				if (isEnlarge(oldPos1, oldPos2, timePos1, timePos2))
				{
					float oldScale = transform.localScale.x;
					float newScale = oldScale * 1.025f;
					if (newScale <=maxScale)
					{
						transform.localScale = new Vector3(newScale, newScale, newScale);
					}
				}
				else
				{
					float oldScale = transform.localScale.x;
					float newScale = oldScale / 1.025f;
					if (newScale>=minScale)
					{
						transform.localScale = new Vector3(newScale, newScale, newScale);
					}  
				}

				oldPos1 = timePos1;
				oldPos2 = timePos2;
			}
		}
	}

	//判断手势
	bool isEnlarge(Vector2 oP1,Vector2 oP2,Vector2 nP1,Vector2 nP2)
	{
		float length1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
		float length2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
		if (length1 < length2)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}