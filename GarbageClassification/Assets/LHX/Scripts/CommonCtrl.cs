using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonCtrl : MonoBehaviour
{
    public static GameObject LHXGame;
    public static GameObject Pause;
    public static GameObject Defeat;
    public static GameObject Success;
    public static GameObject SetUI;
    public static bool isSuccess;
    
    GameObject MyParent;
   // GameObject AnimationTime;
    // Start is called before the first frame update
    void Start()
    {
        LHXGame = this.gameObject;
        MyParent = transform.parent.gameObject;
        Pause = MyParent.transform.Find("pause").gameObject;
        Success = MyParent.transform.Find("success").gameObject;
        Defeat = MyParent.transform.Find("defeat").gameObject;
        SetUI = MyParent.transform.Find("setUI").gameObject;
       // AnimationTime = GameObject.Find("LHXGame").transform.Find("AnimationBg").gameObject;
        GlobalFunction.InitPause(MyParent, Pause, LHXGame);
        GlobalFunction.InitDefeat(MyParent, Defeat, LHXGame, GameObject.Find("GameController").GetComponent<GController>().Initialization);
        GlobalFunction.InitSuccess(MyParent, Success, LHXGame, (GameObject)Resources.Load("prefabs/games/fcgame"), GameObject.Find("GameController").GetComponent<GController>().Initialization);
    }

    // Update is called once per frame
    void Update()
    {
        bool canPlay = AnimationTimeLHX.canPlay;
        if (GController.gateCount >= 11)
        {
            isSuccess = true;
            //CL
            GlobalFunction.SaveScore("LHX", GController.count);
            if (GController.count >= 95)
            {
                Success.GetComponent<Star>().Bling(3);
                if (PlayerPrefs.GetInt("Star4", 0) < 3)
                {
                    PlayerPrefs.SetInt("Star4", 3);
                    MyParent.transform.Find("select/4LHX/Star/Star1/Star").gameObject.SetActive(true);
                    MyParent.transform.Find("select/4LHX/Star/Star2/Star").gameObject.SetActive(true);
                    MyParent.transform.Find("select/4LHX/Star/Star3/Star").gameObject.SetActive(true);
                }
            }
            else if (GController.count >= 85)
            {
                Success.GetComponent<Star>().Bling(2);
                if (PlayerPrefs.GetInt("Star4", 0) < 2)
                {
                    PlayerPrefs.SetInt("Star4", 2);
                    MyParent.transform.Find("select/4LHX/Star/Star1/Star").gameObject.SetActive(true);
                    MyParent.transform.Find("select/4LHX/Star/Star2/Star").gameObject.SetActive(true);
                }
            }
            else
            {
                Success.GetComponent<Star>().Bling(1);
                if (PlayerPrefs.GetInt("Star4", 0) < 1)
                {
                    PlayerPrefs.SetInt("Star4", 1);
                    MyParent.transform.Find("select/4LHX/Star/Star1/Star").gameObject.SetActive(true);
                }
            }
            Success.transform.Find("ScoreImg/ScoreText").GetComponent<Text>().text = "得分:" + GController.count;
            
        }
        if(PlayerController.gameOver&&!canPlay)
        {

            GlobalFunction.ChangeUI(LHXGame, Defeat);
        }
        if (isSuccess && !canPlay)
        {
            GlobalFunction.ChangeUI(LHXGame, Success);
        }
    }

    public void GamePause()
    {
       MyParent.GetComponent<ButtonClick>().PauseGame(LHXGame);
    }

    public void Select()
    {
        MyParent.transform.Find("select").gameObject.SetActive(true);
        Destroy(LHXGame);
    }

}
