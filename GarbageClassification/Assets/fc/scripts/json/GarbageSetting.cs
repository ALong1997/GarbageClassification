using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSetting{
    private int id;
    private float positionX;
    private float positionY;
    public GarbageSetting() {
        id = 0; positionX = 0; positionY = 0;
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public float PositionX
    {
        get
        {
            return positionX;
        }

        set
        {
            positionX = value;
        }
    }

    public float PositionY
    {
        get
        {
            return positionY;
        }

        set
        {
            positionY = value;
        }
    }
}
