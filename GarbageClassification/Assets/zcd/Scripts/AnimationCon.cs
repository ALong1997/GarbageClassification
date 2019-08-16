using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCon : MonoBehaviour
{
    private Animator animator;
    public GameObject animationBg;
    public GameObject animationText;
    public GameObject sanimationBg;
    public GameObject sanimationText;
    // public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("GameObject").GetComponent<Animator>();
        // GetComponent<Animation>().Play("Animation1"); 
        animationBg.SetActive(false);
        animationText.SetActive(false);
        sanimationBg.SetActive(false);
        sanimationText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //print(GameObject.Find("GameObject").transform.Find("Image"));
        bool canPlay = AnimationTime.canPlay;
        if (canPlay && Qnum.TimeStop)
        {
            animationBg.SetActive(true);
            animationText.SetActive(true);
            //anim.Play();
            animator.speed = 1f;
        }
        else if ( canPlay && Qnum.isSuccess)
        {
            sanimationBg.SetActive(true);
            sanimationText.SetActive(true);
            //anim.Play();
            animator.speed = 1f;
        }
        else if(Qnum.QNumber == 10 && !canPlay)
        {
            animationBg.SetActive(false);
            animationText.SetActive(false);
            sanimationBg.SetActive(false);
            sanimationText.SetActive(false);
            animator.speed = 0.0f;
        }
        else
        {
            animator.speed = 0;
        }
    }
}
