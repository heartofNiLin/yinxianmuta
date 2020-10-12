using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleclick : MonoBehaviour {

    public int clickedCount = 2;
    public float clickedInterval = 0.5f;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;

    private float lastClickedTime = 0;
    private float count = 0;

    public void OnClicked()
    {
        float interval = Time.realtimeSinceStartup - lastClickedTime;
        if (interval <= clickedInterval)
        {
            count++;
            if (count == clickedCount - 1)
            {

                //TODO：
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
            }
        }
        else
        {
            count = 0;
        }
        lastClickedTime = Time.realtimeSinceStartup;
    }
}
