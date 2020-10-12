using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanghuirongqi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void activeFangHui() {
        GameObject.Find("MOVE").GetComponent<guoMove>().enabled = true;

    }
}
