using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DryRC : MonoBehaviour
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
    }

    private void Update()
    {
        transform.Rotate(GController.rotate * Time.deltaTime);
        transform.localPosition += new Vector3(0.0f, GController.rubbishSpeed * Time.deltaTime * 40, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = GameObject.Find("GameController");
        GameObject trash = GameObject.Find("Trash");
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
                CommonCtrl.Defeat.GetComponent<DefeatShow>().OneShow(gameObject.GetComponent<Image>().sprite, rtype.ToString());

                Destroy(gameObject);
                
                other.gameObject.SetActive(false);

                PlayerController.gameOver = true;
            }
        }
    }
}
