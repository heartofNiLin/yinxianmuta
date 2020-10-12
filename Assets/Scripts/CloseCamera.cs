using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCamera : MonoBehaviour {
    public GameObject CloseCa;
    private Vector3 startposition = new Vector3(-9.2f, 34.34f, -67);
   
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void CloseCame() {
        CloseCa.GetComponent<xuanzhuan>().enabled = false;
        CloseCa.transform.localPosition = startposition;
        CloseCa.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);



    }
}
