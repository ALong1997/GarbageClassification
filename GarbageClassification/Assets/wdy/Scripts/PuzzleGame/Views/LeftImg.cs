using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftImg : MonoBehaviour
{
    //[HideInInspector]
    //public bool isLeft = true;
    //[HideInInspector]
    //public bool isMid;
    //[HideInInspector]
    //public bool isRight;

    void Start()
    {
       // ShowImg("banana");
    }

    public void ShowImg(string name)
    {
        Sprite sprite = Resources.Load<Sprite>("Image/Garbage1/" + name + "left");
        GetComponent<Image>().sprite = sprite;
    }
}
