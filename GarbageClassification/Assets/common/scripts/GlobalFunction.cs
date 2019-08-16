using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalFunction
{
    /// <summary>
    /// 在游戏开始时调用此函数进行初始化
    /// </summary>
    /// <param name="game">场景中的game游戏对象</param>
    /// <param name="pauseGame">暂停界面的游戏对象</param>
    /// <param name="curGame">当前正在进行的游戏</param>
    public static void InitPause(GameObject game, GameObject pauseGame, GameObject curGame) {
        ButtonClick buttonClick = game.GetComponent<ButtonClick>();
        Button btnSelect = pauseGame.transform.Find("Buttons/ListButton").gameObject.GetComponent<Button>();
        btnSelect.onClick.RemoveAllListeners();
        btnSelect.onClick.AddListener(() => buttonClick.ReturnSelectAndDestroyGame(curGame));
        Button btnContinue = pauseGame.transform.Find("Buttons/PlayButton").gameObject.GetComponent<Button>();
        btnContinue.onClick.RemoveAllListeners();
        btnContinue.onClick.AddListener(() => buttonClick.ContinueGame(curGame));
        pauseGame.SetActive(false);
    }
    /// <summary>
    /// 在游戏开始时调用此函数进行初始化
    /// </summary>
    /// <param name="game">场景中的game游戏对象</param>
    /// <param name="defeatGame">失败界面的游戏对象</param>
    /// <param name="curGame">当前正在进行的游戏</param>
    /// <param name="resetGame">重新开始游戏的回调函数</param>
    public static void InitDefeat(GameObject game, GameObject defeatGame, GameObject curGame, ButtonClick.ResetCurGame resetGame) {
        ButtonClick buttonClick = game.GetComponent<ButtonClick>();
        Button btnSelect = defeatGame.transform.Find("DefeatImage/List").gameObject.GetComponent<Button>();
        btnSelect.onClick.RemoveAllListeners();
        btnSelect.onClick.AddListener(() => buttonClick.ReturnSelectAndDestroyGame(curGame));
        Button btnContinue = defeatGame.transform.Find("DefeatImage/Restart").gameObject.GetComponent<Button>();
        btnContinue.onClick.RemoveAllListeners();
        btnContinue.onClick.AddListener(() => buttonClick.ResetGame(resetGame));
        Button btnHome = defeatGame.transform.Find("Home").gameObject.GetComponent<Button>();
        btnHome.onClick.RemoveAllListeners();
        btnHome.onClick.AddListener(() => buttonClick.ReturnHomeAndDestroyGame(curGame));
        defeatGame.SetActive(false);
    }
    /// <summary>
    /// 在游戏开始时调用此函数进行初始化
    /// </summary>
    /// <param name="game">场景中的game游戏对象</param>
    /// <param name="successGame">游戏获胜界面的游戏对象</param>
    /// <param name="curGame">当前正在进行的游戏</param>
    /// <param name="nextGame">游戏获胜后进行下一关的预制体</param>
    /// <param name="resetGame">重新开始游戏的回调函数</param>
    public static void InitSuccess(GameObject game, GameObject successGame, GameObject curGame, GameObject nextGame, ButtonClick.ResetCurGame resetGame)
    {
        ButtonClick buttonClick = game.GetComponent<ButtonClick>();
        Button btnSelect = successGame.transform.Find("Buttons/ListButton").gameObject.GetComponent<Button>();
        btnSelect.onClick.RemoveAllListeners();
        btnSelect.onClick.AddListener(() => buttonClick.ReturnSelectAndDestroyGame(curGame));
        Button btnContinue = successGame.transform.Find("Buttons/RestartButton").gameObject.GetComponent<Button>();
        btnContinue.onClick.RemoveAllListeners();
        btnContinue.onClick.AddListener(() => buttonClick.ResetGame(resetGame));
        Button btnHome = successGame.transform.Find("Home").gameObject.GetComponent<Button>();
        btnHome.onClick.RemoveAllListeners();
        btnHome.onClick.AddListener(() => buttonClick.ReturnHomeAndDestroyGame(curGame));
        Button btnNext = successGame.transform.Find("Buttons/NextButton").gameObject.GetComponent<Button>();
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() => buttonClick.GoNextLevel(curGame, nextGame));
        successGame.SetActive(false);
    }

    /// <summary>
    /// 切换ui
    /// </summary>
    /// <param name="src">当前ui</param>
    /// <param name="tar">要切换到的ui</param>
    public static void ChangeUI(GameObject src, GameObject tar) {
        src.SetActive(false);
        tar.SetActive(true);
    }

    //CL加的存档功能
    //保存最高记录和设置，第一个参数是键名
    //分数是大的更新,时间是小的更新,设置是任意都更新
    //分数（和星星）的键:CL、LHX、ZCD、BGM1、BGM2、Star1、Star2、Star3、Star4、Star5、AllStar、PlayGame
    //时间的键:WDY、FC
    //设置的键:BGM1、BGM2
    //WDY单位是毫秒，ZCD1是得分，ZCD2单位是10*毫秒，FC打印时需保存两位小数，BGM1和BGM2是设置里的值。
    public static void SaveScore(string Key, int NewScore)
    {
        if (NewScore > PlayerPrefs.GetInt(Key, 0))
        {
            PlayerPrefs.SetInt(Key, NewScore);
            PlayerPrefs.Save();
        }
    }

    public static void SaveTime(string Key, int NewTime)
    {
        if (NewTime < PlayerPrefs.GetInt(Key, 0) || PlayerPrefs.GetInt(Key, 0) == 0)
        {
            PlayerPrefs.SetInt(Key, NewTime);
            PlayerPrefs.Save();
        }
    }
    public static void SaveTime(string Key, float NewTime)
    {
        if (NewTime < PlayerPrefs.GetFloat(Key, 0) || PlayerPrefs.GetFloat(Key, 0) == 0)
        {
            PlayerPrefs.SetFloat(Key, NewTime);
            PlayerPrefs.Save();
        }
    }
    public static void SaveSet(string Key,int SetBool)
    {
        PlayerPrefs.SetInt(Key, SetBool);
        PlayerPrefs.Save();
    }
}
