using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class firstLine1 : MonoBehaviour {
   
    private string filepath;
	//void Start () {
 //       //sourceText = waitingText.text;
 //       ///string filepath = "file://" + Application.streamingAssetsPath + "/" + "jialongone.txt";
 //       //Debug.Log(filepath);
 //       if (Application.platform == RuntimePlatform.IPhonePlayer)
 //       {
 //           filepath = Application.dataPath + "/Raw/" + filename + ".txt";

 //       }
 //       else if (Application.platform == RuntimePlatform.Android)
 //       {
 //           filepath = "jar:file://" + Application.dataPath + "!/assets/" + filename + ".txt";
 //           //StartCoroutine("LoadWWW");
 //       }
 //       else
 //       {
 //           filepath = Application.dataPath + "/StreamingAssets/" + filename + ".txt";
 //       }
 //      StartCoroutine(DownLoadTxT(filepath));

 //   }

 //   IEnumerator DownLoadTxT(string path)
 //   {
 //       WWW www = new WWW(path);
 //       yield return www;
 //       if (www.isDone)
 //       {
 //           waitingText.text = www.text;

 //       }

 //   }

    void Update () {
        // waitingText.text = "简介：\n" +
        //"\u3000\u3000" + "在远古的中生代白垩纪晚期，大约距今7000万年前，在山西省大同地区天镇县一带（如天镇县南部的贾家屯，将军庙康代梁山），生活着一个恐龙的群体。自上世纪80年代被发现以来，经过15年断断续续的发掘，直到90年代末期才被学术界所关注。同时，为了纪念我国古脊椎动物学的创始人杨钟健教授的百年诞辰而起名为杨氏天镇龙。\n" +
        //"\u3000\u3000" + "天镇甲龙体长约5米、背高1米。头骨低平、中等大小，顶面呈等腰三角形,有膜质骨瘤状突起，形状多样、排列无序。眼眶较小,位于头骨中后部，周边有膜质骨环。前颌骨较长，上颌左右齿列近平行。下颌高，外侧无膜质骨覆盖。颈椎椎体短，双凹型，背椎长，双平型，前半部尾椎椎体短粗，后半部的则窄长，肩胛骨发达，呈矩形板状，四肢为一般的甲龙类类型。";




        //string textfinish = ReadFileChange("Assets/words/" + filename + ".txt");
        Text text=this.transform.GetComponent<Text>();
        string mm = text.text;
        string[] strArray = mm.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        string textfinish = "";
        for (int i = 0; i < strArray.Length; i++)
        {
            textfinish += strArray[i] + "\n\u3000\u3000";
        }
        text.text = textfinish;

        //var textFile = Resources.Load<TextAsset>("Text/textFile01");
        ////Debug.Log();
        //string textfinish = ReadFileChange("Assets/Resources/words/" + filename + ".txt");
        // Debug.Log(textfinish);


    }


    //按路径读取txt文本的内容，参数是路径名
    string ReadFileChange(string PathName)
    {
        string[] contents = File.ReadAllLines(PathName);//读取txt文本的内容，返回sring数组的元素是每行内容
        List<string> strList = new List<string>(contents);
        for (int i = 0; i <strList.Count; i++)
        {
           strList[i]= strList[i] + "\n\u3000\u3000";
          
        }
        string[] contentsfinish = strList.ToArray();
        string textfinish = "";
        for (int i = 0; i <contentsfinish.Length; i++)
        {
            textfinish += contentsfinish[i];
        }
        //string textfinish=string.jion(contentsfinish);
        return textfinish;   //返回处理完的文本内容
        
    }
}
