using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerCL : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject fbg;
    GameObject ftxt;
    GameObject sbg;
    GameObject stxt;
    Animator animator;
    void Start()
    {
        animator = GameObject.Find("CLGame").GetComponent<Animator>();
        fbg = GameObject.Find("CLGame").transform.Find("animationBg").gameObject;
        ftxt = GameObject.Find("CLGame").transform.Find("animationText").gameObject;
        fbg.SetActive(false);
        ftxt.SetActive(false);
        sbg = GameObject.Find("CLGame").transform.Find("SAnimationBg").gameObject;
        stxt = GameObject.Find("CLGame").transform.Find("SAnimationText").gameObject;
        sbg.SetActive(false);
        stxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Game.isFailed&&AnimationTimeCL.canPlay)
        {
            fbg.SetActive(true);
           ftxt.SetActive(true);
            animator.speed = 1f;
        }
        else if (Game.isSuccess && AnimationTimeCL.canPlay)
        {
            sbg.SetActive(true);
            stxt.SetActive(true);
            animator.speed = 1f;
        }
        else 
        {
            sbg.SetActive(false);
            stxt.SetActive(false);
            fbg.SetActive(false);
            ftxt.SetActive(false);
            animator.speed = 0f;
        }
    }
}
