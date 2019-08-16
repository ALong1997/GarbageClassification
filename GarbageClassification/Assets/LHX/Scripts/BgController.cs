using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgController : MonoBehaviour
{
    public Image image;
    public Sprite dry;
    public Sprite wet;
    public Sprite recyclable;
    public Sprite harmful;
    public static BgType btype;


    public enum BgType
    {
        干垃圾, 湿垃圾, 可回收垃圾, 有害垃圾
    }

    public void BgColour(BgType type)
    {
        switch (type)
        {
            case BgType.干垃圾: { image.sprite = dry; } break;
            case BgType.湿垃圾: { image.sprite = wet; } break;
            case BgType.可回收垃圾: { image.sprite = recyclable; } break;
            case BgType.有害垃圾: { image.sprite = harmful; } break;
        }


    }
}
