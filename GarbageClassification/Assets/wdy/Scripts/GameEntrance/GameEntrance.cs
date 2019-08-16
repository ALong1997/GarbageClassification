 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    //入口 加载游戏界面
    //PS.所有动画都用的DoTween
    void Start()
    {

        //PlayerPrefs.DeleteAll();
    }

    public void StartGame()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/PuzzlePanel"));
        go.transform.SetParent(GameObject.Find("Canvas").transform, false);
        go.name = "PuzzlePanel";
        GlobalData.Game = go;
        this.transform.parent.gameObject.SetActive(false);
    }
}
