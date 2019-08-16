using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTime : MonoBehaviour
{
    public static float passedTime = 0;
    public static bool canPlay = true;
    private float timeLimit = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(passedTime > timeLimit&&Qnum.TimeStop)
        {
            canPlay = false;
            GlobalFunction.ChangeUI(Related2Uis.ZCDGame, Related2Uis.Defeat);
        }
        else if (passedTime > timeLimit && Qnum.isSuccess)
        {
            canPlay = false;
            GlobalFunction.ChangeUI(Related2Uis.ZCDGame, Related2Uis.Success);
        }
        passedTime += Time.deltaTime;
    }
}
