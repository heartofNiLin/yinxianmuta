using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 将脚本挂在摄像机观察的物体上  物体必须带有Render
/// </summary>
public class PlayerView : MonoBehaviour
{

    bool isRendering;
    float curtTime = 0f;
    float lastTime = 0f;
    public GameObject Cylinder;
    public Vector3 cypos;
    void OnWillRenderObject()
    {
        curtTime = Time.time;
    }
    public bool IsInView(Vector3 worldPos)
    {
        Transform camTransform = Camera.main.transform;
        Vector2 viewPos = Camera.main.WorldToViewportPoint(worldPos);
        Vector3 dir = (worldPos - camTransform.position).normalized;
        float dot = Vector3.Dot(camTransform.forward, dir);     //判断物体是否在相机前面

        if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
            return true;
        else
            return false;
    }

    void Update()
    {
        Vector2 vec2 = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

        if (IsInView(transform.position))
        {
            Debug.Log("目前本物体在摄像机范围内");
     
        }
        else
        {
            Debug.Log("目前本物体不在摄像机范围内");
           // Cylinder.SetActive(false);
            Cylinder.transform.position = cypos;
            print("111111");
        }
    }
}

