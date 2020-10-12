using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class outSee : MonoBehaviour {

    bool pingPong = false
           ;
    float s;
    public float changNum = 0.16f;
    // Use this for initialization
    void Start()
    {
        //s = GetComponent<Glow11>().settings.radius;
        //s = GetComponent<>().settings.outerStrength;
        s = GetComponent<OutlineEffect>().lineThickness;
    }

    // Update is called once per frame
    void Update()
    {
        //s += 0.005f;
        //if (s >= 2)
        //    s = 1.3f;
        if (pingPong)
        {
            s += changNum;
            if (s >= 5.8f)
                pingPong = false;
        }
        else
        {
            s -= changNum;
            if (s <= 1.0f)
                pingPong = true;
        }
        //GetComponent<Glow11>().settings.radius = (int)s;
         GetComponent<OutlineEffect>().lineThickness=s;
    }
}

