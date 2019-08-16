using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;

public class AccountPanelController : MonoBehaviour
{
    //结束界面整个界面的所有方法
    public RectTransform LeftStar;
    public RectTransform MidStar;
    public RectTransform RightStar;
    public Text UsedTime;
    public Text LeastTime;
    public int Least;
    //判断等级的依据
    private readonly int ThreeStarGrade = 8000;
    private readonly int TwoStarGrade = 12000;
    public List<RectTransform> rects;
    //存本地游戏的记录
    //private string Score;
    //private List<int> AllScore;
    private void OnEnable()
    {
        //AllScore = new List<int>();
        //SaveScore();
        //ReadScore();

        GlobalData.ChangeTime = 0;
        GameObject.Find("Canvas/EndGamePanel").transform.SetAsLastSibling();
        rects = new List<RectTransform>
        {
            LeftStar,
            MidStar,
            RightStar
        };
        //LeftStar.gameObject.SetActive(false);
       // MidStar.gameObject.SetActive(false);
       // RightStar.gameObject.SetActive(false);
        
        if (GlobalData.UseAllTime <= ThreeStarGrade)
        {
            GlobalData.Grade = 2;
        }
        else if (GlobalData.UseAllTime <= TwoStarGrade)
        {
            GlobalData.Grade = 1;
        }
        else
        {
            GlobalData.Grade = 0;
        }

        ShowThreeStars(GlobalData.Grade);
        SetStarAct(GlobalData.Grade);

        if (PlayerPrefs.HasKey("leastTime"))
        {
            Least = PlayerPrefs.GetInt("leastTime");
            if (GlobalData.UseAllTime < Least)
            {
                PlayerPrefs.SetInt("leastTime", GlobalData.UseAllTime);
            }
        }
        else
        {
            PlayerPrefs.SetInt("leastTime", GlobalData.UseAllTime);
        }

        LeastTime.text = Least.ToString();
        UsedTime.text = GlobalData.UseAllTime.ToString();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    //public void SaveScore()
    //{
    //    Score = File.ReadAllText(GlobalData.ScorePath);
    //    Score += 'a' +GlobalData.UseAllTime.ToString();
    //    File.WriteAllText(GlobalData.ScorePath,Score);
    //}

    //public void ReadScore()
    //{
    //    string[] OneScore = Score.Split('a');
    //    for (int i = 1; i < OneScore.Length; i++)
    //    {
    //        AllScore.Add(int.Parse(OneScore[i]));
    //    }
    //    AllScore.Sort();
    //    for (int i = 0; i < AllScore.Count; i++)
    //    {
            //TODO
    //    }
    //}

    //重新开始这个游戏
    public void ReStartThisGame()
    {
        AnimationTimeWDY.passedTime = 0;
        AnimationTimeWDY.canPlay = true;
        GameController.isFailed = false;
        GameObject.Find("game").transform.Find("PuzzlePanel").transform.Find("GameControl").gameObject.GetComponent<GameController>().UseTime = 0;
        GameObject.Find("Canvas/EndGamePanel").SetActive(false);
        GameObject go = GlobalData.Game;
        go.SetActive(true);
        go.GetComponent<PuzzleController>().ReStart();
    }

    //分别设置星星状态
    void SetStarAct(int i)
    {
        //for (int j = 0; j < i; j++)
        //{
        //    Invoke(rects[j].gameObject.name + "Active", 0.05f + 0.5f * j);
        //}
        if (i == 1)
        {
            Invoke("ShowStarLeft", 0.05f);
        }
        else if (i == 2)
        {
            Invoke("ShowStarLeft", 0.05f);
            Invoke("ShowStarMid", 0.55f);
        }
        else if (i == 3)
        {
            Invoke("ShowStarLeft", 0.05f);
            Invoke("ShowStarMid", 0.55f);
            Invoke("ShowStarRight", 1.05f);
        }

    }

    //显示星星动画
    void ShowThreeStars(int i)
    {
        var stars = DOTween.Sequence();
        
        for (int j = 0; j < i; j++)
        {        
            stars.Append(rects[j].DOScale(Vector2.one, 0.5f));
        }

    }

    void ShowAllStars(RectTransform rect)
    {
        rect.gameObject.SetActive(true);       
    }
    void ShowStarLeft()
    {
        LeftStar.gameObject.SetActive(true);
    }
    void ShowStarMid()
    {
        MidStar.gameObject.SetActive(true);
    }

    void ShowStarRight()
    {
        RightStar.gameObject.SetActive(true);
    }
}
