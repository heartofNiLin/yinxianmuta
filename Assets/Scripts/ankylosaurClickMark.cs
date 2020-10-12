using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ankylosaurClickMark : MonoBehaviour {

    //private int clicknum;
    private bool clickstatus = false ;
    public GameObject big;

    private Vector3 startposition = new Vector3(13, -51, -796);
    private Quaternion startrotation = Quaternion.Euler(new Vector3(0.0f, 0.0f,0.0f));
    private Vector3 startscale = new Vector3(0.45f, 0.45f, 0.45f);

    private Vector3 startpositionTwo = new Vector3(0.0f, 0.0f, 0.0f);
    private Quaternion startrotationTwo = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
    private Vector3 startscaleTwo = new Vector3(1.0f, 1.0f, 1.0f);
    public GameObject jialongONE;
    public GameObject jialongTWO;

    public void TaskOnClick()
    {
        clickstatus = !clickstatus;
        if (clickstatus)
        {
            jialongONE.transform.localPosition = startposition;
            jialongONE.transform.localScale = startscale;
            // jialong.transform.localEulerAngles = startrotation;
            //jialong.transform.localRotation = startrotation;
            jialongONE.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            jialongTWO.transform.localPosition = startpositionTwo;
            jialongTWO.transform.localScale = startscaleTwo;
            // jialong.transform.localEulerAngles = startrotation;
            //jialong.transform.localRotation = startrotation;
            jialongTWO.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            big.SetActive(true);
            GameObject.Find("bone").GetComponent<Rotate2>().enabled = false;
            GameObject.Find("bone2").GetComponent<Rotate1>().enabled = false;
            GameObject.Find("bone").GetComponent<Enlarge>().enabled = false;
        }
        else
        {
            big.SetActive(false);
            GameObject.Find("bone").GetComponent<Rotate2>().enabled = true;
            GameObject.Find("bone2").GetComponent<Rotate1>().enabled = true;
            GameObject.Find("bone").GetComponent<Enlarge>().enabled = true;
        }
    }
}
