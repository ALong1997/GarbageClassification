using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetting{
    private int id;
    private int exclude;
    private int garbageNum;
    private float runTime;
    private int startId;
    private int endId;
    public LevelSetting() {
        id = 0; exclude = 0; garbageNum = 0; runTime = 0; startId = 0; endId = 0;
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

    public int StartId
    {
        get
        {
            return startId;
        }

        set
        {
            startId = value;
        }
    }

    public int EndId
    {
        get
        {
            return endId;
        }

        set
        {
            endId = value;
        }
    }

    public int Exclude
    {
        get
        {
            return exclude;
        }

        set
        {
            exclude = value;
        }
    }

    public int GarbageNum
    {
        get
        {
            return garbageNum;
        }

        set
        {
            garbageNum = value;
        }
    }


    public float RunTime
    {
        get
        {
            return runTime;
        }

        set
        {
            runTime = value;
        }
    }
}
