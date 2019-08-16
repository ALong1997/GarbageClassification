using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecRC : MonoBehaviour
{

    public RubbishType rtype;
    public static int Score;

    public enum RubbishType
    {
        干垃圾, 湿垃圾, 可回收垃圾, 有害垃圾
    }

    private void Start()
    {
        int i = Random.Range(0, 10);
        switch (i)
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
    }

    private void Update()
    {
        transform.Rotate(GController.rotate * Time.deltaTime);
        transform.localPosition += new Vector3(0.0f, GController.rubbishSpeed * Time.deltaTime * 40, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = GameObject.Find("GameController");
        if (other.gameObject.tag == "Player")
        {
            if (BgController.btype.ToString() == rtype.ToString())
            {
                Destroy(gameObject);
                Score++;
                GController.goal = true;
                GController.count += 1;
            }
            else
            {
                Destroy(gameObject);
                CommonCtrl.Defeat.GetComponent<DefeatShow>().OneShow(gameObject.GetComponent<Image>().sprite, rtype.ToString());
                other.gameObject.SetActive(false);
                PlayerController.gameOver = true;
            }
        }
    }
}

