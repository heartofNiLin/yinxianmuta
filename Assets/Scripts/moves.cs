using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moves : MonoBehaviour
{

    public GameObject xiang1;
    public GameObject text1;
    public GameObject xiang2;
    public GameObject text2;
    public GameObject xiang3;
    public GameObject text3; 
    

    private float a;
    private float b;
    private float c;
    private float d;
    private float e;
    private float f;

    void Start()
    {
        a = 0;
        b = 0;
        c = 0;
        d = 0;
        e = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (a < 112.4f)
        {
            xiang1.transform.localPosition += new Vector3(-3, -10, 0);
            a++;
        }
        else
        {
            if (b < 22.5f)
            {
                text1.transform.localPosition += new Vector3(-10, 0, 0);
                b++;
            }
            else
            {
                if (c<112.4)
                {
                    xiang2.transform.localPosition += new Vector3(-3, -10, 0);
                    c++;
                }
                else
                {
                    if (d<22.5f)
                    {
                        //text1.SetActive(false);
                        text1.transform.localPosition += new Vector3(10, 0, 0);
                        text2.transform.localPosition += new Vector3(-10, 0, 0);
                        d++;
                    }
                    else
                    {
                        if(e < 112.4)
                        {
                            xiang3.transform.localPosition += new Vector3(-3, -10, 0);
                            e++;
                        }
                        else

                        {
                            if (f < 22.5)
                            {
                                text2.transform.localPosition += new Vector3(10, 0, 0);
                                text3.transform.localPosition += new Vector3(-10, 0, 0);
                                f++;
                            }
                          
                        }
                    }
                }
            }

        }
    }
}

