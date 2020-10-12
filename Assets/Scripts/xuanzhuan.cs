using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xuanzhuan : MonoBehaviour {

    public Transform center;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(center.localPosition, Vector3.up, 15 * Time.deltaTime);
    }
}
