using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerFC : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject fbg;
    GameObject ftxt;
    GameObject sbg;
    GameObject stxt;
    Animator animator;
    void Start()
    {
        animator = GameObject.Find("fcgame").GetComponent<Animator>();
        fbg = GameObject.Find("fcgame").transform.Find("AnimationBg").gameObject;
        ftxt = GameObject.Find("fcgame").transform.Find("AnimationText").gameObject;
        fbg.SetActive(false);
        ftxt.SetActive(false);
        sbg = GameObject.Find("fcgame").transform.Find("SAnimationBg").gameObject;
        stxt = GameObject.Find("fcgame").transform.Find("SAnimationText").gameObject;
        sbg.SetActive(false);
        stxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Main.isFailed&&AnimationTimeFC.canPlay)
        {
            fbg.SetActive(true);
            ftxt.SetActive(true);
            animator.speed = 1f;
        }else if(Main.isSuccess && AnimationTimeFC.canPlay)
        {
            sbg.SetActive(true);
            stxt.SetActive(true);
            animator.speed = 1f;
        }
        else
        {
            fbg.SetActive(false);
            ftxt.SetActive(false);
            sbg.SetActive(false);
            stxt.SetActive(false);
            animator.speed = 0f;
        }
    }
}
