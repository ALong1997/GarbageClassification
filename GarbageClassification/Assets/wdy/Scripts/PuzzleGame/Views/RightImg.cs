using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightImg : MonoBehaviour
{
    //[HideInInspector]
    //public bool isLeft;
    //[HideInInspector]
    //public bool isMid;
    //[HideInInspector]
    //public bool isRight = true;
    void Start()
    {
        //ShowImg("banana");
    }

    public void ShowImg(string name)
    {
        Sprite sprite = Resources.Load<Sprite>("Image/Garbage1/" + name + "right");
        GetComponent<Image>().sprite = sprite;
    }
}
