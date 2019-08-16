using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SuccessPanelController : MonoBehaviour
{
    public RectTransform[] Stars;
    public Text ScoreText;
    private int Num = 0;
    private float PastTime;
    private bool ShowOver = false;

    private void OnEnable()
    {
       // ScoreText.text = GlobalData.ShowText;

    }
    // Start is called before the first frame update
    void Start()
    {
        //ScoreText.text = GlobalData.ShowText;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShowOver)
        {
            //ShowStars();



        }
    }

    private void ShowStars()
    {
        PastTime += Time.deltaTime;
        if (PastTime >= 0.5f)
        {
            if (Num < GlobalData.Grade)
            {
                Stars[Num].gameObject.SetActive(true);
                Stars[Num].DOScale(Vector2.one, 0.5f);
                Num++;
                PastTime = 0;
                if (Num >= Stars.Length)
                {
                    ShowOver = true;
                }
            }
            else
            {
                Stars[Num].gameObject.SetActive(true);
                if (Num == 1)
                {
                    Stars[Num].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/FailBig");
                }
                else
                {
                    Stars[Num].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/FailSmall");
                }
                Stars[Num].localScale = Vector2.one;
                Num++;
                PastTime = 0;
                if (Num >= Stars.Length)
                {
                    ShowOver = true;
                }
            }
        }
    }
}
