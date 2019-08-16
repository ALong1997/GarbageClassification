using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//失败界面：游戏失败调用

public class DefeatShow : MonoBehaviour
{

    public GameObject Image34;
    public GameObject ImageA;
    public GameObject ImageB;
    public GameObject ImageC;
    public GameObject Text12;
    public GameObject Text345;
    public GameObject Text345_;

    Image Image0;
    Image Image1;
    Image Image2;
    Image Image3;
    Text _Text12;
    Text _Text345_;

    public static string DefeatGarbageName;

    // Start is called before the first frame update
    void Start()
    {        
        Image0 = Image34.GetComponent<Image>();
        Image1 = ImageA.GetComponent<Image>();
        Image2 = ImageB.GetComponent<Image>();
        Image3 = ImageC.GetComponent<Image>();
        _Text12 = Text12.GetComponent<Text>();
        _Text345_ = Text345_.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //游戏1和2失败调用
    public void WDYShow()
    {
        _Text12.text = "你用的时间太长了!";

        Image34.SetActive(false);
        ImageA.SetActive(false);
        ImageB.SetActive(false);
        ImageC.SetActive(false);
        Text12.SetActive(true);
        Text345.SetActive(false);
        Text345_.SetActive(false);
    }

    public void ZCDShow()
    {
        _Text12.text = "请提高正确率或者答题速度";

        Image34.SetActive(false);
        ImageA.SetActive(false);
        ImageB.SetActive(false);
        ImageC.SetActive(false);
        Text12.SetActive(true);
        Text345.SetActive(false);
        Text345_.SetActive(false);
    }

    //游戏3和4失败调用
    public void OneShow(Sprite Garbage, string Type)
    {
        Image0.sprite = Garbage;
        _Text345_.text = Garbage.name + "是" + Type;

        Image34.SetActive(true);
        ImageA.SetActive(false);
        ImageB.SetActive(false);
        ImageC.SetActive(false);
        Text12.SetActive(false);
        Text345.SetActive(true);
        Text345_.SetActive(true);
    }

    //游戏5失败调用,Type下标对应规则：0-干、1-湿、2-可回收、3-有害
    public void ThreeShow(Sprite[] GarbageSprites, int[] Type)
    {
        Image1.sprite = GarbageSprites[0];
        Image2.sprite = GarbageSprites[1];
        Image3.sprite = GarbageSprites[2];

        _Text345_.text = "其中:\n\u3000\u3000";
        if (Type[0] != 0) _Text345_.text += Type[0] + "个干垃圾\n\u3000\u3000";
        if (Type[1] != 0) _Text345_.text += Type[1] + "个湿垃圾\n\u3000\u3000";
        if (Type[2] != 0) _Text345_.text += Type[2] + "个可回收垃圾\n\u3000\u3000";
        if (Type[3] != 0) _Text345_.text += Type[3] + "个有害垃圾";

        Image34.SetActive(false);
        ImageA.SetActive(true);
        ImageB.SetActive(true);
        ImageC.SetActive(true);
        Text12.SetActive(false);
        Text345.SetActive(true);
        Text345_.SetActive(true);
    }
}
