using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerWDY : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject fbg;
    GameObject ftxt;
    GameObject sbg;
    GameObject stxt;
    Animator animator;
    void Start()
    {
        animator = GameObject.Find("PuzzlePanel").GetComponent<Animator>();
        fbg = GameObject.Find("PuzzlePanel").transform.Find("AnimationBg").gameObject;
        ftxt = GameObject.Find("PuzzlePanel").transform.Find("AnimationText").gameObject;
        sbg = GameObject.Find("PuzzlePanel").transform.Find("SAnimationBg").gameObject;
        stxt = GameObject.Find("PuzzlePanel").transform.Find("SAnimationText").gameObject;
        fbg.SetActive(false);
        ftxt.SetActive(false);
        sbg.SetActive(false);
        stxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //print(AnimationTimeWDY.canPlay);
        if (GameController.isFailed && AnimationTimeWDY.canPlay)
        {
            fbg.SetActive(true);
            ftxt.SetActive(true);
            animator.speed = 1f;
        }
        else if (GameController.isSuccess && AnimationTimeWDY.canPlay)
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
