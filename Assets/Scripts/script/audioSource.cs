using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioSource : MonoBehaviour {
	public AudioSource Audio;
	public Button musicBtn;

//	public GameObject img;
//	public GameObject bg;
//
	// Use this for initialization
	void Start () {
		Button btn = musicBtn.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void Update()
	{
		
			
	}

	void TaskOnClick(){
		if (!Audio.isPlaying) {
			Audio.Play();
		}else if(Audio.isPlaying){

			Audio.Pause ();
		}
	}
	// Update is called once per frame

}
