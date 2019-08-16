using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimeLHX : MonoBehaviour
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

        if (passedTime > timeLimit&PlayerController.gameOver)
        {
            canPlay = false;
            GlobalFunction.ChangeUI(CommonCtrl.LHXGame, CommonCtrl.Defeat);
        }
        if (passedTime > timeLimit & CommonCtrl.isSuccess)
        {
            canPlay = false;
            GlobalFunction.ChangeUI(CommonCtrl.LHXGame, CommonCtrl.Success);
        }
        passedTime += Time.deltaTime;
    }
}