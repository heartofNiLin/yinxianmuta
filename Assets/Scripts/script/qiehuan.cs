using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qiehuan : MonoBehaviour {
    public GameObject obj;
    public GameObject ing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) { 
        
            obj.SetActive(false);
            ing.SetActive(true);
        }
	}
}
