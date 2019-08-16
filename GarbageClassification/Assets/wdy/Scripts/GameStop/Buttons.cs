using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStart()
    {
        Tools.ReStartGame(Restart);

    }


    void Restart()
    {
        GameController GC = GlobalData.Game.transform.Find("GameControl").GetComponent<GameController>();
        GC.IsStop = false;
    }
}
