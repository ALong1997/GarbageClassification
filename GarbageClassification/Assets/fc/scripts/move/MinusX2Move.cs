using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusX2Move : IMove
{
    public void Init(GarbageMove gm)
    {
        gm.Ay = 2 * gm.H / (gm.T * gm.T);
        gm.Vx = gm.X / gm.T;
        gm.Vy = 0;
    }

    public void Move(GarbageMove gm)
    {
        gm.transform.localPosition = gm.transform.localPosition + (Vector3.right * gm.Vx - Vector3.up * gm.Vy) * Time.deltaTime;
        gm.Vy += gm.Ay * Time.deltaTime;
    }
}
