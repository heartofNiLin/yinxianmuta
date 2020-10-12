using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guoMove : MonoBehaviour {
    //bool beginMove = false;
    public Transform[] po;
    int index;
    int index1=0;
    private bool status=true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (status)
        {
            if (transform.localPosition != po[index].position)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, po[index].position, 0.2f);
                if (index == 2)
                {
                    if (index1 < 28)
                    {
                        transform.eulerAngles += new Vector3(0.45f, -0.025f, 0.1f);
                        index1++;
                    }

                }
            }
            else
            {
                index++;
            }
            if (index>=3)
            {
                status = false;
            }
        }
        
	}

}
