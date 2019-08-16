using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//游戏主函数

public class Game : MonoBehaviour
{
    //关卡数、成功次数、总分
    public static int Level = 0, Score = 0, AddScore = 0;

    //游戏难度,调整垃圾下降速度
    public static float[] Difficulty = new float[10] { 2.0f, 1.7f, 1.4f, 1.2f, 1.0f, 0.9f, 0.8f, 0.77f, 0.66f, 0.6f };

    public GameObject GarbageR;
    public GameObject GarbageW;
    public GameObject GarbageH;
    public GameObject GarbageO;

    //游戏开始动画、加分动画
    public static GameObject ReadyGo;
    public static GameObject AddScoreChoose;

    //垃圾栏、垃圾出现的赛道、出现的垃圾
    GameObject GarbageLine;
    GameObject LineChoose;
    public static GameObject GarbageChoose;

    //垃圾是否移动判断、公示牌是否移动判断、游戏失败标识
    public static bool IsGarbageMove;
    public static bool IsBillboardMove;
    public static bool isFailed;
    public static bool isSuccess;

    //赛道、垃圾和公示牌类型
    public static TypeEnum LineType;
    public static TypeEnum GarbageType;
    public static TypeEnum BillboardType;

    //四个公示牌和暂停按钮
    public static Button ButtonR;
    public static Button ButtonW;
    public static Button ButtonH;
    public static Button ButtonO;

    //被点击的公示牌
    public static GameObject BillboardClick;

    //公示牌初始位置
    public static Vector3 BillboardPos;

    //公用界面需要控制的物体
    public static GameObject CLGame;
    public static GameObject Pause;
    public static GameObject Defeat;
    public static GameObject Success;
    public static GameObject MyParent;

    // Start is called before the first frame update
    void Start()
    {
        CLGame = this.gameObject;
        MyParent = transform.parent.gameObject;
        Pause = MyParent.transform.Find("pause").gameObject;
        Success = MyParent.transform.Find("success").gameObject;
        Defeat = MyParent.transform.Find("defeat").gameObject;

        GlobalFunction.InitPause(MyParent, Pause, CLGame);
        GlobalFunction.InitDefeat(MyParent, Defeat, CLGame, StaticFunction.GameRestart);
        GlobalFunction.InitSuccess(MyParent, Success, CLGame, (GameObject)Resources.Load("prefabs/games/LHXGame"), StaticFunction.GameRestart);

        ReadyGo = transform.Find("ReadyGo").gameObject;
        GarbageLine = transform.Find("Garbage").gameObject;

        ButtonR = transform.Find("Board/BoardR").GetComponent<Button>();
        ButtonW = transform.Find("Board/BoardW").GetComponent<Button>();
        ButtonH = transform.Find("Board/BoardH").GetComponent<Button>();
        ButtonO = transform.Find("Board/BoardO").GetComponent<Button>();

        ButtonR.onClick.AddListener(OnClick);
        ButtonW.onClick.AddListener(OnClick);
        ButtonH.onClick.AddListener(OnClick);
        ButtonO.onClick.AddListener(OnClick);

        IsGarbageMove = false;
        IsBillboardMove = false;

        Restart();
    }

    //控制游戏关卡
    void Update()
    {
        //播完开始动画之后再开始游戏
        if (!StartAnimator.IsStartAnimator && Level < 10)
        {
            GameStart();
        }
    }


    //游戏开始，随机出现垃圾
    public void GameStart()
    {
        StartAnimator.IsStartAnimator = true;

        //选择哪一列出现垃圾和对应的加分动画
        int RandLine = Random.Range(0, 4);
        LineChoose = GarbageLine.transform.GetChild(RandLine).gameObject;
        AddScoreChoose = LineChoose.transform.GetChild(0).gameObject;

        //选择出现哪个垃圾
        int RandGarbage = Random.Range(0, 4);
        switch(RandGarbage)
        {
            case 0: GarbageChoose = Instantiate(GarbageR); break;
            case 1: GarbageChoose = Instantiate(GarbageW); break;
            case 2: GarbageChoose = Instantiate(GarbageH); break;
            case 3: GarbageChoose = Instantiate(GarbageO); break;
        }
        GarbageChoose.transform.SetParent(LineChoose.transform);
        GarbageChoose.transform.localPosition = Vector3.zero;
        GarbageChoose.transform.localScale = Vector3.one;

        LineType = LineChoose.GetComponent<ThisType>().MyType;
        GarbageType = GarbageChoose.GetComponent<ThisType>().MyType;

        //垃圾移动
        GarbageChoose.SetActive(true);
        GarbageChoose.GetComponent<Move>().IsDrop = true;
        IsGarbageMove = true;

        //打开公示牌按钮交互
        StaticFunction.OpenButton();
    }


    //点击公示牌，垃圾暂停，公示牌上升，判断操作是否正确并进行相应反应
    public void OnClick()
    {
        //获取被点击的公示牌及其类型
        BillboardClick = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        BillboardType = BillboardClick.GetComponent<ThisType>().MyType;

        if (BillboardType == LineType)
        {
            //移除公示牌按钮交互
            StaticFunction.CloseButton();

            //垃圾暂停
            GarbageChoose.GetComponent<Move>().IsDrop = false;
            IsGarbageMove = false;

            //记录公示牌原始位置和点击公示牌时垃圾位置
            BillboardPos = BillboardClick.transform.localPosition;

            //被点击的公示牌上升
            BillboardClick.GetComponent<Move>().IsRise = true;
            IsBillboardMove = true;
        }
    }

    //游戏暂停
    public void GamePause()
    {
        MyParent.GetComponent<ButtonClick>().PauseGame(gameObject);
    }

    //游戏重开
    public void Restart()
    {
        StaticFunction.GameRestart();
    }
}
