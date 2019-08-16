using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimeFC : MonoBehaviour
{
    public static float passedTime = 0;
    public static bool canPlay = true;
    private float timeLimit = 2.5f;
    GameObject fc;
    GameObject defeat;
    GameObject success;
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        fc = GameObject.Find("fcgame");
        parent = transform.parent.parent.gameObject;
        defeat =fc.transform.parent.transform.Find("defeat").gameObject;
        success = parent.transform.Find("success").gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(passedTime);
        if (passedTime > timeLimit&&Main.isFailed)
        {
            canPlay = false;
            GlobalFunction.ChangeUI(fc,defeat);
        }
        if (passedTime > timeLimit && Main.isSuccess)
        {
            canPlay = false;
            GlobalFunction.ChangeUI(fc, success);
        }
        passedTime += Time.deltaTime;
    }
}
