using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Qnum : MonoBehaviour {

    public static int QNumber;
    public Text Score;
    public static bool isSuccess;
    public static bool TimeStop;
    public static bool Stop;
//    private Animator animator;

	// Use this for initialization
	void Start () {
        TimeStop = false;
        isSuccess = false;
        //this.gameObject.GetComponent<Text>().text = "0/12";
        //animator = GameObject.Find("GameObject").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //this.gameObject.GetComponent<Text>().text = QNumber.ToString()+"/10";
        if(QNumber == 10)
        {
            Stop = true;
            //print("游戏结束");
            //GameObject.Find("GameObject").transform.Find("Image").GetComponent<DesByTime>().canPlay = true;
            // GameObject.Find("Canvas").GetComponent<Animator>().Update(0);


            // GameObject.Find("Image").GetComponent<DesByTime>().passedTime = 0;
            // print(animator);

            // GameObject.Find("GameOverText").GetComponent<DesByTime>().passedTime = 0;
            //animator.Play("GameOver2");

            //GameObject.Find("GameObject").transform.Find("ResultBg").gameObject.SetActive(true);
            // GameObject.Find("GameObject").transform.Find("TryAgain").gameObject.SetActive(true);

            int AllTime = PassedTime.time;
            int myScore = int.Parse(Score.text);
            //Debug.Log("用时" + time);
            if (myScore == 10 && AllTime < 1000)
            {
               // TimeStop = true;
                isSuccess = true;
                //CL成功界面分数显示
                GlobalFunction.SaveScore("ZCD", myScore);
                Related2Uis.Success.GetComponent<Star>().Bling(3);
                if (PlayerPrefs.GetInt("Star2", 0) < 3)
                {
                    PlayerPrefs.SetInt("Star2", 3);
                    Related2Uis.MyParent.transform.Find("select/2ZCD/Star/Star1/Star").gameObject.SetActive(true);
                    Related2Uis.MyParent.transform.Find("select/2ZCD/Star/Star2/Star").gameObject.SetActive(true);
                    Related2Uis.MyParent.transform.Find("select/2ZCD/Star/Star3/Star").gameObject.SetActive(true);
                }
                Related2Uis.Success.transform.Find("ScoreImg/ScoreText").GetComponent<Text>().text = "得分:" + myScore + "  用时:" + AllTime / 100 + "." + (AllTime % 100).ToString() + "秒";

                AnimationTime.canPlay = true;
                // AnimationTime.canPlay = true;
                //GameObject.Find("Result").GetComponent<Text>().text = "游戏结束, 您的评价为S";
                //GlobalFunction.ChangeUI(Related2Uis.ZCDGame, Related2Uis.Success);
            }
            else if (myScore >7 &&myScore < 10 && AllTime < 1700)
            {
                isSuccess = true;
                //TimeStop = true;
                //CL成功界面分数显示
                GlobalFunction.SaveScore("ZCD", myScore);
                Related2Uis.Success.GetComponent<Star>().Bling(2);
                if (PlayerPrefs.GetInt("Star2", 0) < 2)
                {
                    PlayerPrefs.SetInt("Star2", 2);
                    Related2Uis.MyParent.transform.Find("select/2ZCD/Star/Star1/Star").gameObject.SetActive(true);
                    Related2Uis.MyParent.transform.Find("select/2ZCD/Star/Star2/Star").gameObject.SetActive(true);
                }
                    Related2Uis.Success.transform.Find("ScoreImg/ScoreText").GetComponent<Text>().text = "得分:" + myScore + "  用时:" + AllTime / 100 + "." + AllTime % 100 + "秒";
                AnimationTime.canPlay = true;
               // GameObject.Find("Result").GetComponent<Text>().text = "游戏结束, 您的评价为A";
                //GlobalFunction.ChangeUI(Related2Uis.ZCDGame, Related2Uis.Success);
            }
            else if (myScore >= 6 && myScore < 10)
            {
                isSuccess = true;
                //TimeStop = true;
                //CL成功界面分数显示
                GlobalFunction.SaveScore("ZCD", myScore);
                Related2Uis.Success.GetComponent<Star>().Bling(1);
                if (PlayerPrefs.GetInt("Star2", 0) < 1)
                {
                    PlayerPrefs.SetInt("Star2", 1);
                    Related2Uis.MyParent.transform.Find("select/2ZCD/Star/Star1/Star").gameObject.SetActive(true);
                }
                    Related2Uis.Success.transform.Find("ScoreImg/ScoreText").GetComponent<Text>().text = "得分:" + myScore + "  用时:" + AllTime / 100 + "." + AllTime % 100 + "秒";
                AnimationTime.canPlay = true;
                // GameObject.Find("Result").GetComponent<Text>().text = "游戏结束, 您的评价为A";
                //GlobalFunction.ChangeUI(Related2Uis.ZCDGame, Related2Uis.Success);
            }
            else
            {
                TimeStop = true;
                //GameObject.Find("Result").GetComponent<Text>().text = "游戏结束, 您的评价为B";
                AnimationTime.canPlay = true;
                Related2Uis.Defeat.GetComponent<DefeatShow>().ZCDShow();
            }
            //GameObject.Find("ConfirmButton").SetActive(false);
            //GameObject.Find("RejectButton").SetActive(false);
            //GameObject.Find("Time").SetActive(false);
            //GameObject.Find("Qnum").SetActive(false);
        }
       
    }
}
