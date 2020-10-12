using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterClick : MonoBehaviour {

    //private int clicknum;
    private bool clickstatus = false;
    //public Button mButton;
    public GameObject image;
    public GameObject jiuplane;
    public GameObject jiuplane2;
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
            jiuplane2.SetActive(true);
            GameObject.Find("Audio Source_kaishui").GetComponent<AudioSource>().Play();
        }
        else
        {
            image.SetActive(false);
            jiuplane.transform.localPosition = jiuplaneposition;
            jiuplane.SetActive(false);
            jiuplane2.SetActive(false);
            GameObject.Find("Audio Source_kaishui").GetComponent<AudioSource>().Pause();
        }
    }

}
