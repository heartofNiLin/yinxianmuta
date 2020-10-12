using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class returnchoose1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void gifshow()
    {
        SceneManager.LoadScene(2);
    }
    public void modelshow()
    {
        SceneManager.LoadScene(1);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void returnshow()
    {
        SceneManager.LoadScene(0);
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
