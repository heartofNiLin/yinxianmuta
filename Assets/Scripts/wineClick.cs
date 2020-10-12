using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wineClick : MonoBehaviour {
    //private int clicknum;
    private bool clickstatus = false;
    //public Button mButton;
    public GameObject image;
    public GameObject jiuplane;
   
    private Vector3 jiuplaneposition;
    // Use this for initialization
    void Start()
    {
        jiuplaneposition = jiuplane.transform.localPosition;

    }


    public void TaskOnClick()
    {
       
        clickstatus = !clickstatus;
        if (clickstatus)
        {
            image.SetActive(true);
            jiuplane.SetActive(true);
          
            GameObject.Find("Audio Source_jiu").GetComponent<AudioSource>().Play();
        }
        else
        {
            image.SetActive(false);
            jiuplane.transform.localPosition = jiuplaneposition;
            jiuplane.SetActive(false);
            GameObject.Find("Audio Source_jiu").GetComponent<AudioSource>().Pause();
        }
    }

}
