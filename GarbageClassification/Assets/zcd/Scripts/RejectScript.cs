using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class RejectScript : MonoBehaviour
{
    public Image RubbishImg;
    public Image TagImage;
    public static  int RubbishNum = 1;
    public static  int TagNum = 1;
    private string temp;
    private string temp1;
    private Dictionary<int, int[]> answerDict;
    public Text Score;
    public Text trueOrFalse;
    public GameObject ImproveDifficulty;
    public GameObject OverText;
    public static float timeInterval;
    private float timeLimit = 2;
    public float timeScale1=1;
    public float timeScale2=1;

   




    // Use this for initialization
    void Start()
    {
        GameObject trueOrFalse = GameObject.Find("TrueOrFalse");
        int[] DryR = {  1,  2,  3,  4,  5,  6,  7,  8,  9, 10 };
        int[] WetR = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        int[] RecyR ={ 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        int[] HamR = { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };
        answerDict = new Dictionary<int, int[]>
        {
            { 1, DryR },
            { 2, WetR },
            { 3, RecyR },
            { 4, HamR }
        };

        RubbishNum = ConfirmScripts.RubbishNum;
        TagNum = ConfirmScripts.TagNum;
        ImproveDifficulty.SetActive(false);


        System.Random r = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        //float colorIndex = GameObject.Find("GameObject").transform.Find("Go").gameObject.GetComponent<TextFadeOut>().colorIndex;
        bool isStartAnimator = StartAnimator.IsStartAnimator;
       if(!isStartAnimator)
        {
            //print(colorIndex);
            if (Qnum.QNumber > 5)
            {
                timeLimit = 3;
                ImproveDifficulty.SetActive(true);
            }
            else
            {
                timeLimit = 3;
                ImproveDifficulty.SetActive(false);
            }
            if (timeInterval > timeLimit)
            {
                //回答超时
                OverText.GetComponent<TextFade>().color.a = 1;
                OverText.SetActive(true);
                Qnum.QNumber +=1;
                Score.text = (int.Parse(Score.text) - 0).ToString();
                System.Random r = new System.Random();
                TagNum = r.Next(1, 5);
                RubbishNum = r.Next(1, 41);
                ConfirmScripts.RubbishNum = RubbishNum;
                ConfirmScripts.TagNum = TagNum;
                temp = "Image/Garbage25/" + RubbishNum;
                temp1 = "TagImages/" + TagNum;
                RubbishImg.overrideSprite = Resources.Load(temp, typeof(Sprite)) as Sprite;
                TagImage.overrideSprite = Resources.Load(temp1, typeof(Sprite)) as Sprite;
                timeInterval = 0;
            }
            timeInterval += Time.deltaTime;

        }
    }
    public void Click()
    {
        timeInterval = 0;
       // print(trueOrFalse);
        Qnum.QNumber += 1;
        //Debug.Log(TagNum + " " + RubbishNum);
        //先判断用户给的结果是否正确
        int res = Array.IndexOf(answerDict[TagNum], RubbishNum);
        if (res != -1)
        {
            //Debug.Log("判断错了");
            Score.text = (int.Parse(Score.text) - 0).ToString();
            trueOrFalse.GetComponent<TextFade>().color.a = 1;
            trueOrFalse.text = "判断错了!";
        
        }
        else
        {
           // Debug.Log("判断正确");
            trueOrFalse.text = "判断正确!";
            trueOrFalse.GetComponent<TextFade>().color.a = 1;
            Score.text = (int.Parse(Score.text) + 1).ToString();
        }
        System.Random r = new System.Random();
        TagNum = r.Next(1, 5);
        RubbishNum = r.Next(1, 41);
        ConfirmScripts.RubbishNum = RubbishNum;
        ConfirmScripts.TagNum = TagNum;
        temp = "Image/Garbage25/" + RubbishNum;
        temp1 = "TagImages/" + TagNum;
        RubbishImg.overrideSprite = Resources.Load(temp, typeof(Sprite)) as Sprite;
        TagImage.overrideSprite = Resources.Load(temp1, typeof(Sprite)) as Sprite;

    }
}
