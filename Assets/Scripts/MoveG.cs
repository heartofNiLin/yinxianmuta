using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveG : MonoBehaviour {
    public GameObject jiubutton;
    public float speed = 8;
    private Vector3 sourceposition;
    private Vector3 targetposition = new Vector3(-3.8f, 29f, -40.7f);
    private int num=1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, targetposition, speed * Time.deltaTime);
        
        if (gameObject.transform.localPosition == targetposition)
        {
            if (num==1) {
                jiubutton.SetActive(true);
            }
            num++; 
        }
       

	}
}
