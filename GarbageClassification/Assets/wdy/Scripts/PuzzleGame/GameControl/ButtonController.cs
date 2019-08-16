using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonController : MonoBehaviour
{
    Transform LeftPos;
    Transform MidPos;
    Transform RightPos;
    public GameObject LeftClone;
    public GameObject MidClone;
    public GameObject RightClone;
    public GameObject GameController1;
    private GameObject BackImg;
    public Button StopBtn;

    private GameController GC;
    private BackImgShow ImgShow;

    private readonly int ThreeStarGrade = 8000;
    private readonly int TwoStarGrade = 12000;

    public GameObject Game;
    public GameObject PauseGame;
    public GameObject CurGame;
    public GameObject SucceedGame;
    public GameObject Defeat;

    public Button btn1;
    public Button btn2;
    public Button btn3;

    public GameObject WDYgame;

    //CL
    GameObject ReadyGo;
    GameObject Mask;
    

    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.Find("Canvas/game");
        PauseGame = Game.transform.Find("pause").gameObject;
        CurGame = Game.transform.Find("PuzzlePanel").gameObject;
        SucceedGame = Game.transform.Find("success").gameObject;
        Defeat = Game.transform.Find("defeat").gameObject;

        BackImg = GameObject.Find("BackImage");
        LeftPos = GameObject.Find("Canvas/game/PuzzlePanel/GameControl/LeftPos").transform;
        MidPos = GameObject.Find("Canvas/game/PuzzlePanel/GameControl/MidPos").transform;
        RightPos = GameObject.Find("Canvas/game/PuzzlePanel/GameControl/RightPos").transform;

        GlobalFunction.InitPause(Game, PauseGame, CurGame);
        GlobalFunction.InitSuccess(Game, SucceedGame, CurGame, (GameObject)Resources.Load("prefabs/games/GameObject"), ReStart);
        GlobalFunction.InitDefeat(Game, Defeat, CurGame, ReStart);


        GC = GameController1.GetComponent<GameController>();
        ImgShow = BackImg.GetComponent<BackImgShow>();

        //CL
        ReadyGo = CurGame.transform.Find("ReadyGo").gameObject;
        Mask= CurGame.transform.Find("GameControl/StartMask_CL").gameObject;
    }

    //重玩本关
    public void ReStart()
    {
        GlobalData.Left = false;
        GlobalData.Mid = false;
        GlobalData.Right = false;
        SucceedGame.GetComponent<Star>().BlingReset();
        GameController.isFailed = false;
        GameController.isSuccess = false;
        GlobalData.Left = false;
        GlobalData.Mid = false;
        GlobalData.Right = false;
        AnimationTimeWDY.passedTime = 0;
        AnimationTimeWDY.canPlay = true;
        GameObject.Find("game").transform.Find("PuzzlePanel").transform.Find("GameControl").gameObject.GetComponent<GameController>().UseTime = 0;
        GlobalData.UseAllTime = 0;
        GlobalData.ChangeTime = 0;
        GC.UseTimeInt = 0;
        ImgShow.Show();
        ImgShow.IsStop = false;

        GC.UseTime = 0;
        GC.ReloadImg();

        SucceedGame.SetActive(false);
        Defeat.SetActive(false);
        CurGame.SetActive(true);

        //CL加的动画初始化
        StartAnimator.IsStartAnimator = true;
        ReadyGo.GetComponent<Image>().sprite = StartAnimator.Ready;
        ReadyGo.transform.localScale = Vector2.one;
        ReadyGo.SetActive(true);
        Mask.SetActive(true);
    }
    //暂停按钮按下时逻辑
    public void ChangeGameState()
    {
        //GC.IsStop = true;
        Game.GetComponent<ButtonClick>().PauseGame(WDYgame);
        Tools.StopPanel(SetLast);
        this.transform.parent.gameObject.SetActive(false);

    }

    /// <summary>
    /// 第一第二没有意义，目的是交换两个预制体的位置
    /// </summary>
    /// <param name="changePosFirst">按下的第一个按钮</param>
    /// <param name="changePosSecond">按下的第二个按钮</param>
    void ChangeBtns(Transform changePosFirst,Transform changePosSecond)
    {
        Transform temp;
        temp = changePosFirst;
        Transform changeImgFirst = changePosFirst.GetChild(0);
        Transform changeImgSecond = changePosSecond.GetChild(0);
        changeImgFirst.SetParent(changePosSecond);
        changeImgSecond.SetParent(temp);
        RectTransform rcFirst = changeImgFirst.GetComponent<RectTransform>();
        RectTransform rcSecond = changeImgSecond.GetComponent<RectTransform>();
        rcFirst.DOLocalMove(Vector2.zero, 0.05f);
        rcSecond.DOLocalMove(Vector2.zero, 0.05f);
    }

    //按钮们的逻辑
    public void LeftButton()
    {
        GlobalData.Left = true;
        if (GlobalData.Mid == true)
        {
            ChangeBtns(MidPos, LeftPos);
            GlobalData.Left = false;
            GlobalData.Mid = false;
            Success();
        }

        if (GlobalData.Right == true)
        {
            ChangeBtns(RightPos, LeftPos);
            GlobalData.Left = false;
            GlobalData.Right = false;
            Success();
        }
    }

    public void MidButton()
    {
        GlobalData.Mid = true;
        if (GlobalData.Left == true)
        {
            ChangeBtns(LeftPos, MidPos);
            GlobalData.Left = false;
            GlobalData.Mid = false;
            Success();
        }

        if (GlobalData.Right == true)
        {
            ChangeBtns(RightPos, MidPos);
            GlobalData.Mid = false;
            GlobalData.Right = false;
            Success();
        }
    }

    public void RightButton()
    {
        GlobalData.Right = true;
        if (GlobalData.Left == true)
        {
            ChangeBtns(LeftPos, RightPos);
            GlobalData.Left = false;
            GlobalData.Right = false;
            Success();
        }

        if (GlobalData.Mid == true)
        {
            ChangeBtns(MidPos, RightPos);
            GlobalData.Mid = false;
            GlobalData.Right = false;
            Success();
        }
    }

    //判断拼图是否完成和当拼图完成时执行的逻辑，为了玩家的游戏体验，使用了延迟函数延迟了0.5秒
    public void Success()
    {
        if (GlobalData.ChangeTime < GlobalData.MaxChangeTime)
        {
            if (LeftPos.GetChild(0).tag == LeftPos.tag &&
                MidPos.GetChild(0).tag == MidPos.tag &&
                RightPos.GetChild(0).tag == RightPos.tag
                )
            {
                btn1.interactable = false;
                btn2.interactable = false;
                btn3.interactable = false;
                GlobalData.ChangeTime += 1;
                GC.IsStop = true;
                ImgShow.IsStop = true;
                int useTime = GC.UseTimeInt;
                GlobalData.UseAllTime += useTime;
                GlobalData.AllScores.Add(useTime);
                GC.UseTime = 0;

                Invoke("DestoryThis", 0.5f);
            }
        }
        else
        {
            if (LeftPos.GetChild(0).tag == LeftPos.tag &&
                MidPos.GetChild(0).tag == MidPos.tag &&
                RightPos.GetChild(0).tag == RightPos.tag
                )
            {
                //CL
                int AllTime = GlobalData.UseAllTime;
                if (AllTime <= 9999)
                {
                    SucceedGame.GetComponent<Star>().Bling(3);
                    if (PlayerPrefs.GetInt("Star1", 0) < 3)
                    {
                        PlayerPrefs.SetInt("Star1", 3);
                        Game.transform.Find("select/1WDY/Star/Star1/Star").gameObject.SetActive(true);
                        Game.transform.Find("select/1WDY/Star/Star2/Star").gameObject.SetActive(true);
                        Game.transform.Find("select/1WDY/Star/Star3/Star").gameObject.SetActive(true);
                    }
                }
                else if (AllTime <= 11111)
                {
                    SucceedGame.GetComponent<Star>().Bling(2);
                    if (PlayerPrefs.GetInt("Star1", 0) < 2)
                    {
                        PlayerPrefs.SetInt("Star1", 2);
                        Game.transform.Find("select/1WDY/Star/Star1/Star").gameObject.SetActive(true);
                        Game.transform.Find("select/1WDY/Star/Star2/Star").gameObject.SetActive(true);
                    }
                }
                else
                {
                    SucceedGame.GetComponent<Star>().Bling(1);
                    if (PlayerPrefs.GetInt("Star1", 0) < 1)
                    {
                        PlayerPrefs.SetInt("Star1", 1);
                        Game.transform.Find("select/1WDY/Star/Star1/Star").gameObject.SetActive(true);
                    }
                }
                GlobalFunction.SaveTime("WDY", AllTime);
                SucceedGame.transform.Find("ScoreImg/ScoreText").GetComponent<Text>().text = "用时:" + AllTime / 1000 + "." + (AllTime % 1000).ToString() + "秒";
               // GC.animationText.GetComponent<Text>().text = "游戏成功";
                AnimationTimeWDY.canPlay = true;
                GameController.isSuccess = true;
            }
        }
    }

    //显示游戏结束界面
    public void ShowEndPanel()
    {
        GlobalData.ChangeTime = 0;

        if (GlobalData.UseAllTime <= ThreeStarGrade)
        {
            GlobalData.Grade = 3;
        }
        else if (GlobalData.UseAllTime <= TwoStarGrade)
        {
            GlobalData.Grade = 2;
        }
        else
        {
            GlobalData.Grade = 1;
        }
        ImgShow.IsStop = true;
        GlobalData.ShowText = GlobalData.UseAllTime.ToString();
        CurGame.SetActive(false);
        Defeat.SetActive(false);

       // this.transform.parent.gameObject.SetActive(true);
    }

    public void DestoryThis()
    {
        GC.ReloadImg();
        ImgShow.IsStop = false;
        GC.IsStop = false;
    }
    void Update()
    {
        if (GameController.isSuccess && !AnimationTimeWDY.canPlay)
        {
            Tools.SuccessPanel(ShowEndPanel);
        }
    }
    public void SetLast()
    {
        //GlobalData.GameStop.transform.SetAsLastSibling();
    }
}
