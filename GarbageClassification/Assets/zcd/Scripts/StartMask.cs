using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMask : MonoBehaviour
{
   // private float dispearTime = 1f;
   // public float passedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartAnimator.IsStartAnimator)
        {
            this.gameObject.SetActive(false);
        }
    }
}
