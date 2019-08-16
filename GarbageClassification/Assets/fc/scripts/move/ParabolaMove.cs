using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaMove : IMove{
    public void Init(GarbageMove gm)
    {
        gm.Vx = gm.X / gm.T;
        gm.Ay = gm.H * 8 / (gm.T * gm.T);
        gm.Vy = 0.5f * gm.Ay * gm.T;
    }

    public void Move(GarbageMove gm)
    {
        gm.transform.localPosition = gm.transform.localPosition + (Vector3.right * gm.Vx + Vector3.up * gm.Vy) * Time.deltaTime;
        
        gm.Vy -= gm.Ay * Time.deltaTime;
    }
    
}
