using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int Num = Random.Range(0, 10);
        switch (gameObject.name[7])
        {
            case 'R':
                {
                    switch (Num)
                    {
                        case 0: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/书本", typeof(Sprite)) as Sprite; ; break;
                        case 1: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/塑料瓶", typeof(Sprite)) as Sprite; ; break;
                        case 2: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/报纸", typeof(Sprite)) as Sprite; ; break;
                        case 3: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/旧包", typeof(Sprite)) as Sprite; ; break;
                        case 4: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/旧电器", typeof(Sprite)) as Sprite; ; break;
                        case 5: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/旧衣服", typeof(Sprite)) as Sprite; ; break;
                        case 6: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/易拉罐", typeof(Sprite)) as Sprite; ; break;
                        case 7: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/玻璃杯", typeof(Sprite)) as Sprite; ; break;
                        case 8: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/玻璃酒瓶", typeof(Sprite)) as Sprite; ; break;
                        case 9: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Rec/罐头盒", typeof(Sprite)) as Sprite; ; break;
                    }
                    break;
                }
            case 'W':
                {
                    switch (Num)
                    {
                        case 0: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/剩菜", typeof(Sprite)) as Sprite; ; break;
                        case 1: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/果核", typeof(Sprite)) as Sprite; ; break;
                        case 2: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/果皮", typeof(Sprite)) as Sprite; ; break;
                        case 3: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/树叶", typeof(Sprite)) as Sprite; ; break;
                        case 4: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/番茄", typeof(Sprite)) as Sprite; ; break;
                        case 5: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/肉", typeof(Sprite)) as Sprite; ; break;
                        case 6: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/蛋壳", typeof(Sprite)) as Sprite; ; break;
                        case 7: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/蛋糕", typeof(Sprite)) as Sprite; ; break;
                        case 8: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/面包", typeof(Sprite)) as Sprite; ; break;
                        case 9: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Wet/鱼骨", typeof(Sprite)) as Sprite; ; break;
                    }
                    break;
                }
            case 'H':
                {
                    switch (Num)
                    {
                        case 0: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/医疗器具", typeof(Sprite)) as Sprite; ; break;
                        case 1: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/水银体温计", typeof(Sprite)) as Sprite; ; break;
                        case 2: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/油漆", typeof(Sprite)) as Sprite; ; break;
                        case 3: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/注射器", typeof(Sprite)) as Sprite; ; break;
                        case 4: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/消毒剂", typeof(Sprite)) as Sprite; ; break;
                        case 5: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/灯泡", typeof(Sprite)) as Sprite; ; break;
                        case 6: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/电池", typeof(Sprite)) as Sprite; ; break;
                        case 7: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/电灯泡", typeof(Sprite)) as Sprite; ; break;
                        case 8: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/药片", typeof(Sprite)) as Sprite; ; break;
                        case 9: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Ham/药瓶", typeof(Sprite)) as Sprite; ; break;
                    }
                    break;
                }
            case 'O':
                {
                    switch (Num)
                    {
                        case 0: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/内衣裤", typeof(Sprite)) as Sprite; ; break;
                        case 1: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/卫生纸", typeof(Sprite)) as Sprite; ; break;
                        case 2: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/口红", typeof(Sprite)) as Sprite; ; break;
                        case 3: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/大骨头", typeof(Sprite)) as Sprite; ; break;
                        case 4: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/打火机", typeof(Sprite)) as Sprite; ; break;
                        case 5: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/烟蒂", typeof(Sprite)) as Sprite; ; break;
                        case 6: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/眼镜", typeof(Sprite)) as Sprite; ; break;
                        case 7: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/胶带", typeof(Sprite)) as Sprite; ; break;
                        case 8: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/陶瓷", typeof(Sprite)) as Sprite; ; break;
                        case 9: gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Garbage34/Dry/雨伞", typeof(Sprite)) as Sprite; ; break;
                    }
                    break;
                }
        }
    }
}
