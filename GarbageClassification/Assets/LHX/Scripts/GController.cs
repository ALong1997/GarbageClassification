using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GController : MonoBehaviour
{
    private string Garbage;
    public GameObject player;   //游戏体
  //  public Joystick joystick;
    public GameObject dry;       //四种垃圾
    public GameObject wet;
    public GameObject rec;
    public GameObject ham;
    private Vector3 v = new Vector3(0,100,0);

    private int hazardCount =10;      // 每波垃圾的数量
    private int sright = 4;
    public GameObject Rubbish;
    public GameObject bg;

    public static int gateCount; //关卡计数
    public static float rubbishSpeed; //垃圾掉落速度（变量）

    public Text countText;       //记分板
    public GameObject ReadyGo;
    public static bool reSetBtnIsClick;

    public static Vector3 rotate = new Vector3(0, 0, 45); //垃圾自旋转
    public static bool goal;      //得分标志
    public static int count;     //得分计数

    private int k;           //延时记录
    private int l;           //记录生成的是该波中第几个垃圾
    private int[] c;         //记录该波中可得分垃圾的序数
    private GameObject effect;


    private float[] speed = new float[11] { 12, 22, 32, 40, 44, 47, 50, 50, 50, 50, 50 };
    //private float[] speed = new float[11] { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };

    private void Start()
    {
        Initialization();      
    }

    private void Update()
    {
        CountText(count);
        if (!StartAnimator.IsStartAnimator)
        {
            k++;
        }
        if (!PlayerController.gameOver&&!CommonCtrl.isSuccess)
        {
            if (k >= 30)
            {
                if (l == 1)
                {
                    rubbishSpeed = -speed[gateCount - 1];
                    switch ((gateCount - 1) % 4)
                    {
                        case 0:
                            {
                                BgController.btype = BgController.BgType.干垃圾;
                                PlayerController.btype = PlayerController.PlayerType.Dry;
                            }
                            break;
                        case 1:
                            {
                                BgController.btype = BgController.BgType.湿垃圾;
                                PlayerController.btype = PlayerController.PlayerType.Wet;
                            }
                            break;
                        case 2:
                            {
                                BgController.btype = BgController.BgType.可回收垃圾;
                                PlayerController.btype = PlayerController.PlayerType.Recyclable;
                            }
                            break;
                        case 3:
                            {
                                BgController.btype = BgController.BgType.有害垃圾;
                                PlayerController.btype = PlayerController.PlayerType.Hamful;
                            }
                            break;
                    }
                    bg.SendMessage("BgColour", BgController.btype);
                    player.SendMessage("TrashColour", PlayerController.btype);
                    c = new int[sright];
                    GetRandNum(sright, hazardCount, c);
                }
                if (l <= hazardCount)
                {
                    if (Exist(l, c, sright))
                    {
                        switch ((gateCount - 1) % 4)
                        {
                            //dry.GetComponent<Image>().sprite = Resources.Load("DryRImage/" + 1, typeof(Sprite)) as Sprite;
                            case 0: { effect = Instantiate(dry); } break;
                            case 1: { effect = Instantiate(wet); } break;
                            case 2: { effect = Instantiate(rec); } break;
                            case 3: { effect = Instantiate(ham); } break;
                            default: { effect = null; } break;
                        }
                    }
                    else
                    {
                        int picNum = Random.Range(0, 3);
                        switch ((gateCount - 1) % 4)
                        {
                            case 0: { effect = Randomtype(wet, rec, ham); } break;
                            case 1: { effect = Randomtype(dry, rec, ham); } break;
                            case 2: { effect = Randomtype(dry, wet, ham); } break;
                            case 3: { effect = Randomtype(dry, wet, rec); } break;
                            default: { effect = null; } break;
                        }
                    }
                    effect.transform.SetParent(Rubbish.transform);
                    effect.transform.localScale = new Vector3(1, 1, 1);
                    effect.transform.localPosition = new Vector3(Random.Range(-260,260), 0, 0);
                    rubbishSpeed -= ((speed[gateCount] - speed[gateCount - 1]) / hazardCount);
                    k = 0;
                    l++;
                }
            }
            if (k >= 120)
            {
                if (!PlayerController.gameOver)
                    count += 6;
                CountText(count);
                DryRC.Score = 0;
                WetRC.Score = 0;
                RecRC.Score = 0;
                HamRC.Score = 0;
                gateCount++;
                k = 0;
                l = 1;
            }
        }
        if(PlayerController.gameOver)
        {
            rubbishSpeed = 0;
        }
        if(reSetBtnIsClick)
        {
            Initialization();
        }
    }

    public GameObject Randomtype(GameObject a,GameObject b,GameObject c)
    {
        int picNum = Random.Range(0, 3);
        GameObject eff;
        switch (picNum)
        {
            case 0: { eff = Instantiate(a); } break;
            case 1: { eff = Instantiate(b); } break;
            case 2: { eff = Instantiate(c); } break;
            default: { eff = null; } break;
        }
        return eff;
    }

    public void CountText(int count)
    {
        countText.text = "得分 :" + count.ToString();
    }

    public void GetRandNum(int site,int size,int[] result)
    {
        
        int temp;
        for(temp = 0;temp < site;temp++)
        {            
            int id = Random.Range(1, size+1);
            result[temp] = id;
            for (int c = 0; c < temp; c++)
            {
                if(result[c]==result[temp])
                {
                    temp--;
                }
            }            
        }
    }
    public bool Exist(int j,int[] k,int size)
    {
        for(int i =0;i<size;i++)
        {
            if (j == k[i])
                return true;
        }
        return false;
    }

    public void Initialization()
    {
        k = 0;
        l = 1;
        CommonCtrl.Success.GetComponent<Star>().BlingReset();
        AnimationTimeLHX.canPlay = true;
        CommonCtrl.isSuccess = false;
        StartAnimator.IsStartAnimator = true;
        ReadyGo.GetComponent<Image>().sprite = StartAnimator.Ready;
        ReadyGo.transform.localScale = Vector2.one;
        ReadyGo.SetActive(true);
        player.SetActive(true); 
        player.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
        count = 0;
        gateCount = 1;
        CountText(count);
        reSetBtnIsClick = false;
        PlayerController.gameOver = false;
        goal = false;
        DryRC.Score = 0;
        WetRC.Score = 0;
        RecRC.Score = 0;
        HamRC.Score = 0;
        Des(Rubbish);
        Des(player); 
        bg.GetComponent<Image>().sprite = null;
        player.GetComponent<Image>().sprite = Resources.Load("Trash/垃圾桶0", typeof(Sprite)) as Sprite;
        CommonCtrl.Success.SetActive(false);
        CommonCtrl.Defeat.SetActive(false);
        CommonCtrl.LHXGame.SetActive(true);
        AnimationTimeLHX.passedTime = 0;
    }

    public void Des(GameObject Obj)
    {
        for (int i = 0; i < Obj.transform.childCount; i++)
        {
            if (Obj.transform.GetChild(i) != null)
            {
                Destroy(Obj.transform.GetChild(i).gameObject);
            }
        }
    }
}
