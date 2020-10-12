using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickBig : MonoBehaviour {

    //private int clicknum;
   
    public GameObject cameraAR;
    public GameObject camera1;
    //public GameObject camerabig;
    public GameObject canvas1;
    public GameObject canvas2;
    // Use this for initialization
    void Start()
    {


    }
    public void ShowOnClick()
    {
        camera1.SetActive(true);
        cameraAR.SetActive(false);
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void CloseShowOnClick()
    {
        canvas1.SetActive(true);
        cameraAR.SetActive(true);
        camera1.SetActive(false);
        canvas2.SetActive(false);
        
    }
}
