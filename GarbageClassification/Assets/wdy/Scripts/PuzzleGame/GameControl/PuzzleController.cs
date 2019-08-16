using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public Transform GameControl;
    private GameController GC;
    public GameObject Buttons;
    // Start is called before the first frame update
    void Start()
    {
        // GlobalFunction.InitPause();
        GlobalData.GameSuccess.GetComponent<Star>().BlingReset();
         GameControl = transform.Find("GameControl");
        GC = GameControl.GetComponent<GameController>();
        GlobalData.UseAllTime = 0;
        GlobalData.ChangeTime = 0;
        GlobalData.Left = false;
        GlobalData.Mid = false;
        GlobalData.Right = false;
        GC.UseTime = 0;
    }

    //在结束界面的重新开始本关调用，和游戏界面的重玩按钮逻辑一样。
    public void ReStart()
    {
        GlobalData.UseAllTime = 0;
        GlobalData.ChangeTime = 0;

        GC.ReloadImg();
        GC.UseTime = 0;
    }
}
