using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Related2Uis : MonoBehaviour
{
    //公用界面需要控制的物体
    public static GameObject ZCDGame;
    public static GameObject Pause;
    public static GameObject Defeat;
    public static GameObject Success;
    public static GameObject MyParent;

    // Start is called before the first frame update
    void Start()
    {
        ZCDGame = this.gameObject;
        MyParent = transform.parent.gameObject;
        Pause = MyParent.transform.Find("pause").gameObject;
        Success = MyParent.transform.Find("success").gameObject;
        Defeat = MyParent.transform.Find("defeat").gameObject;

        Success.SendMessage("BlingReset");

        GlobalFunction.InitPause(MyParent, Pause, ZCDGame);
        GlobalFunction.InitDefeat(MyParent, Defeat, ZCDGame, GameObject.Find("game").transform.Find("GameObject").transform.Find("TryAgain").gameObject.GetComponent<TryAgain>().Click);
        GlobalFunction.InitSuccess(MyParent, Success, ZCDGame, (GameObject)Resources.Load("prefabs/games/CLGame"), GameObject.Find("game").transform.Find("GameObject").transform.Find("TryAgain").GetComponent<TryAgain>().Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        MyParent.GetComponent<ButtonClick>().PauseGame(gameObject);
    }
}
