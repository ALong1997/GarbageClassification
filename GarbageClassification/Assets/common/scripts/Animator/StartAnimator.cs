using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//游戏开始时“ReadyGo”图片缩小动画

public class StartAnimator : MonoBehaviour
{
    public static Sprite Ready;

    public static bool IsStartAnimator;

    Vector2 ImageScale;
    Sprite Go;
    public bool IsReady;
    // Start is called before the first frame update
    void Start()
    {
        Ready = Resources.Load("Image/ready", typeof(Sprite)) as Sprite;
        Go = Resources.Load("Image/go", typeof(Sprite)) as Sprite;
        GetComponent<Image>().sprite = Ready;

        IsReady = true;
        IsStartAnimator = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStartAnimator)
        {
            ImageScale = transform.localScale;
            ImageScale.x -= 0.015f * Time.deltaTime * 50;
            ImageScale.y -= 0.015f * Time.deltaTime * 50;
            transform.localScale = ImageScale;

            if (ImageScale.x < 0.4)
            {
                if (IsReady)
                {
                    GetComponent<Image>().sprite = Go;
                    transform.localScale = Vector2.one;
                    IsReady = false;
                }
                else
                {
                    IsReady = true;
                    IsStartAnimator = false;
                    GetComponent<Image>().sprite = Ready;
                    transform.localScale = Vector2.one;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
