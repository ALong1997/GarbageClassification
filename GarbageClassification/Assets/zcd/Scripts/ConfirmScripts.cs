using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ConfirmScripts : MonoBehaviour {
    public Image RubbishImg;
    public Image TagImage;
    public static int RubbishNum = 1;
    public static int TagNum = 1;
    private string temp;
    private string temp1;
    private Dictionary<int, int[]> answerDict;
    public Text Score;
    public Text trueOrFalse;





    // Use this for initialization
    void Start () {
       
        int[] DryR = { 1, 2, 3, 4, 5, 6, 7, 8, 9,10};
        int[] WetR = {11,12,13,14,15,16,17,18,19,20};
        int[] RecyR ={21,22,23,24,25,26,27,28,29,30};
        int[] HamR = {31,32,33,34,35,36,37,38,39,40};
        answerDict = new Dictionary<int, int[]>
        {
            { 1, DryR },
            { 2, WetR },
            { 3, RecyR },
            { 4, HamR }
        };
        Score.text = "0";


        System.Random r = new System.Random();
        TagNum = r.Next(1,5);
        RubbishNum = r.Next(1, 41);
        RubbishImg.sprite = Resources.Load("Image/Garbage25/" + RubbishNum, typeof(Sprite)) as Sprite;
        TagImage.sprite = Resources.Load("TagImages/"+TagNum, typeof(Sprite)) as Sprite;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click()
    {
        RejectScript.timeInterval = 0;
        //print(QN);
        Qnum.QNumber = Qnum.QNumber + 1;
        //Debug.Log(TagNum + " " + RubbishNum);
        //先判断用户给的结果是否正确
        int res = Array.IndexOf(answerDict[TagNum], RubbishNum);
        if(res == -1)
        {
            //Debug.Log("判断错了!");
            Score.text = (int.Parse(Score.text) - 0).ToString();
            trueOrFalse.GetComponent<TextFade>().color.a = 1;
            trueOrFalse.text = "判断错了!";

        }
        else
        {
            //Debug.Log("判断正确");
            Score.text = (int.Parse(Score.text) + 1).ToString();
            trueOrFalse.text = "判断正确!";
            trueOrFalse.GetComponent<TextFade>().color.a = 1;

        }
        System.Random r = new System.Random();
        TagNum = r.Next(1, 5);
        RubbishNum = r.Next(1, 41);
        RejectScript.RubbishNum = RubbishNum;
        RejectScript.TagNum = TagNum;
        temp = "Image/Garbage25/" + RubbishNum;
        temp1 = "TagImages/" + TagNum;
        RubbishImg.overrideSprite = Resources.Load(temp, typeof(Sprite)) as Sprite;
        TagImage.overrideSprite = Resources.Load(temp1, typeof(Sprite)) as Sprite;
      
    }
}
