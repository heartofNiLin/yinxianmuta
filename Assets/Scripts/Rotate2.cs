using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( 1 == Input.touchCount ){
			Touch touch = Input.GetTouch (0);
			Vector2 deltaPos = touch.deltaPosition;			
		
			transform.Rotate(Vector3.right * deltaPos.y , Space.Self);
		}	
	}
}
