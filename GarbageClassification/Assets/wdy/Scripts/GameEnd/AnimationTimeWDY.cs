using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimeWDY : MonoBehaviour
{
    public static float passedTime = 0;
    public static bool canPlay = true;
    private float timeLimit = 2.5f;
    public GameObject game;
    GameObject de;
    GameObject su;
    // Start is called before the first frame update
    void Start()
    {
        de=game.transform.parent.transform.Find("defeat").gameObject;
        su=game.transform.parent.transform.Find("success").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //print(passedTime);
        if (passedTime > timeLimit)
        {
            canPlay = false;

            if (GameController.isFailed)
            {
                de.GetComponent<DefeatShow>().WDYShow();
                GlobalFunction.ChangeUI(game, de);
            }
            if(GameController.isSuccess) GlobalFunction.ChangeUI(game, su);
        }
        passedTime += Time.deltaTime;
    }
}
