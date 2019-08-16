using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidImg : MonoBehaviour
{
    //[HideInInspector]
    //public bool isLeft;
    //[HideInInspector]
    //public bool isMid = true;
    //[HideInInspector]
    //public bool isRight;

    void Start()
    {
       // ShowImg("banana");
    }

    public void ShowImg(string name)
    {
        Sprite sprite = Resources.Load<Sprite>("Image/Garbage1/" + name + "mid");
        GetComponent<Image>().sprite = sprite;
    }
}
