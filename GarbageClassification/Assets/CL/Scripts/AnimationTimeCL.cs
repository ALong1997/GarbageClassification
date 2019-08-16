using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimeCL : MonoBehaviour
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
        //print(passedTime);
        if (passedTime > timeLimit&&Game.isFailed)
        {
            canPlay = false;
            GlobalFunction.ChangeUI(Game.CLGame, Game.Defeat);
        }
        if (passedTime > timeLimit && Game.isSuccess)
        {
            canPlay = false;
            GlobalFunction.ChangeUI(Game.CLGame, Game.Success);
        }
        passedTime += Time.deltaTime;
    }
}
