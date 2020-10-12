using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour {

    public float moveSpeed = 0.2f;
    public float rotateSpeed = 50f;
    //public GameObject showCanvas;
    private Animator ani;
    private int IdleID = Animator.StringToHash("idle");
    private int WalkID = Animator.StringToHash("changewalk");
    private int HouID = Animator.StringToHash("changehou");
    //private bool idle = true;
    //public GameObject testimage;
    //public GameObject tempimage;
    //private Vector3 po;
    //private Vector3 targetPos;
    ///public GameObject ARcamera;
   public GameObject nextPage;
    void Start()
    {
       // targetPos = transform.position;
        //获取自身的动画控制器
        ani = this.GetComponent<Animator>();
        //AnimatorStateInfo 动画层状态信息类
        //GetCurrentAnimatorStateInfo 获取动画控制器中指定层的状态信息
       

    }
    void Update() {
        
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        //获取当前动画状态的哈希值
        int tempNumber = info.shortNameHash;
        //判断当前状态是否为摇头
        if((info.normalizedTime >= 1.0f)&&(info.IsName("youtou")))
       // if (Animator.StringToHash("houjiao").Equals(tempNumber))
        {
            ani.SetBool(HouID, true);
            GameObject.Find("Roar").GetComponent<AudioSource>().Play();
        }
        if ((info.normalizedTime >= 1.0f) && (info.IsName("houjiao")))
        {
            ani.SetBool(WalkID, true);
            //testimage.SetActive(true);
            //tempimage.SetActive(false);
         
        }
        if ((info.normalizedTime >= 1.0f) && (info.IsName("walk")))
        {
            nextPage.SetActive(true);
            //testimage.SetActive(true);
            //tempimage.SetActive(false);
        }
        //if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        //{
        //    GameObject.Find("3Dcanvas").SetActive(false);
        //    showCanvas.SetActive(true);
        //    ARcamera.SetActive(false);
        //}
    }


    // Update is called once per frame
    //void Update ()
    //   {
    //       if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
    //       {
    //           if (Input.GetMouseButtonDown(0)) po = Input.mousePosition;
    //           else if (Input.touchCount == 1) po = Input.touches[0].position;

    //           ani.SetBool(IdleID, false);
    //           Ray ray = Camera.main.ScreenPointToRay(po);
    //           RaycastHit hit;
    //           if (Physics.Raycast(ray, out hit, 300.0f))
    //           {
    //               targetPos = hit.point;
    //           }
    //           turnForward2(transform, targetPos);
    //       }
    //       //transform.position = Vector3.Slerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
    //       transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed);
    //       stop(targetPos);
    //   }

    //   void turnForward(Transform origin,Vector3 target)
    //   {
    //       Vector3 t1 = new Vector3(origin.position.x, 0, origin.position.y);
    //       Vector3 t2 = new Vector3(target.x, 0, target.y);

    //       Vector3 dir = t2 - t1;
    //       Quaternion rotate = Quaternion.FromToRotation(origin.forward, dir);
    //       float angle = rotate.eulerAngles.y;
    //       origin.rotation *= rotate;
    //   }

    //   void turnForward2(Transform origin,Vector3 target)
    //   {
    //       Vector3 dir = target - origin.position;

    //       //Quaternion rotate = Quaternion.LookRotation(dir);
    //       Quaternion rotate = Quaternion.FromToRotation(origin.forward , dir);
    //       float angle = rotate.eulerAngles.y;
    //       //origin.rotation = Quaternion.Slerp(origin.rotation, rotate, Time.deltaTime * rotateSpeed);
    //       origin.Rotate(Vector3.up * rotateSpeed, angle);
    //   }

    //   void stop(Vector3 target)
    //   {
    //       float dis = Vector3.Distance(transform.position, target);
    //       if(dis < 0.5f)
    //       {
    //           //idle = true;
    //           ani.SetBool(IdleID, true);
    //       }
    //   }
}
