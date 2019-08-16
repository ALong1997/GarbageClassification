using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//四种类型
public enum TypeEnum
{
    可回收垃圾,
    湿垃圾,
    有害垃圾,
    干垃圾
}

public class StaticFunction : MonoBehaviour
{
    //打开公示牌按钮交互
    public static void OpenButton()
    {
        Game.ButtonR.interactable = true;
        Game.ButtonW.interactable = true;
        Game.ButtonH.interactable = true;
        Game.ButtonO.interactable = true;
    }

    //关闭公示牌按钮交互
    public static void CloseButton()
    {
        Game.ButtonR.interactable = false;
        Game.ButtonW.interactable = false;
        Game.ButtonH.interactable = false;
        Game.ButtonO.interactable = false;
    }

    //游戏重开
    public static void GameRestart()
    {
        Game.Success.GetComponent<Star>().BlingReset();
        AnimationTimeCL.passedTime = 0;
        Game.isFailed = false;
        Game.isSuccess = false;
        AnimationTime.canPlay = true;
        //垃圾复位
        if (Game.IsGarbageMove)
        {
            Destroy(Game.GarbageChoose);
        }

        //有公示牌复位
        if (Game.IsBillboardMove)
        {
            Game.BillboardClick.GetComponent<Move>().IsRise = false;
            Game.BillboardClick.transform.localPosition = Game.BillboardPos;
            Game.IsBillboardMove = false;
            ScoreAnimator.IsInit = true;
        }

        //初始化数据
        CloseButton();
        Game.Level = 0;
        Game.Score = 0;

        ScoreAnimator.IsInit = true;
        if(ScoreAnimator.IsScoreAnimator == true)
        {
            ScoreAnimator.IsScoreAnimator = false;
            Game.AddScoreChoose.SetActive(false);
        }
        StartAnimator.IsStartAnimator = true;
        Game.ReadyGo.GetComponent<Image>().sprite = StartAnimator.Ready;
        Game.ReadyGo.transform.localScale = Vector2.one;
        Game.ReadyGo.SetActive(true);
        Game.Success.SetActive(false);
        Game.Defeat.SetActive(false);
        Game.CLGame.SetActive(true);
    }

    //游戏成功
    public static void GameSuccess()
    {
        Game.isSuccess = true;
        AnimationTimeCL.canPlay = true;
        GlobalFunction.SaveScore("CL", Game.Score);
        Game.Success.transform.Find("ScoreImg/ScoreText").GetComponent<Text>().text = "得分:" + Game.Score;
        if (Game.Score >= 90)
        {
            Game.Success.GetComponent<Star>().Bling(3);
            if (PlayerPrefs.GetInt("Star3", 0) < 3)
            {
                PlayerPrefs.SetInt("Star3", 3);
                Game.MyParent.transform.Find("select/3CL/Star/Star1/Star").gameObject.SetActive(true);
                Game.MyParent.transform.Find("select/3CL/Star/Star2/Star").gameObject.SetActive(true);
                Game.MyParent.transform.Find("select/3CL/Star/Star3/Star").gameObject.SetActive(true);
            }
        }
        else if (Game.Score >= 75)
        {
            Game.Success.GetComponent<Star>().Bling(2);
            if (PlayerPrefs.GetInt("Star3", 0) < 2)
            {
                PlayerPrefs.SetInt("Star3", 2);
                Game.MyParent.transform.Find("select/3CL/Star/Star1/Star").gameObject.SetActive(true);
                Game.MyParent.transform.Find("select/3CL/Star/Star2/Star").gameObject.SetActive(true);
            }
        }
        else
        {
            Game.Success.GetComponent<Star>().Bling(1);
            if (PlayerPrefs.GetInt("Star3", 0) < 1)
            {
                PlayerPrefs.SetInt("Star3", 1);
                Game.MyParent.transform.Find("select/3CL/Star/Star1/Star").gameObject.SetActive(true);
            }
        }
    }

    //游戏失败
    public static void GameDefeat()
    {
        Game.isFailed = true;
        AnimationTimeCL.canPlay = true;
        Game.Defeat.GetComponent<DefeatShow>().OneShow(Game.GarbageChoose.GetComponent<Image>().sprite, Game.GarbageType.ToString());
    }
}
