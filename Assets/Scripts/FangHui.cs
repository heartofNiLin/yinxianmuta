﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FangHui : MonoBehaviour {

    public GameObject target;   //要到达的目标
    public float speed = 10;    //速度
    private float distanceToTarget;   //两者之间的距离
    private bool move = true;
    public Vector3 targert=new Vector3(-7.08f, 29.57f, -45.8f);
    // Use this for initialization
    void Start () {
        //计算两者之间的距离
        distanceToTarget = Vector3.Distance(this.transform.localPosition, targert);
        StartCoroutine(StartShoot());

    }

    IEnumerator StartShoot()
    {

        while (move)
        {
            Vector3 targetPos = target.transform.position;

            //让始终它朝着目标
            this.transform.LookAt(targetPos);

            //计算弧线中的夹角
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 70;
            //this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
            if (currentDist < 0.1f)
            {

                move = false;
                this.transform.localPosition = new Vector3(-7.08f, 29.57f, -45.8f);
                this.transform.localEulerAngles = new Vector3(20.81f, 0.0f, 4.8f);

            }


            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            yield return null;
        }
    }

    

}
