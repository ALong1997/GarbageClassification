using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TryAgain : MonoBehaviour {
    
    public GameObject animationBg;
    public GameObject animationText;
    public GameObject sanimationBg;
    public GameObject sanimationText;
    public GameObject ImproveDifficulty;
    public GameObject Quenum;
    public GameObject Timeobj;
    public GameObject ConfirmButton;
    public GameObject RejectButton;
    public GameObject ReStart;
    public GameObject StartMask;
    public GameObject ReadyGo;

    public Text Score;
    public Text TrueOrFalse;

    public Image RubbishImg;
    public Image TagImage;


    // Use this for initialization
    void Start () {
        // GameObject.Find("GameObject").transform.Find("TryAgain").gameObject.SetActive(false);
        //trueOrFalse = GameObject.Find("GameObject").transform.Find("TrueOrFalse").gameObject;
        Qnum.Stop = false;
        AnimationTime.canPlay = true;
        Qnum.isSuccess = false;
        Qnum.TimeStop = false;
        AnimationTime.passedTime = 0;
        Score.text = "0";
        Qnum.QNumber = 0;
        //GameObject.Find("TryAgain").SetActive(false);
        PassedTime.time = 0;
        Time.timeScale = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click()
    {
        System.Random r = new System.Random();
        int TagNum = r.Next(1, 5);
        int RubbishNum = r.Next(1, 41);
        ConfirmScripts.TagNum = TagNum;
        ConfirmScripts.RubbishNum = RubbishNum;
        RubbishImg.sprite = Resources.Load("Image/Garbage25/" + RubbishNum, typeof(Sprite)) as Sprite;
        TagImage.sprite = Resources.Load("TagImages/" + TagNum, typeof(Sprite)) as Sprite;

        Related2Uis.Success.GetComponent<Star>().BlingReset();
        Qnum.TimeStop = false;
        Qnum.isSuccess = false;
        Qnum.Stop = false;
       // AnimationTime.passedTime = 0;
        AnimationTime.canPlay= true;
        AnimationTime.passedTime = 0;
        RejectScript.timeInterval = 0;
        //AnimationTime.canPlay = true;
        //GameObject.Find("GameObject").transform.Find("Ready").gameObject.SetActive(true);
        // GameObject.Find("GameObject").transform.Find("Go").gameObject.SetActive(true);
        // GameObject.Find("GameObject").transform.Find("Ready").gameObject.GetComponent<TextFadeOut>().color.a = 1;
        //  GameObject.Find("GameObject").transform.Find("Go").gameObject.GetComponent<TextFadeOut>().color.a = 1;
        animationBg.SetActive(false);
        sanimationBg.SetActive(false);
        sanimationText.SetActive(false);
        animationText.SetActive(false);
        //GameObject.Find("GameObject").transform.Find("GameController").gameObject.GetComponent<PrepareLevel>().Start();
        ImproveDifficulty.SetActive(false);
        TrueOrFalse.text = "";
        Quenum.SetActive(true);
        Timeobj.SetActive(true);
        Timeobj.GetComponent<Text>().text = "0000";
        ConfirmButton.SetActive(true);
        RejectButton.SetActive(true);
        ReStart.SetActive(true);
        Score.text = "0";
        Qnum.QNumber = 0;
        //GameObject.Find("TryAgain").SetActive(false);
        PassedTime.time = 0;
        Time.timeScale = 1;
        //GameObject pauseBtn = GameObject.Find("game").transform.Find("GameObject").transform.Find("PauseBtn").gameObject;
        //pauseBtn.GetComponent<PauseGame>().isPaused = false;
        StartMask.SetActive(true);
        //GameObject.Find("GameObject").transform.Find("StartMask").GetComponent<StartMask>().passedTime = 0;
        Related2Uis.Success.SetActive(false);
        Related2Uis.Defeat.SetActive(false);
        Related2Uis.ZCDGame.SetActive(true);
        StartAnimator.IsStartAnimator = true;
        ReadyGo.GetComponent<Image>().sprite = StartAnimator.Ready;
        ReadyGo.transform.localScale = Vector2.one;
        ReadyGo.SetActive(true);
       

    }
}
