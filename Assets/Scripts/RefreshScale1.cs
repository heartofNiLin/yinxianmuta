using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshScale1 : MonoBehaviour {
    public Vector3 old = new Vector3(1f,1f,1f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void oldScale() {
        transform.transform.localScale = old;

    }

}
