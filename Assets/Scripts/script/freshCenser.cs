using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class freshCenser : MonoBehaviour {
	public Button mBtn;
	//public string obj;
	// Use this for initialization
	void Start () {
		Button btn = mBtn.GetComponent<Button> ();
	    btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick(){
		//GameObject.Find (obj).GetComponent <NotFound> ().freshCenser ();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
