using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//游戏合集运行时，加载存档数据
public class LoadData : MonoBehaviour
{
    public Image BGM1;
    public Image BGM2;
    public Text AllStar;
    public GameObject Game1;
    public GameObject Game2;
    public GameObject Game3;
    public GameObject Game4;
    public GameObject Game5;

    // Start is called before the first frame update
    void Start()
    {
        //测试用
        //PlayerPrefs.DeleteAll();


        //开始界面星星总数
        AllStar.text = "X" + (PlayerPrefs.GetInt("Star1", 0) + PlayerPrefs.GetInt("Star2", 0) + PlayerPrefs.GetInt("Star3", 0) + PlayerPrefs.GetInt("Star4", 0) + PlayerPrefs.GetInt("Star5", 0));
        
        //加载设置
        if (PlayerPrefs.GetInt("BGM1", 1) == 1)
        {
            FindGameObjects.SetBg = true;
            BGM1.sprite = Resources.Load("Image/Option/开", typeof(Sprite)) as Sprite;
        }
        else
        {
            FindGameObjects.SetBg = false;
            BGM1.sprite = Resources.Load("Image/Option/关", typeof(Sprite)) as Sprite;
        }
        if (PlayerPrefs.GetInt("BGM2", 1) == 1)
        {
            FindGameObjects.SetOther = true;
            BGM2.sprite = Resources.Load("Image/Option/开", typeof(Sprite)) as Sprite;
        }
        else
        {
            FindGameObjects.SetOther = false;
            BGM2.sprite = Resources.Load("Image/Option/关", typeof(Sprite)) as Sprite;
        }

        //加载选择界面各游戏的星星数
        for (int i = 1; i <= PlayerPrefs.GetInt("PlayGame", 1); i++)
        {
            GameObject Game;
            switch (i)
            {
                case 5: Game = Game5; break;
                case 4: Game = Game4; break;
                case 3: Game = Game3; break;
                case 2: Game = Game2; break;
                case 1:
                default: Game = Game1; break;
            }
            switch (PlayerPrefs.GetInt(("Star" + i), 0))
            {
                case 3: Game.transform.Find("Star/Star1/Star").gameObject.SetActive(true); Game.transform.Find("Star/Star2/Star").gameObject.SetActive(true); Game.transform.Find("Star/Star3/Star").gameObject.SetActive(true); break;
                case 2: Game.transform.Find("Star/Star1/Star").gameObject.SetActive(true); Game.transform.Find("Star/Star2/Star").gameObject.SetActive(true); break;
                case 1: Game.transform.Find("Star/Star1/Star").gameObject.SetActive(true); break;
                case 0:
                default: break;
            }
        }

        GameLock();
    }

    //解锁功能
    public void GameLock()
    {
        int AllStar = PlayerPrefs.GetInt("Star1", 0) + PlayerPrefs.GetInt("Star2", 0) + PlayerPrefs.GetInt("Star3", 0) + PlayerPrefs.GetInt("Star4", 0) + PlayerPrefs.GetInt("Star5", 0);
        if (AllStar >= 2)
        {
            PlayerPrefs.SetInt("PlayGame", 2);
            Game2.transform.Find("Mask").gameObject.SetActive(false);
            Game2.transform.Find("Star").gameObject.SetActive(true);
            Game2.GetComponent<Button>().interactable = true;
        }
        if (AllStar >= 4)
        {
            PlayerPrefs.SetInt("PlayGame", 3);
            Game3.transform.Find("Mask").gameObject.SetActive(false);
            Game3.transform.Find("Star").gameObject.SetActive(true);
            Game3.GetComponent<Button>().interactable = true;
        }
        if (AllStar >= 7)
        {
            PlayerPrefs.SetInt("PlayGame", 4);
            Game4.transform.Find("Mask").gameObject.SetActive(false);
            Game4.transform.Find("Star").gameObject.SetActive(true);
            Game4.GetComponent<Button>().interactable = true;
        }
        if (AllStar >= 10)
        {
            PlayerPrefs.SetInt("PlayGame", 5);
            Game5.transform.Find("Mask").gameObject.SetActive(false);
            Game5.transform.Find("Star").gameObject.SetActive(true);
            Game5.GetComponent<Button>().interactable = true;
        }
    }

    //清楚存档
    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }

    //测试用外挂
    public void MaxStar()
    {
        PlayerPrefs.SetInt("Star1", 3);
        PlayerPrefs.SetInt("Star2", 3);
        PlayerPrefs.SetInt("Star3", 3);
        PlayerPrefs.SetInt("Star4", 3);
        PlayerPrefs.SetInt("Star5", 3);
    }
}
