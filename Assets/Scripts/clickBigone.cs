using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickBigone : MonoBehaviour {

    //private int clicknum;
    private bool clickstatus = false;
    public GameObject big;

    // Use this for initialization
    void Start()
    {


    }


    public void TaskOnClick()
    {
        clickstatus = !clickstatus;
        if (clickstatus)
        {
            big.SetActive(true);
        }
        else
        {
            big.SetActive(false);
        }
    }
}
