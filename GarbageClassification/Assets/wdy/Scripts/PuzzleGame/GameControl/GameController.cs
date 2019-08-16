using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform LeftPos;
    public Transform MidPos;
    public Transform RightPos;
    private Transform LeftImage;
    private Transform MidImage;
    private Transform RightImage;
    //所用时间和转int后时间
    public float UseTime;
    public int UseTimeInt;
    //private Text timeText;
    //是否暂停游戏
    public bool IsStop;
    //刷新的图片的名字
    private string ThisName;
    //private int TTT = 1;

    private ButtonController Bc;
    public static bool isFailed;
    public static bool isSuccess;
    public GameObject animationText;

    public Button btn1;
    public Button btn2;
    public Button btn3;

    // Start is called before the first frame update
    void Start()
    {
        isFailed = false;
        isSuccess = false;
        GlobalData.Left = false;
        GlobalData.Mid = false;
        GlobalData.Right = false;
        GlobalData.ChangeTime = 0;
        AnimationTimeWDY.passedTime = 0;
        AnimationTimeWDY.canPlay = true;
        LeftPos = transform.Find("LeftPos");
        MidPos = transform.Find("MidPos");
        RightPos = transform.Find("RightPos");
        //timeText = GameObject.Find("TimeText").GetComponent<Text>();
        //ChangeImg();
        //Debug.Log(LeftPos.gameObject.name);
        LeftImage = Instantiate(Resources.Load<GameObject>("Prefabs/LeftImage")).transform;
        MidImage = Instantiate(Resources.Load<GameObject>("Prefabs/MidImage")).transform;
        RightImage = Instantiate(Resources.Load<GameObject>("Prefabs/RightImage")).transform;
        
        ReloadImg();
        GameObject go = GameObject.Find("Canvas/game/PuzzlePanel/Buttons");
        Bc = go.GetComponent<ButtonController>();

    }

    public void ReloadImg()
    {
        btn1.interactable = true;
        btn2.interactable = true;
        btn3.interactable = true;
        ChangeImg();
        int rand = Random.Range(0, 3);

        switch (rand)
        {
            case 0:
                Refreash(LeftPos, RightPos, MidPos, ThisName);
                break;
            case 1:
                int nextRand = Random.Range(0, 2);
                if (nextRand == 0)
                {
                    Refreash(MidPos, LeftPos, RightPos, ThisName);
                }
                else
                {
                    Refreash(MidPos, RightPos, LeftPos, ThisName);
                }
                break;
            case 2:
                int nextRandOne = Random.Range(0, 2);
                if (nextRandOne == 0)
                {
                    Refreash(RightPos, MidPos, LeftPos, ThisName);
                }
                else
                {
                    Refreash(RightPos, LeftPos, MidPos, ThisName);
                }
                break;
            default:
                break;
        }

    }

    //随机刷新图片的逻辑
    public void ChangeImg()
    {
        int num = Random.Range(0, 10);
        switch (num)
        {
            case 0:ThisName = "香蕉";break;
            case 1:ThisName = "梳子";break;
            case 2:ThisName = "电池";break;
            case 3:ThisName = "手提包";break;
            case 4: ThisName = "书本"; break;
            case 5: ThisName = "创可贴"; break;
            case 6: ThisName = "剩菜"; break;
            case 7: ThisName = "树叶"; break;
            case 8: ThisName = "药瓶"; break;
            case 9: ThisName = "面包"; break;
            default:break;      
        }
    }
    // Update is called once per frame
    void Update()
    {
        ////判断失败动画是否播放完成
        //if (!AnimationTimeWDY.canPlay && isFailed)
        //{
        //    //CL
        //    Bc.Defeat.GetComponent<DefeatShow>().WDYShow();
        //    GlobalFunction.ChangeUI(Bc.CurGame, Bc.Defeat);
        //}
        //CL加了开始动画结束后游戏开始的控制开关
        if (!StartAnimator.IsStartAnimator)
        {
            if (UseTime <= 5555)
            {
                if (!isSuccess)
                {
                    UseTime += Time.deltaTime * 1000.0f;
                    UseTimeInt = Mathf.FloorToInt(UseTime);
                }              
            }
            else
            {
                animationText.GetComponent<Text>().text = "游戏失败";
                AnimationTimeWDY.canPlay = true;
                isFailed = true;

            }
        }
    }

    /// <summary>
    ///  随机设置父物体，然后localPosition归零，完成随机刷新图片
    /// </summary>
    /// <param name="leftParent">应该在左边的图片的实际位置</param>
    /// <param name="midParent">应该在中间的图片的实际位置</param>
    /// <param name="rightParent">应该在右边的图片的实际位置</param>
    /// <param name="thisName">生成时使用的图片</param>
    public void Refreash(Transform leftParent,Transform midParent,Transform rightParent,string thisName)
    {
        GameObject go = GameObject.Find("Canvas/game/PuzzlePanel/Buttons");
        ButtonController bc = go.GetComponent<ButtonController>();
        bc.LeftClone = LeftImage.gameObject;
        bc.MidClone = MidImage.gameObject;
        bc.RightClone = RightImage.gameObject;
        LeftImage.gameObject.GetComponent<LeftImg>().ShowImg(thisName);
        MidImage.gameObject.GetComponent<MidImg>().ShowImg(thisName);
        RightImage.gameObject.GetComponent<RightImg>().ShowImg(thisName);
        MoveToZero(LeftImage, leftParent);
        MoveToZero(MidImage, midParent);
        MoveToZero(RightImage, rightParent);
    }
  
    public void MoveToZero(Transform transform,Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector2.zero;
        transform.localScale = Vector2.one;
    }
}
