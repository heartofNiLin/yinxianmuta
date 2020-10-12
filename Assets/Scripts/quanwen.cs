using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quanwen : MonoBehaviour {
    private string show = "\n品，也是目前国内已发现的此类器物中\n最精美的一件。口径10.3厘米，腹径\n11.4厘米，高7.5厘米。\n                        \n                 \n";//要显示剩余文字
    public GameObject textone;//填写文字文本框
    public Vector3 textonepos;//填写文字文本框的位置
    public Button quan;//全文按钮  对应项目中的按钮
    private string article;
   
    public GameObject imagequanwen;//image2  文本框背景区域
    public Vector3 imagepos; //image2 文本框背景区域位置
    public Vector2 changeVectors;//image2 文本框要改变的宽度和高度
    //public GameObject liuyan; //留言的对象  image3
    //public Vector3 liuyanpos;//留言的对象位置

    //public GameObject notes;//大同博物馆的对象  image5
    //public Vector3 notesnpos;//大同博物馆的对象位置image5

    private Vector3 textonesourcepos;
    private Vector3 imageposourcepos;
    //private Vector3 liuyansourcepos;
    //private Vector3 notessourcepos;
    private Vector2  sourceheight;
    // Use this for initialization
    void Start () {
        quan.onClick.AddListener(showWen);
        article = textone.GetComponent<Text>().text;
        textonesourcepos = textone.GetComponent<RectTransform>().anchoredPosition3D ;
        imageposourcepos = imagequanwen.GetComponent<RectTransform>().anchoredPosition3D;
        //liuyansourcepos = liuyan.GetComponent<RectTransform>().anchoredPosition3D;
        //notessourcepos = notes.GetComponent<RectTransform>().anchoredPosition3D;
        sourceheight = imagequanwen.GetComponent<RectTransform>().sizeDelta;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public  void showWen()//点击全文
    {

        textone.GetComponent<Text>().text = article + show;//点击全文需要追加的文字  注意\n  必须有

        textone.GetComponent<RectTransform>().anchoredPosition3D = textonepos;
        imagequanwen.GetComponent<RectTransform>().sizeDelta = changeVectors;
        //var rt = imagequanwen.GetComponent<RectTransform>();
        //rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
       // rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 665);//获取高度
        imagequanwen.GetComponent<RectTransform>().anchoredPosition3D = imagepos;
        //liuyan.GetComponent<RectTransform>().anchoredPosition3D = liuyanpos;
        //notes.GetComponent<RectTransform>().anchoredPosition3D = notesnpos;


    }
    public void closeWen()//点击收起
    {

        textone.GetComponent<Text>().text = article;
        textone.GetComponent<RectTransform>().anchoredPosition3D = textonesourcepos; //未运行时候的文字文本框位置
        imagequanwen.GetComponent<RectTransform>().sizeDelta = sourceheight;
        imagequanwen.GetComponent<RectTransform>().anchoredPosition3D = imageposourcepos;//未运行时候的文字文本框位置
        //liuyan.GetComponent<RectTransform>().anchoredPosition3D = liuyansourcepos;//未运行时候的留言区域的位置
        //notes.GetComponent<RectTransform>().anchoredPosition3D = notessourcepos;//未运行时候的通告区域的位置

    }
}
