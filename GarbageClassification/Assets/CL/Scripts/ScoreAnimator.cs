using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//加分出现在垃圾暂停位上方，向上移动并淡出

public class ScoreAnimator : MonoBehaviour
{
    public static bool IsScoreAnimator;
    public static bool IsInit;
    public static Vector3 TextPos;
    float Alpha;
    Text ScoreText;
    Vector3 TextSpeed;


    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
        IsInit = true;
        TextSpeed = new Vector3(0, 0.6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsScoreAnimator)
        {
            //动画开始
            if (IsInit)
            {
                ScoreText.text = "+" + Game.AddScore;
                transform.localPosition = TextPos;
                ScoreText.canvasRenderer.SetAlpha(1);
                IsInit = false;
                gameObject.SetActive(true);
                Game.Score += Game.AddScore;
            }

            //动画过程
            transform.localPosition += TextSpeed;
            ScoreText.CrossFadeAlpha(0, 0.5f, false);
            Alpha = ScoreText.canvasRenderer.GetAlpha();


            //动画结束
            if (Alpha <= 0.2)
            {
                IsScoreAnimator = false;
                gameObject.SetActive(false);
                IsInit = true;
                StartAnimator.IsStartAnimator = false;
                if (Game.Level == 10) StaticFunction.GameSuccess();
            }
        }
    }
}
