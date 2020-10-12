using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glow11;

namespace Glow11
{
    public class shan : MonoBehaviour
    {
        bool pingPong = false
            ;
        float s;
        // Use this for initialization
        void Start()
        {
            //s = GetComponent<Glow11>().settings.radius;
            s = GetComponent<Glow11>().settings.outerStrength;
        }

        // Update is called once per frame
        void Update()
        {
            //s += 0.005f;
            //if (s >= 2)
            //    s = 1.3f;
            if (pingPong)
            {
                s += 0.02f;
                if (s >= 2)
                    pingPong = false;
            }
            else
            {
                s -= 0.02f;
                if (s <= 1.3f)
                    pingPong = true;
            }
            //GetComponent<Glow11>().settings.radius = (int)s;
            GetComponent<Glow11>().settings.outerStrength = s;
        }
    }
}
