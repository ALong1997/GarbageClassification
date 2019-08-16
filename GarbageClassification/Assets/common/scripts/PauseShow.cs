using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseShow : MonoBehaviour
{
    Image Garbage;
    Text Classification;

    int Num;

    // Start is called before the first frame update
    void Start()
    {
        Garbage = transform.Find("Image/Garbage").GetComponent<Image>();
        Classification = transform.Find("Image/Classification").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        Num = Random.Range(0, 40);
        switch (Num)
        {
            case 0: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/内衣裤", typeof(Sprite)) as Sprite; Classification.text = "内衣裤是干垃圾"; break;
            case 1: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/卫生纸", typeof(Sprite)) as Sprite; Classification.text = "卫生纸是干垃圾"; break;
            case 2: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/口红", typeof(Sprite)) as Sprite; Classification.text = "口红是干垃圾"; break;
            case 3: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/大骨头", typeof(Sprite)) as Sprite; Classification.text = "大骨头是干垃圾"; break;
            case 4: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/打火机", typeof(Sprite)) as Sprite; Classification.text = "打火机是干垃圾"; break;
            case 5: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/烟蒂", typeof(Sprite)) as Sprite; Classification.text = "烟蒂是干垃圾"; break;
            case 6: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/眼镜", typeof(Sprite)) as Sprite; Classification.text = "眼镜是干垃圾"; break;
            case 7: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/胶带", typeof(Sprite)) as Sprite; Classification.text = "胶带是干垃圾"; break;
            case 8: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/陶瓷", typeof(Sprite)) as Sprite; Classification.text = "陶瓷是干垃圾"; break;
            case 9: Garbage.sprite = Resources.Load("Image/Garbage34/Dry/雨伞", typeof(Sprite)) as Sprite; Classification.text = "雨伞是干垃圾"; break;

            case 10: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/剩菜", typeof(Sprite)) as Sprite; Classification.text = "剩菜是湿垃圾"; break;
            case 11: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/果核", typeof(Sprite)) as Sprite; Classification.text = "果核是湿垃圾"; break;
            case 12: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/果皮", typeof(Sprite)) as Sprite; Classification.text = "果皮是湿垃圾"; break;
            case 13: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/树叶", typeof(Sprite)) as Sprite; Classification.text = "树叶是湿垃圾"; break;
            case 14: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/番茄", typeof(Sprite)) as Sprite; Classification.text = "番茄是湿垃圾"; break;
            case 15: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/肉", typeof(Sprite)) as Sprite; Classification.text = "肉是湿垃圾"; break;
            case 16: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/蛋壳", typeof(Sprite)) as Sprite; Classification.text = "蛋壳是湿垃圾"; break;
            case 17: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/蛋糕", typeof(Sprite)) as Sprite; Classification.text = "蛋糕是湿垃圾"; break;
            case 18: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/面包", typeof(Sprite)) as Sprite; Classification.text = "面包是湿垃圾"; break;
            case 19: Garbage.sprite = Resources.Load("Image/Garbage34/Wet/鱼骨", typeof(Sprite)) as Sprite; Classification.text = "鱼骨是湿垃圾"; break;

            case 20: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/书本", typeof(Sprite)) as Sprite; Classification.text = "书本是可回收垃圾"; break;
            case 21: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/塑料瓶", typeof(Sprite)) as Sprite; Classification.text = "塑料瓶是可回收垃圾"; break;
            case 22: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/报纸", typeof(Sprite)) as Sprite; Classification.text = "报纸是可回收垃圾"; break;
            case 23: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/旧包", typeof(Sprite)) as Sprite; Classification.text = "旧包是可回收垃圾"; break;
            case 24: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/旧电器", typeof(Sprite)) as Sprite; Classification.text = "旧电器是可回收垃圾"; break;
            case 25: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/旧衣服", typeof(Sprite)) as Sprite; Classification.text = "旧衣服是可回收垃圾"; break;
            case 26: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/易拉罐", typeof(Sprite)) as Sprite; Classification.text = "易拉罐是可回收垃圾"; break;
            case 27: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/玻璃杯", typeof(Sprite)) as Sprite; Classification.text = "玻璃杯是可回收垃圾"; break;
            case 28: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/玻璃酒瓶", typeof(Sprite)) as Sprite; Classification.text = "玻璃酒瓶是可回收垃圾"; break;
            case 29: Garbage.sprite = Resources.Load("Image/Garbage34/Rec/罐头盒", typeof(Sprite)) as Sprite; Classification.text = "罐头盒是可回收垃圾"; break;

            case 30: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/医疗器具", typeof(Sprite)) as Sprite; Classification.text = "医疗器具是有害垃圾"; break;
            case 31: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/水银体温计", typeof(Sprite)) as Sprite; Classification.text = "水银体温计是有害垃圾"; break;
            case 32: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/油漆", typeof(Sprite)) as Sprite; Classification.text = "油漆是有害垃圾"; break;
            case 33: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/注射器", typeof(Sprite)) as Sprite; Classification.text = "注射器是有害垃圾"; break;
            case 34: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/消毒剂", typeof(Sprite)) as Sprite; Classification.text = "消毒剂是有害垃圾"; break;
            case 35: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/灯泡", typeof(Sprite)) as Sprite; Classification.text = "灯泡是有害垃圾"; break;
            case 36: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/电池", typeof(Sprite)) as Sprite; Classification.text = "电池是有害垃圾"; break;
            case 37: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/电灯泡", typeof(Sprite)) as Sprite; Classification.text = "电灯泡是有害垃圾"; break;
            case 38: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/药片", typeof(Sprite)) as Sprite; Classification.text = "药片是有害垃圾"; break;
            case 39: Garbage.sprite = Resources.Load("Image/Garbage34/Ham/药瓶", typeof(Sprite)) as Sprite; Classification.text = "药瓶是有害垃圾"; break;
        }
    }
}
