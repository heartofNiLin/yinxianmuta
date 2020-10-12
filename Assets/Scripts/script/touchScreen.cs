using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchScreen : MonoBehaviour {

	public GameObject img;
	public GameObject bg;
 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) || Input.touchCount > 0 && img.activeSelf == true) 
		{
			img.SetActive (false);
			bg.SetActive (true);
          
		}
	}
}
