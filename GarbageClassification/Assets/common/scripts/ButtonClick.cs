using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {
    //游戏开始界面
    public GameObject gameStart;
    //游戏选择界面
    public GameObject gameSelect;
    //游戏介绍界面
    public GameObject gameDescription;
    //暂停界面
    public GameObject gamePause;
    public GameObject gameDefeat;
    public GameObject gameSuccess;

    public AudioClip clip;
    public AudioSource source;

    //CL,1=“王”，2=“张”，3=“陈”，4=“李”，5=“樊”,0是其他界面。
    public static int GameStatus = 0;
    public Text CannotNextText;

    public Text DescriptionContentText;
    public Text HighestScore;
    public Image DescriptionImage;
    public Text AllStar;
    public GameObject Fade1;
    public GameObject Fade2;
    public GameObject Fade3;
    /// <summary>
    /// 开始游戏界面开始按钮绑定的函数
    /// </summary>
    public void StartGame() {
        OnClick();
        gameStart.SetActive(false);
        gameSelect.SetActive(true);
    }
    /// <summary>
    /// 选择游戏界面选择游戏按钮需要绑定的函数
    /// </summary>
    /// <param name="gamePrefab">你的游戏的prefab</param>
    public void SelectGame(GameObject gamePrefab) {

        //CL，游戏合集状态，介绍界面的显示内容
        switch (gamePrefab.name)
        {
            case "PuzzlePanel":
                {
                    GameStatus = 1;
                    DescriptionImage.sprite = Resources.Load("Image/Main/des_1", typeof(Sprite)) as Sprite;
                    DescriptionContentText.text = "\u3000\u3000替换图块位置拼出完整的垃圾图案。";
                    HighestScore.text = "最低用时:" + PlayerPrefs.GetInt("WDY", 0) / 1000 + "." + (PlayerPrefs.GetInt("WDY", 0) % 1000).ToString() + "秒";
                    DescriptionStar(PlayerPrefs.GetInt("Star1", 0));
                    break;
                }
            case "GameObject":
                {
                    GameStatus = 2;
                    DescriptionImage.sprite = Resources.Load("Image/Main/des_2", typeof(Sprite)) as Sprite;
                    DescriptionContentText.text = "\u3000\u3000判断垃圾和垃圾桶的关系是否对应。";
                    HighestScore.text = "最高得分:" + PlayerPrefs.GetInt("ZCD", 0);
                    DescriptionStar(PlayerPrefs.GetInt("Star2", 0));
                    break;
                }
            case "CLGame":
                {
                    GameStatus = 3;
                    DescriptionImage.sprite = Resources.Load("Image/Main/des_3", typeof(Sprite)) as Sprite;
                    DescriptionContentText.text = "\u3000\u3000请点击下方按钮阻止错误的垃圾掉入垃圾桶，不要阻止正确的垃圾。";
                    HighestScore.text = "最高得分:" + PlayerPrefs.GetInt("CL", 0);
                    DescriptionStar(PlayerPrefs.GetInt("Star3", 0));
                    break;
                }
            case "LHXGame":
                {
                    GameStatus = 4;
                    DescriptionImage.sprite = Resources.Load("Image/Main/des_4", typeof(Sprite)) as Sprite;
                    DescriptionContentText.text = "\u3000\u3000操控垃圾桶去尽可能的接取正确的垃圾，同时避开其它垃圾。";
                    HighestScore.text = "最高得分:" + PlayerPrefs.GetInt("LHX", 0);
                    DescriptionStar(PlayerPrefs.GetInt("Star4", 0));
                    break;
                }
            case "fcgame":
                {
                    GameStatus = 5;
                    DescriptionImage.sprite = Resources.Load("Image/Main/des_5", typeof(Sprite)) as Sprite;
                    DescriptionContentText.text = "\u3000\u3000在书籍打开时记住每种垃圾的数量，合上时给出答案。";
                    HighestScore.text = "最低用时:" + PlayerPrefs.GetFloat("FC", 0).ToString("f2") + "秒";
                    DescriptionStar(PlayerPrefs.GetInt("Star5", 0));
                    break;
                }
            default: GameStatus = 0; break;
        }

        gameSelect.SetActive(false);
        Button enter = gameDescription.transform.Find("enter").gameObject.GetComponent<Button>();
        enter.onClick.RemoveAllListeners();
        enter.onClick.AddListener(delegate ()
        {
            OnClick();
            CannotNextText.gameObject.SetActive(false);
            gameDescription.SetActive(false);
            GameObject gameInstance = Instantiate(gamePrefab);
            gameInstance.name = gamePrefab.name;
            gameInstance.transform.SetParent(this.transform);
            gameInstance.transform.position = this.transform.position;
            gameInstance.transform.GetComponent<RectTransform>().sizeDelta = this.transform.GetComponent<RectTransform>().sizeDelta;
            gameInstance.transform.localScale = Vector3.one;
            Button btnReturnHome = gameInstance.transform.Find("Home").gameObject.GetComponent<Button>();
            btnReturnHome.onClick.RemoveAllListeners();
            btnReturnHome.onClick.AddListener(() => ReturnHomeAndDestroyGame(gameInstance));
        });
        gameDescription.SetActive(true); gamePause.SetActive(true); gameDefeat.SetActive(true); gameSuccess.SetActive(true);

    }
    /// <summary>
    /// 跳转到开始游戏界面
    /// </summary>
    /// <param name="curUI">跳转前的ui</param>
    public void ReturnHome(GameObject curUI) {
        OnClick();
        AllStar.text = "X" + (PlayerPrefs.GetInt("Star1", 0) + PlayerPrefs.GetInt("Star2", 0) + PlayerPrefs.GetInt("Star3", 0) + PlayerPrefs.GetInt("Star4", 0) + PlayerPrefs.GetInt("Star5", 0));
        curUI.SetActive(false);
        gameStart.SetActive(true);
        GameStatus = 0;
    }
    /// <summary>
    /// 返回到游戏选择界面并销毁当前正在玩的游戏
    /// </summary>
    /// <param name="curGame">当前正在进行的游戏</param>
    public void ReturnSelectAndDestroyGame(GameObject curGame) {
        OnClick();
        gameObject.SendMessage("GameLock");
        gamePause.SetActive(false);
        gameDefeat.SetActive(false);
        gameSuccess.SetActive(false);
        gameSelect.SetActive(true);
        Destroy(curGame);
        GameStatus = 0;
    }
    /// <summary>
    /// 返回到游戏开始界面并销毁当前正在玩的游戏
    /// </summary>
    /// <param name="curGame">当前正在进行的游戏</param>
    public void ReturnHomeAndDestroyGame(GameObject curGame) {
        OnClick();
        AllStar.text = "X" + (PlayerPrefs.GetInt("Star1", 0) + PlayerPrefs.GetInt("Star2", 0) + PlayerPrefs.GetInt("Star3", 0) + PlayerPrefs.GetInt("Star4", 0) + PlayerPrefs.GetInt("Star5", 0));
        gameStart.SetActive(true);
        Destroy(curGame);
        GameStatus = 0;
    }
    /// <summary>
    /// 暂停游戏(当前采用的是将你的游戏SetActive设置成false来实现暂停效果)
    /// </summary>
    /// <param name="curGame">当前正在进行的游戏</param>
    public void PauseGame(GameObject curGame) {
        OnClick();
        curGame.SetActive(false);
        gamePause.SetActive(true);
        gamePause.GetComponent<PauseShow>().Show(); //CL
    }
    /// <summary>
    /// 继续游戏
    /// </summary>
    /// <param name="curGame">当前正在进行的游戏</param>
    public void ContinueGame(GameObject curGame) {
        OnClick();
        gamePause.SetActive(false);
        curGame.SetActive(true);
    }
    public delegate void ResetCurGame();
    /// <summary>
    /// 重新开始游戏
    /// </summary>
    /// <param name="resetCurGame">你重新开始游戏的回调函数</param>
    public void ResetGame(ResetCurGame resetCurGame) {
        OnClick();
        CannotNextText.gameObject.SetActive(false);
        resetCurGame();
    }

    /// <summary>
    /// 进入下一关
    /// </summary>
    /// <param name="curGame">当前正在进行的游戏</param>
    /// <param name="nextGame">下一关要进行的游戏</param>
    public void GoNextLevel(GameObject curGame, GameObject nextGame) {
        OnClick();
        int AllStar = PlayerPrefs.GetInt("Star1", 0) + PlayerPrefs.GetInt("Star2", 0) + PlayerPrefs.GetInt("Star3", 0) + PlayerPrefs.GetInt("Star4", 0) + PlayerPrefs.GetInt("Star5", 0);

        if ((GameStatus == 1) && (AllStar < 2))
        {
            CannotNextText.gameObject.SetActive(false);
            CannotNextText.text = "星星总数达到2颗才能解锁下一关";
            CannotNextText.gameObject.SetActive(true);
            return;
        }
        if ((GameStatus == 2) && (AllStar < 4))
        {
            CannotNextText.gameObject.SetActive(false);
            CannotNextText.text = "星星总数达到4颗才能解锁下一关";
            CannotNextText.gameObject.SetActive(true);
            return;
        }
        if ((GameStatus == 3) && (AllStar < 7))
        {
            CannotNextText.gameObject.SetActive(false);
            CannotNextText.text = "星星总数达到7颗才能解锁下一关";
            CannotNextText.gameObject.SetActive(true);
            return;
        }
        if ((GameStatus == 4) && (AllStar < 10))
        {
            CannotNextText.gameObject.SetActive(false);
            CannotNextText.text = "星星总数达到10颗才能解锁下一关";
            CannotNextText.gameObject.SetActive(true);
            return;
        }
        else if (GameStatus != 5) Destroy(curGame);
        SelectGame(nextGame);
    }



    public void OnClick()
    {
        if (FindGameObjects.SetOther)
        {
            source.PlayOneShot(clip);
        }
    }

    void DescriptionStar(int StarNum)
    {
        switch (StarNum)
        {
            case 3: Fade1.SetActive(false); Fade2.SetActive(false); Fade3.SetActive(false); break;
            case 2: Fade1.SetActive(false); Fade2.SetActive(false); Fade3.SetActive(true); break;
            case 1: Fade1.SetActive(false); Fade2.SetActive(true); Fade3.SetActive(true); break;
            case 0:
            default: Fade1.SetActive(true); Fade2.SetActive(true); Fade3.SetActive(true); break;
        }
    }
}
