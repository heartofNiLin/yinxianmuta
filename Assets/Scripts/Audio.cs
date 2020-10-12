using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

	public AudioSource audio;
	public Button mButton;

	// Use this for initialization
	void Start () {
		//获取按钮一
		Button btn = mButton.GetComponent<Button> ();
		//给按钮一绑定监听器，点击时执行TaskOnClick方法
		btn.onClick.AddListener (TaskOnClick);

	}


	void TaskOnClick(){

		if(!audio.isPlaying)
		{
			audio.Play();
		}else if(audio.isPlaying)
		{
			audio.Pause();
		}

	}

}