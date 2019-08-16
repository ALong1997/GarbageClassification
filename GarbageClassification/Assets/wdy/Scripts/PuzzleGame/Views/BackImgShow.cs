using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackImgShow : MonoBehaviour
{
    private Text ThText;
    private Text HuText;
    private Text TenText;
    private Text UnitText;
    private int TimeNum;
    public bool IsStop;
    private GameController GC;
    //private List<int> Nums;
    //private List<Text> Texts; 

    // Start is called before the first frame update
    void Start()
    {
        //Nums = new List<int>() { 0, 0, 0, 0 };
        //Texts = new List<Text>();
        GameObject go = GameObject.Find("GameControl");
        GC = go.GetComponent<GameController>();
        IsStop = GC.IsStop;
        //timeNum = gc.useTimeInt;
        ThText = transform.Find("ThText").GetComponent<Text>();
        HuText = transform.Find("HuText").GetComponent<Text>();
        TenText = transform.Find("TenText").GetComponent<Text>();
        UnitText = transform.Find("UnitsText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsStop)
        {
            Show();
        }
            

    }

    public void Show()
    {
        TimeNum = GC.UseTimeInt;

        //for (int i = 0; TimeNum > 0; i++)
        //{
        //    Nums[i] = TimeNum % 10;
        //    Texts[i].text = Nums[i].ToString();
        //    TimeNum /= 10;
        //}



        int thousand = TimeNum / 1000;
        int hundred = (TimeNum % 1000) / 100;
        int ten = ((TimeNum % 1000) % 100) / 10;
        int unit = TimeNum % 10;

        ThText.text = thousand.ToString();
        HuText.text = hundred.ToString();
        TenText.text = ten.ToString();
        UnitText.text = unit.ToString();

    }
}
