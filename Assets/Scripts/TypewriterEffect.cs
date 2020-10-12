﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour {

    public GameObject textkuang;
	public float charsPerSecond = 0.1f;//打字时间间隔
	private string words;//保存需要显示的文字

	private bool isActive = false;
	private float timer;//计时器
	private Text myText;
	private int currentPos=0;//当前打字位置

	// Use this for initialization
	void Start () {
		timer = 0;
		isActive = true;
		charsPerSecond = Mathf.Min (0.2f,charsPerSecond);
		myText = GetComponent<Text> ();
		words = myText.text;
		myText.text = "";//获取Text的文本信息，保存到words中，然后动态更新文本显示内容，实现打字机的效果
	}

	// Update is called once per frame
	void Update () {
		OnStartWriter ();
		//Debug.Log (isActive);
	}

	public void StartEffect(){
		isActive = true;
	}
	/// <summary>
	/// 执行打字任务
	/// </summary>
	void OnStartWriter(){

		if(isActive){
			timer += Time.deltaTime;
			if(timer>=charsPerSecond){//判断计时器时间是否到达
				timer = 0;
				currentPos++;
				myText.text =words.Substring (0,currentPos);
				//myText.text = "<color=#fff100><size=52>"+words.Substring (0,currentPos)+"</size></color>";//刷新文本显示内容
				// myText.text= "<color=#fff100><size=52>"+myText.text+"</size></color>";
				if(currentPos>=words.Length) {
					OnFinish();
                    textkuang.SetActive(true);

                }
			}

		}
	}
	/// <summary>
	/// 结束打字，初始化数据
	/// </summary>
	void OnFinish(){
		isActive = false;
		timer = 0;
		currentPos = 0;
		myText.text = words;
	}
}
