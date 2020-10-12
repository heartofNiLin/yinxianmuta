using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click: MonoBehaviour
{

	    //private int clicknum;
	    private bool clickstatus = false;
	    public Button mButton;
	    public GameObject image;

	    // Use this for initialization
	    void Start()
	    {
		         
		        //获取按钮一
		        Button btn = mButton.GetComponent<Button>();
		        //给按钮一绑定监听器，点击时执行TaskOnClick方法
		        btn.onClick.AddListener(TaskOnClick);

		    }


	    void TaskOnClick()
	    {
		        clickstatus = !clickstatus;
		        if (clickstatus) {
			            image.SetActive (true);
		        } else {
			            image.SetActive (false);
			        }
		    }

}