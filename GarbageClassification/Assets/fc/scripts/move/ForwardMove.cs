using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMove : IMove
{
    public void Init(GarbageMove gm)
    {
        gm.Vx = gm.X / gm.T;
        gm.Vy = 0;
    }

    public void Move(GarbageMove gm)
    {
        gm.transform.localPosition = gm.transform.localPosition + Vector3.right * gm.Vx * Time.deltaTime;
    }
}
