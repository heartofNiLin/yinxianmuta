using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class returnchoose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void returnScan()
    {
        SceneManager.LoadScene(0);
    }
    public void modelshow()
    {
        SceneManager.LoadScene(2);
    }
    public void gifshow()
    {
        SceneManager.LoadScene(2);
    }
    public void modelscreenwideshow()
    {
        SceneManager.LoadScene(25);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void returnscreennormalshow()
    {
        SceneManager.LoadScene(6);
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
