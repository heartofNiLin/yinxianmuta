///NotFound.cs

using UnityEngine;
using System.Collections;
using Vuforia;
using System;
using UnityEngine.SceneManagement;

public class NotFound : MonoBehaviour , ITrackableEventHandler
{

	#region PRIVATE_MEMBER_VARIABLES
	private TrackableBehaviour mTrackableBehaviour;

	public GameObject obj;

	//判断是否是第一次识别是否完成，防止开启程序未放入识别图也在屏幕中央出现模型
	bool firstfound = false;

	//	public Plane  plane;

	public Transform sphere;

	public GameObject successImage;

	public bool imageIsOut = false;//识别成功的图片是否已经出现过

	//模型起始位置，值为起始模型组件中Transform.Position
	//Vector3 origposition = new Vector3 (0, 0.25f, 0);
	public Vector3 originPosition;

	//当前imagetarget对应的模型等target
	public Transform[] localTargets;

	//其他非当前imagetarget对应的模型等targets
	public Transform[] otherTargets;


	//Camera Object
	GameObject gObject;
	//Camera Object的Creat Empty脚本
	CreatEmpty cempty;

	//表示ImageTarget父物体那个组件
	public GameObject[] otherImageTargets;



	#region 自定义的协程延时函数
	//定义一个延时函数
	public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)

	{

		yield return new WaitForSeconds(delaySeconds);

		action();

	}
	#endregion //自定义的协程延时函数


	void Start()
	{
		//不显示两张识别成功失败的图片
		successImage.SetActive (false);


		//相机自动对焦
		Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);  


		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

		//获取Camera中组件的CreatEmpty脚本
		gObject = GameObject.FindWithTag("MainCamera");
		cempty = gObject.GetComponent<CreatEmpty> ();
		if(cempty != null)
		{
			//杀死空物体
			cempty.destoryempty ();
		}
	}

	void Update()
	{
		//退出当前程序
		if(Input.GetKeyDown(KeyCode.Escape)) 
		{
			//Application.Quit(); 
			//Application.LoadLevel("PreschoolEducation-0-MenuScreen");
			//			SceneManager.LoadScene ("AR_tuoka");

			homing ();

			for(int i = 0; i < otherTargets.Length; i++)
			{
				//但是隐藏其他imagetarget对应的模型，目的是防止在该imagetarget对应的模型出现在屏幕中央的时候不受其他imagetarget对应的模型的影响
				//otherTargets[i].gameObject.SetActive (false);
				setShow (otherTargets [i], false);
			}

			for(int i = 0; i < localTargets.Length; i++)
			{
				//localTargets[i].gameObject.SetActive (false);
				setShow (localTargets [i], false);
			}


		}

	}

	public void freshCenser(){

		//Application.Quit(); 
		//Application.LoadLevel("PreschoolEducation-0-MenuScreen");
		//			SceneManager.LoadScene ("AR_tuoka");

		homing ();
		//识别图丢失后隐藏菜单栏
		obj.SetActive(false);

		for(int i = 0; i < otherTargets.Length; i++)
		{
			//但是隐藏其他imagetarget对应的模型，目的是防止在该imagetarget对应的模型出现在屏幕中央的时候不受其他imagetarget对应的模型的影响
			//otherTargets[i].gameObject.SetActive (false);
			setShow (otherTargets [i], false);
		}

		for(int i = 0; i < localTargets.Length; i++)
		{
			//localTargets[i].gameObject.SetActive (false);
			setShow (localTargets [i], false);
		}

		firstfound = false;
		imageIsOut = false;


	}


	#endregion // UNTIY_MONOBEHAVIOUR_METHODS


	#region PUBLIC_METHODS

	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		//Vector3 orirotation = new Vector3 (270, 0, 0);

		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{

			//如果识别成功图片没有出现过，则执行下面的代码，显示并延时0.5秒后消失
			if(!imageIsOut)
			{
				successImage.SetActive (true);


				for(int i = 0; i < otherTargets.Length; i++)
				{
					//但是隐藏其他imagetarget对应的模型，目的是防止在该imagetarget对应的模型出现在屏幕中央的时候不受其他imagetarget对应的模型的影响
					//otherTargets[i].gameObject.SetActive (false);
					setShow (otherTargets [i], false);

				}

				for(int i = 0; i < localTargets.Length; i++)
				{
					//localTargets[i].gameObject.SetActive (false);
					setShow (localTargets [i], false);
				}


				//需要延时0.3s，让图片多显示0.3s后消失(执行outImage函数)
				//Invoke ("outImage", 0.5f);//如果这样，并不影响下面代码的执行。

				StartCoroutine(DelayToInvokeDo(() =>

					{
						outImage(newStatus);

						//识别成功图片已经显示过了
						imageIsOut = true;

					}, 0.4f));

			}
			else
			{
				OnTrackingFound ();


			}


		}
		else
		{   

			OnTrackingLost ();
		}
	}

	//sphere上升控制
	IEnumerator MoveUp() 
	{
		sphere.transform.localPosition = new Vector3(0,-1,0);
		//Vector3 n = new Vector3 (0,0,0);
		while(sphere.transform.localPosition!= originPosition)
		{
			yield return new WaitForEndOfFrame();
			sphere.transform.localPosition = Vector3.MoveTowards(sphere.transform.localPosition,originPosition,1f*Time.deltaTime);
		}
	}





	#endregion // PUBLIC_METHODS

	//识别成功图片显示并消失之后
	private void outImage(TrackableBehaviour.Status newStatus)
	{   
		successImage.SetActive (false);
		for(int i = 0; i < otherTargets.Length; i++)
		{
			//但是隐藏其他imagetarget对应的模型，目的是防止在该imagetarget对应的模型出现在屏幕中央的时候不受其他imagetarget对应的模型的影响
			//otherTargets[i].gameObject.SetActive (false);
			setShow (otherTargets [i], false);
		}

		for(int i = 0; i < localTargets.Length; i++)
		{
			//localTargets[i].gameObject.SetActive (false);
			setShow (localTargets [i], false);
		}

		//显示并消失之后在一次判断图片是否处于追踪状态
		if (newStatus == TrackableBehaviour.Status.TRACKED || 
			newStatus == TrackableBehaviour.Status.DETECTED || 
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound ();
			firstfound = true;

			StopAllCoroutines();//关闭所有协同程序
			StartCoroutine(MoveUp());//开启特定的协同程序
		}
		else
		{
			//OnTrackingLost ();
			for(int i = 0; i < otherTargets.Length; i++)
			{
				//但是隐藏其他imagetarget对应的模型，目的是防止在该imagetarget对应的模型出现在屏幕中央的时候不受其他imagetarget对应的模型的影响
				//otherTargets[i].gameObject.SetActive (false);
				setShow (otherTargets [i], false);
			}

			for(int i = 0; i < localTargets.Length; i++)
			{
				//localTargets[i].gameObject.SetActive (false);
				setShow (localTargets [i], false);
			}

		}

	}



	private void OnTrackingFound()
	{

		obj.SetActive (true);
		Debug.Log ("it is found");
		for(int i = 0; i < otherImageTargets.Length; i++)
		{
			//让其他的识别图在执行一次状态识别成功的代码，使得模型归位到imagetarget子物体
			otherImageTargets[i].GetComponent<NotFound> ().homing ();

			//当前图片识别成功时，关闭其他图片的识别
			//      otherImageTargets[i].SetActive (false);

			//将其他识别图中的识别成功图片设置成未显示过
			otherImageTargets [i].GetComponent<NotFound> ().imageIsOut = false;

		}

		for(int i = 0; i < localTargets.Length; i++)
		{
			//setShow (localTargets [i], true);
			//othertargetmodel.gameObject.SetActive (false);

			localTargets[i].parent = this.transform;
			localTargets[i].localPosition = originPosition;
			localTargets[i].rotation = Quaternion.Euler (Vector3.zero);

			//开启当前图片对应的模型，因为在识别其他图片的时候有可能关闭了这个图片对应的模型
			//localTargets[i].gameObject.SetActive (true);
			setShow (localTargets [i], true);
		}

		//杀死空物体
		cempty.destoryempty ();

		//因为杀死了空物体，所以一旦丢失跟踪，模型就没地方放了，所以就加一个判断，丢失的话就不显示模型
		if(mTrackableBehaviour.CurrentStatus ==TrackableBehaviour.Status.NOT_FOUND)
		{
			for(int i = 0;i < localTargets.Length; i++)
			{
				setShow (localTargets [i], false);
			}
		}

		//target.rotation = Quaternion.Euler(orirotation);
		//firstfound = true;
	}


	private void OnTrackingLost()
	{
		Debug.Log ("it is lost");
		for(int i = 0; i < localTargets.Length; i++)
		{
			//localTargets[i].gameObject.SetActive (false);
			setShow (localTargets [i], false);
		}

		successImage.SetActive (false);
		if (firstfound == true) 
		{
			//创建空物体
			cempty.creatempty ();


			for(int i = 0; i < otherTargets.Length; i++)
			{
				//但是隐藏其他imagetarget对应的模型，目的是防止在该imagetarget对应的模型出现在屏幕中央的时候不受其他imagetarget对应的模型的影响
				//otherTargets[i].gameObject.SetActive (false);
				setShow (otherTargets [i], false);
			}

			GameObject emptyobject = GameObject.Find ("empty");
			Transform cameraPos = emptyobject.transform;

			for(int i = 0; i < localTargets.Length; i++)
			{
				//将target作为cameraPos的子物体，cameraPos就是emptyobject(即空物体)的Transform表现形式
				localTargets[i].parent = cameraPos;

				//原来的代码
				//				localTargets[i].localPosition = originPosition;
				//位置改为0点成功
				localTargets[i].localPosition = Vector3.zero;


				//target.localRotation = Quaternion.Euler (orirotation);
				localTargets[i].localRotation = Quaternion.Euler (Vector3.zero);

				//localTargets[i].gameObject.SetActive (true);
				setShow (localTargets [i], true);

			}

		}
		else
		{

			for(int i = 0; i < otherTargets.Length; i++)
			{
				//但是隐藏其他imagetarget对应的模型，目的是防止在该imagetarget对应的模型出现在屏幕中央的时候不受其他imagetarget对应的模型的影响
				//otherTargets[i].gameObject.SetActive (false);
				setShow (otherTargets [i], false);
			}

			for(int i = 0; i < localTargets.Length; i++)
			{
				print ("local Targets set active false");
				//localTargets[i].gameObject.SetActive (false);
				setShow (localTargets [i], false);
			}

		}


	}



	//方便其他脚本调用的接口函数，使this.中模型归位
	public void homing()
	{
		for(int i = 0; i < localTargets.Length; i++)
		{
			localTargets[i].parent = this.transform;
			localTargets[i].position = originPosition;
			localTargets[i].rotation = Quaternion.Euler (Vector3.zero);

		}

	}




	//自己写的隐藏模型代码,仅模型可用
	void setShow(Transform target,bool IsShow)
	{

		Renderer[] targetrendererComponents = target.GetComponentsInChildren<Renderer>(true);
		Collider[] targetcolliderComponents = target.GetComponentsInChildren<Collider>(true);


		if(IsShow)
		{
			// enable rendering:
			foreach (Renderer component in targetrendererComponents)
			{
				component.enabled = true;
			}

			// enable colliders:
			foreach (Collider component in targetcolliderComponents)
			{
				component.enabled = true;
			}
		}
		else
		{
			// Disable rendering:
			foreach (Renderer component in targetrendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in targetcolliderComponents)
			{
				component.enabled = false;
			}
		}
	}


}

