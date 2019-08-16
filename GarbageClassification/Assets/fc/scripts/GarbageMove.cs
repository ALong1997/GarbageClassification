using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageMove : MonoBehaviour {
    private float x;
    private float h;
    private float t;
    private float vx;
    private float vy;
    private float ay;
    private float delayTime;
    private float stopPos;
    private bool pause;
    private Vector3 v;
    private IMove imove;
    private IRotate irotate;
    public float T
    {
        get
        {
            return t;
        }

        set
        {
            t = value;
        }
    }

    public float DelayTime
    {
        get
        {
            return delayTime;
        }

        set
        {
            delayTime = value;
        }
    }

    public float X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    public float H
    {
        get
        {
            return h;
        }

        set
        {
            h = value;
        }
    }

    public float StopPos
    {
        get
        {
            return stopPos;
        }

        set
        {
            stopPos = value;
        }
    }

    public Vector3 V
    {
        get
        {
            return v;
        }

        set
        {
            v = value;
        }
    }

    internal IMove Imove
    {
        get
        {
            return imove;
        }

        set
        {
            imove = value;
        }
    }

    public float Vx
    {
        get
        {
            return vx;
        }

        set
        {
            vx = value;
        }
    }

    public float Vy
    {
        get
        {
            return vy;
        }

        set
        {
            vy = value;
        }
    }


    public float Ay
    {
        get
        {
            return ay;
        }

        set
        {
            ay = value;
        }
    }

    internal IRotate Irotate
    {
        get
        {
            return irotate;
        }

        set
        {
            irotate = value;
        }
    }

    public bool Pause
    {
        get
        {
            return pause;
        }

        set
        {
            pause = value;
        }
    }



    // Use this for initialization
    void Start () {
        pause = false;
        //imove.Init(this);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (pause) { return; }
        if (delayTime > 0)
        {
            delayTime -= Time.deltaTime;
            return;
        }
        //print(transform.position);
        //imove.Move(this);
        //irotate.Rotate(this);
        //CheckActive();
    }
    private void CheckActive() {
        
        if (transform.localPosition.x > stopPos) {
            gameObject.SetActive(false);
        }
    }
    
}
