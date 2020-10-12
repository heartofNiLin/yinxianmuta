using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : MonoBehaviour {
     
    public float speed = 2;
    public Vector3 circlePlanePosition;
    private Vector3 sourceposition;
    public GameObject water;

    public GameObject waterqi;
    public GameObject wineqi;
    public GameObject morebutton;
    public GameObject xizun;
    public Vector3 middleposition;
  
	void Update () {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, circlePlanePosition, speed * Time.deltaTime);
        sourceposition = gameObject.transform.localPosition;
        if (sourceposition == circlePlanePosition)
        {
            wineqi.SetActive(true);
            water.SetActive(false);
            morebutton.SetActive(true);
            GameObject.Find("GameObject").GetComponent<rotate>().enabled = true;
        }
        if (sourceposition.y >= middleposition.y)
        {
            
            waterqi.SetActive(true);
        }
    }
}
