using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotate : IRotate
{
    public void Rotate(GarbageMove gm)
    {
        gm.transform.Rotate(new Vector3(0, 0, 360 * Time.deltaTime));
    }
}
