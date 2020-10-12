using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelClick : MonoBehaviour {
    public GameObject clickmodel;
    public GameObject showthing;
    public GameObject bonebar;
    public GameObject dragonbar;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {

            showthing.SetActive(true);
            clickmodel.SetActive(false);

            dragonbar.SetActive(true);
            bonebar.SetActive(false);
        }
    }
}
