
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    public enum STATUS
    {
        START,
        MEMORY,
        OP,
        PAUSE,
        GO_NEXT_LEVEL,
        END,
    }
    public STATUS status, preStatus;
    public GameObject garbagePrefab;
    public GameObject plus1Prefab;
    public GameObject buttons;
    public GameObject garbagesObject;
    public GameObject bookopen;
    public GameObject bookclose;
    public GameObject fcGame;
    public GameObject leftBottom;
    public GameObject topRight;


    public GameObject resetGame;
    public GameObject pauseGame;

    public Button btn1;
    public Button btn2;
    public Button btn3;

    GameObject parent;
    GameObject pause;
    GameObject defeat;
    GameObject success;

    GameObject ReadyGo; //CL


    //public GameObject game;
    //public GameObject pause;
    //public GameObject defeat;
    //public GameObject success;


    public GameObject[] signList;
    public Text[] countList;

    public List<GameObject> tt;

    public int exclude;

    private int level;
    private int[] total;
    private int[] cur;
    private float memoryTime;
    private float timeToWin;
    private float totalTime;
    private Sprite[] sprites;
    private GameObject[] garbages;
    public Text[] timeText;
    public List<LevelSetting> levelSettings;
    public List<GarbageSetting> garbageSettings;
    public static bool isFailed;
    public static bool isSuccess;

    //CL
    Sprite[] DefeatSprites;

    // Use this for initialization
    void Start () {
        isFailed = false;
        isSuccess = false;
        AnimationTimeFC.canPlay = true;
        AnimationTimeFC.passedTime = 0;
        parent = transform.parent.gameObject;
        pause = parent.transform.Find("pause").gameObject;
        defeat = parent.transform.Find("defeat").gameObject;
        success = parent.transform.Find("success").gameObject;
        GlobalFunction.InitPause(parent, pause, fcGame);
        GlobalFunction.InitDefeat(parent, defeat, fcGame, Restart);
        GlobalFunction.InitSuccess(parent, success, fcGame, null, Restart);
        sprites = new Sprite[] {
            Resources.Load("Image/Garbage25/1", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/2", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/3", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/4", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/5", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/6", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/7", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/8", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/9", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/10", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/11", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/12", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/13", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/14", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/15", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/16", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/17", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/18", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/19", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/20", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/21", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/22", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/23", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/24", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/25", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/26", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/27", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/28", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/29", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/30", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/31", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/32", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/33", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/34", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/35", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/36", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/37", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/38", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/39", typeof(Sprite)) as Sprite,
            Resources.Load("Image/Garbage25/40", typeof(Sprite)) as Sprite,
            Resources.Load("atlas/不可回收按钮1", typeof(Sprite)) as Sprite,
            Resources.Load("atlas/不可回收按钮2", typeof(Sprite)) as Sprite,
            Resources.Load("atlas/湿垃圾1", typeof(Sprite)) as Sprite,
            Resources.Load("atlas/湿垃圾2", typeof(Sprite)) as Sprite,
            Resources.Load("atlas/可回收按钮1", typeof(Sprite)) as Sprite,
            Resources.Load("atlas/可回收按钮2", typeof(Sprite)) as Sprite,
            Resources.Load("atlas/有害垃圾1", typeof(Sprite)) as Sprite,
            Resources.Load("atlas/有害垃圾2", typeof(Sprite)) as Sprite,
        };
        readJson();
        total = new int[Constant.TYPE_NUM];
        cur = new int[Constant.TYPE_NUM];
        InitPerPlay();
        status = STATUS.START;
        tt = new List<GameObject>();


        //以下是CL写的
        success.GetComponent<Star>().BlingReset();
        //为了解决游戏成功后再进入游戏显示的是成功界面的bug
        success.SetActive(false);
        defeat.SetActive(false);

        //为了加上游戏开始动画，播放动画时书合上，按钮隐藏
        ReadyGo = transform.Find("ReadyGo").gameObject;
        buttons.SetActive(false);
        bookopen.SetActive(false);
        bookclose.SetActive(true);
        DefeatSprites = new Sprite[3];
    }
	
	// Update is called once per frame
	void Update () {
        AI();
        if (!AnimationTimeFC.canPlay && isFailed)
        {
            GlobalFunction.ChangeUI(this.gameObject, defeat);
        }
    }
    private void AI() {
        //CL加的游戏开始动画
        if(!StartAnimator.IsStartAnimator)
        {
            StartAnimator.IsStartAnimator = true;
            bookopen.SetActive(true);
            bookclose.SetActive(false);
        }
        //游戏中止
        if (status == STATUS.END) {
            return;
        }
        //暂停
        if (status == STATUS.PAUSE) {
            return;
        }
        //游戏开始，初始化垃圾
        if (status == STATUS.START) {
            InitGarbage(level - 1);
            status = STATUS.MEMORY;
        }
        //记忆时间
        if (status == STATUS.MEMORY) {
            if (CheckMemoryTime()) {
                status = STATUS.OP;
            }
        }
        //玩家操作，选择垃圾种类
        if (status == STATUS.OP) {
            totalTime += Time.deltaTime;
            TimeUpdate(totalTime);
            int op = OpStatus();
            if (op == 1)
            {
                btn1.interactable = false;
                btn2.interactable = false;
                btn3.interactable = false;
                //延时结束，游戏胜利
                if (timeToWin < 0)
                {
                    status = STATUS.GO_NEXT_LEVEL;
                }
                //操作正确后的延时
                else {
                    timeToWin -= Time.deltaTime;
                }
            }
            //游戏失败
            else if (op == -1) {
                Main.isFailed = true;
                foreach (Transform child in buttons.transform)
                {
                    child.GetComponent<Button>().enabled = false;
                }
                status = STATUS.END;
                
                AnimationTimeFC.canPlay = true;
                defeat.GetComponent<DefeatShow>().ThreeShow(DefeatSprites, total);
            }
        }
        //过关，跳到下一关卡
        if (status == STATUS.GO_NEXT_LEVEL) {
            //已经通过了最后一关
            if (level == levelSettings.Count)
            {
                isSuccess = true;
                status = STATUS.END;
                //CL
                float AllTime = totalTime;
                GlobalFunction.SaveTime("FC", AllTime);
                if (AllTime <= 8)
                {
                    success.GetComponent<Star>().Bling(3);
                    if (PlayerPrefs.GetInt("Star5", 0) < 3)
                    {
                        PlayerPrefs.SetInt("Star5", 3);
                        parent.transform.Find("select/4LHX/Star/Star1/Star").gameObject.SetActive(true);
                        parent.transform.Find("select/4LHX/Star/Star2/Star").gameObject.SetActive(true);
                        parent.transform.Find("select/4LHX/Star/Star3/Star").gameObject.SetActive(true);
                    }
                }
                else if (AllTime <= 10)
                {
                    success.GetComponent<Star>().Bling(2);
                    if (PlayerPrefs.GetInt("Star5", 0) < 2)
                    {
                        PlayerPrefs.SetInt("Star5", 2);
                        parent.transform.Find("select/4LHX/Star/Star1/Star").gameObject.SetActive(true);
                        parent.transform.Find("select/4LHX/Star/Star2/Star").gameObject.SetActive(true);
                    }
                }
                else
                {
                    success.GetComponent<Star>().Bling(1);
                    if (PlayerPrefs.GetInt("Star5", 0) < 1)
                    {
                        PlayerPrefs.SetInt("Star5", 1);
                        parent.transform.Find("select/4LHX/Star/Star1/Star").gameObject.SetActive(true);
                    }
                }
                success.transform.Find("ScoreImg/ScoreText").GetComponent<Text>().text = "用时:" + AllTime.ToString("f2")+"秒";
            }
            else {
                ++level;
                InitPerLevel();
                status = STATUS.START;
            }
        }
    }
    //在每一关开始前的初始化
    private void InitPerLevel() {
        
        bookopen.SetActive(true);
        bookclose.SetActive(false);
        buttons.SetActive(false);
        btn1.interactable = true;
        btn2.interactable = true;
        btn3.interactable = true;
        status = STATUS.START;
        timeToWin = Constant.TIME_TO_WIN;
        Array.Clear(total, 0, total.Length);
        Array.Clear(cur, 0, total.Length);
        for (int i = 0; i < 3; ++i) {
            countList[i].text = "0";
        }
        for (int i = 0; i < 4; ++i) {
            timeText[i].text = "0";
        }
        foreach (Transform child in buttons.transform)
        {
            child.GetComponent<Button>().enabled = true;
        }
    }
    //在每次游戏开始时的初始化
    public void InitPerPlay() {
        level = 1;
        totalTime = 0;
        InitPerLevel();
    }
    //初始化垃圾
    private void InitGarbage(int levelId) {
        memoryTime = levelSettings[levelId].RunTime;
        int startId = levelSettings[levelId].StartId;
        int endId = levelSettings[levelId].EndId;
        garbages = new GameObject[endId - startId + 1];
        exclude = levelSettings[levelId].Exclude;
        for (int i = 0; i < 3; ++i) {
            int picNum = i < exclude ? i : i + 1;
            signList[i].GetComponent<Image>().sprite = sprites[40 + picNum * 2];
            SpriteState state = new SpriteState();
            state.pressedSprite = sprites[40 + picNum * 2 + 1];
            signList[i].GetComponent<Button>().spriteState = state;
        }
        for (int i = startId; i <= endId; ++i) {
            int rand = UnityEngine.Random.Range(0, 3);
            rand = rand < exclude ? rand : rand + 1;
            ++total[rand];
            garbages[i - startId] = CreateGarbage(rand, garbageSettings[i].PositionX, garbageSettings[i].PositionY);
        }
        //CL
        for (int i = 0; i < 3; i++) DefeatSprites[i] = garbages[i].GetComponent<Image>().sprite;
    }
    //创建一个垃圾
    private GameObject CreateGarbage(int cls, float x, float y) {
        GameObject garbage = Instantiate(garbagePrefab);
        //找图片
        garbage.GetComponent<Image>().sprite = sprites[cls * 10 + UnityEngine.Random.Range(0, 10)];
        float z = leftBottom.transform.position.z;
        x = leftBottom.transform.position.x + (topRight.transform.position.x - leftBottom.transform.position.x) * x / 100;
        y = leftBottom.transform.position.y + (topRight.transform.position.y - leftBottom.transform.position.y) * y / 100;
        garbage.transform.position = new Vector3(x, y, z);
        garbage.transform.SetParent(garbagesObject.transform);
        garbage.transform.localScale = new Vector3(1, 1, 1);
        return garbage;
    }
    //若记忆时间已过，则合上书
    public bool CheckMemoryTime() {
        if (memoryTime < 0) {
            for (int i = 0; i < garbages.Length; ++i)
            {
                Destroy(garbages[i]);
            }
            buttons.SetActive(true);
            bookopen.SetActive(false);
            bookclose.SetActive(true);
            return true;
        }
        memoryTime -= Time.deltaTime;
        return false;
    }
    //检查玩家的操作(待优化)
    public int OpStatus() {
        int ret = 1;
        for (int i = 0; i < Constant.TYPE_NUM; ++i) {
            //失败
            if (total[i] < cur[i])
            {
                ret = -1;
                break;
            }
            //可能未完成
            else if (total[i] > cur[i])
            {
                ret = 0;
            }
        }
        return ret;
    }

    public void curAdd(int index) {
        ++cur[index];
    }
    
    public void readJson()
    {
        JSONNode node = null;
        TextAsset filePath = (TextAsset)Resources.Load("0");
        levelSettings = new List<LevelSetting>();
        garbageSettings = new List<GarbageSetting>();
        if (filePath == null)   // Json文件读取失败，打印日志
            Debug.Log("find json file faild!");
        else
            node = JSON.Parse(filePath.text);    // 转为json格式
        //获取关卡设置
        for (int i = 0; i < node[0].Count; ++i) {
            LevelSetting ls = new LevelSetting();
            ls.Id = node[0][i]["id"];
            ls.Exclude = node[0][i]["exclude"] - 1;
            ls.GarbageNum = node[0][i]["garbage_num"];
            ls.RunTime = node[0][i]["run_time"];
            ls.StartId = node[0][i]["start_id"] - 1;
            ls.EndId = node[0][i]["end_id"] - 1;
            levelSettings.Add(ls);
        }
        //获取垃圾设置
        for (int i = 0; i < node[1].Count; ++i) {
            GarbageSetting gs = new GarbageSetting();
            gs.Id = node[1][i]["id"];
            gs.PositionX = node[1][i]["position_x"];
            gs.PositionY = node[1][i]["position_y"];
            garbageSettings.Add(gs);
        }
    }

    //暂停
    public void SetPause() {
        parent.GetComponent<ButtonClick>().PauseGame(this.gameObject);
    }
    //重开
    public void Restart() {
        success.GetComponent<Star>().BlingReset();
        isFailed = false;
        isSuccess = false;
        AnimationTimeFC.canPlay = true;
        AnimationTimeFC.passedTime = 0;
        this.gameObject.SetActive(true);
        success.SetActive(false);
        defeat.SetActive(false);
        for (int i = 0; i < garbages.Length; ++i) {
            Destroy(garbages[i]);
        }
        InitPerPlay();
        status = STATUS.START;
        buttons.SetActive(false);
        bookopen.SetActive(false);
        bookclose.SetActive(true);
        StartAnimator.IsStartAnimator = true;
        ReadyGo.GetComponent<Image>().sprite = StartAnimator.Ready;
        ReadyGo.transform.localScale = Vector2.one;
        ReadyGo.SetActive(true);
    }

    public void NumUpdate(int opNum) {
        int x = cur[opNum < exclude ? opNum : opNum + 1] ;
        countList[opNum].text = "" + x;
        //GameObject t = Instantiate(plus1Prefab);
        //t.transform.position = signList[opNum].transform.position;
        //t.transform.SetParent(fcGame.transform);
        //t.transform.localScale = new Vector3(1, 1, 1);
        //tt.Add(t);
    }
    public void Op(int opNum)
    {
        curAdd(opNum < exclude ? opNum : opNum + 1);
        NumUpdate(opNum);
    }

    public void TimeUpdate(float t) {
        int[] showTime = new int[4];
        int x = Mathf.RoundToInt(t * 1000);
        for (int i = 3; i >= 0; --i) {
            timeText[i].text = "" + (x % 10);
            x /= 10;
        }
    }
    

}
