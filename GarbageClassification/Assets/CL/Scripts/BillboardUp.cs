using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//公示牌上升碰到垃圾桶，垃圾和垃圾桶复位，计算得分

public class BillboardUp : MonoBehaviour
{
    float GarbageTop;

    //垃圾复位消失，公示牌复位
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GarbageTop = collision.transform.localPosition.y;
        ScoreAnimator.TextPos = collision.transform.localPosition;
        Destroy(collision.gameObject);
        Game.BillboardClick.GetComponent<Move>().IsRise = false;
        Game.BillboardClick.transform.localPosition = Game.BillboardPos;
        Game.IsBillboardMove = false;

        //操作正确则加分，否则游戏结束
        if (Game.GarbageType != Game.LineType)
        {
            if (GarbageTop > -250) Game.AddScore = 10;
            else if (GarbageTop > -500) Game.AddScore = 8;
            else Game.AddScore = 6;

            //进入下一关
            Game.Level++;
            ScoreAnimator.IsInit = true;
            ScoreAnimator.IsScoreAnimator = true;
            Game.AddScoreChoose.SetActive(true);
        }
        else StaticFunction.GameDefeat();
    }
}
