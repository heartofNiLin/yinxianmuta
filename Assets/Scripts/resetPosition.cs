using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPosition : MonoBehaviour {

    private Vector3 sourceposition;
    private Vector3 sourceroation;
    private Vector3 sourcescale;
	void Start () {
        sourceposition = this.transform.localPosition;
        
       // sourceroation = this.transform.rotation;
        sourcescale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void resetall() { 
      this.transform.localScale=sourcescale;
      this.transform.localPosition=sourceposition;
	
    }
}
