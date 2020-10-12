using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWine : MonoBehaviour {

    public float speed = 2;
    public Vector3 circlePlanePosition;
    private Vector3 sourceposition;
    public GameObject wine;
    public GameObject shuibutton;
    private int num;


    void Update()
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, circlePlanePosition, speed * Time.deltaTime);
        sourceposition = gameObject.transform.localPosition;
        if (sourceposition == circlePlanePosition)
        {
            
            wine.SetActive(false);
            if (num == 1)
            {
                shuibutton.SetActive(true);
            }
            num++;
           
        }
       
    }
}
