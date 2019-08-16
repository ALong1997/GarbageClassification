using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCtrl : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.localPosition += new Vector3(0.0f,speed,0.0f);
    }
}
