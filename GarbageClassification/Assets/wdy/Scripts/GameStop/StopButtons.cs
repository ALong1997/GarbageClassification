using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStart()
    {
        Tools.ReStartGame(Restart);

    }

    public void ReturnToList()
    {
        Tools.ReturnToOption(Return);
    }

    void Restart()
    {
        GameController GC = GlobalData.Game.transform.Find("GameControl").GetComponent<GameController>();
        GC.IsStop = false;
    }

    void Return()
    {
        GlobalData.Game = null;
        GlobalData.UseAllTime = 0;
        GlobalData.ChangeTime = 0;
        GlobalData.Left = false;
        GlobalData.Right = false;
        GlobalData.Mid = false;
    }
}
