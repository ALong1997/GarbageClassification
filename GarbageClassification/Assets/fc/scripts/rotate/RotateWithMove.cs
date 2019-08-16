using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMove : IRotate
{
    public void Rotate(GarbageMove gm)
    {
        gm.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(gm.Vy, gm.Vx) * 180 / Mathf.PI));
    }
}
