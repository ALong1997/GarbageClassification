using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//垃圾掉进垃圾桶的情况

public class InBarbageCan: MonoBehaviour
{
    //垃圾碰到垃圾桶
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StaticFunction.CloseButton();

        if (Game.GarbageType == Game.LineType)
        //正确操作加分
        {
            Game.AddScore = 10;
            Game.Level++;
            ScoreAnimator.TextPos = collision.transform.localPosition;
            ScoreAnimator.IsInit = true;
            ScoreAnimator.IsScoreAnimator = true;
            Game.AddScoreChoose.SetActive(true);
        }
        else
        //错误操作结束
        {
            collision.GetComponent<Move>().IsDrop = false;
            StaticFunction.GameDefeat();
        }
    }


    //正确操作，垃圾进入垃圾后进入下一关
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}

