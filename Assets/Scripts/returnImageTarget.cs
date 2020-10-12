using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;
public class returnImageTarget : MonoBehaviour {
    GameObject[] obj; //开头定义GameObject数组
     
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void returnscan() {
        obj = GameObject.FindGameObjectsWithTag("scanImage") as GameObject[]; //关键代码，获取所有gameobject元素给数组obj
                                                                              //obj = FindObjectsOfType(typeof(ImageTargetBehaviour)) as GameObject[]; //关键代码，获取所有gameobject元素给数组obj
        foreach (GameObject child in obj)    //遍历所有gameobject
        {
            Debug.Log(child.gameObject.name + "222222222222");  //可以在unity控制台测试一下是否成功获取所有元素


            child.gameObject.GetComponent<ImageTargetBehaviour>().enabled = true;

            //if (child.gameObject.tag == "enemy")    //进行操作
            //{
            //    child.gameObject.SetActive(false);
            //    Destroy(child.gameObject);
            //}
        }

    }
}
