using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject fbg;
    GameObject ftxt;
    GameObject sbg;
    GameObject stxt;
    Animator animator;
    void Start()
    {
        animator = GameObject.Find("LHXGame").GetComponent<Animator>();
        fbg =   GameObject.Find("LHXGame").transform.Find("AnimationBg").gameObject;
        ftxt = GameObject.Find("LHXGame").transform.Find("AnimationText").gameObject;
        fbg.SetActive(false);
        ftxt.SetActive(false);
        sbg = GameObject.Find("LHXGame").transform.Find("SAnimationBg").gameObject;
        stxt = GameObject.Find("LHXGame").transform.Find("SAnimationText").gameObject;
        sbg.SetActive(false);
        stxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool canPlay = AnimationTimeLHX.canPlay;
       if (PlayerController.gameOver&&canPlay)
        {
            fbg.SetActive(true);
            ftxt.SetActive(true);
            animator.speed = 1f;
        }
       else if (CommonCtrl.isSuccess && canPlay)
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
