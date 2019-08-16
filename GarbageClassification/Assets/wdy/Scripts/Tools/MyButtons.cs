using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStart()
    {
        Tools.ReStartGame(GameStartCallBack);

    }

    public void ReturnToGame()
    {

    }

    void GameStartCallBack()
    {
        GameController GC = GlobalData.Game.transform.Find("GameControl").GetComponent<GameController>();
        GC.IsStop = false;
    }
}
