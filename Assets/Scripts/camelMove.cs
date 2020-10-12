using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camelMove : MonoBehaviour {
    public GameObject showCanvas;
    private Animator ani;

    // Use this for initialization
    void Start () {
        ani = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        //获取当前动画状态的哈希值


        //if ((info.normalizedTime >= 1.0f) && (info.IsName("walk")))
        //{
        //    GameObject.Find("AnimatorCanvas").SetActive(false);
        //    showCanvas.SetActive(true);

        //}
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            GameObject.Find("AnimatorCanvas").SetActive(false);
            showCanvas.SetActive(true);
        }
    }
}
