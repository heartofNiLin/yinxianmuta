
using UnityEngine;
using System.Collections;
using Vuforia;
public class CreatEmpty : MonoBehaviour {
	Vector3 emptyposition = new Vector3 (0, 0, 2);
	public void creatempty()
	{
		//定义一个空物体，并将他作为Camera的子物体，并设置其坐标和旋转角度
		GameObject emptyObject = new GameObject ();
		emptyObject.transform.parent = GameObject.FindWithTag ("MainCamera").transform;
		emptyObject.name = "empty";
		emptyObject.transform.localPosition = emptyposition;
		emptyObject.transform.localRotation = Quaternion.Euler (Vector3.zero);
	}
	//杀死camera组件中名字为“empty”的物体
	public void destoryempty()
	{
		if (GameObject.Find ("empty"))
			GameObject.Destroy (GameObject.Find ("empty"));
		else
			print ("没有empty！");     
	}
}