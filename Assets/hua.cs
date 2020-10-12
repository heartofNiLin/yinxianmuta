using UnityEngine;
using System.Collections;

public class hua : MonoBehaviour {
	public GameObject h;
	public GameObject texiao;
	GameObject pre;
	Transform ht;
	// Use this for initialization
	void Awake () {
		h.transform.parent = texiao.transform;
		h.SetActive (false);
		//pre = GameObject.Find ("Prefab(Clone)");
	}
	
	// Update is called once per frame
	void Update () {
		//ht = pre.transform.FindChild ("Effects");
		//h = this.gameObject;
		Invoke ("showHua",3f);
	}

	void showHua()
	{
		h.SetActive (true);
	}
}
