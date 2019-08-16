using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesByTime : MonoBehaviour
{
    private Animator animator;
    float interval = 0.97f;
    public float passedTime;
    public bool canPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GameObject.Find("GameObject").transform.Find("Image").GetComponent<DesByTime>().canPlay;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(passedTime > interval)
        {
            this.gameObject.SetActive(false);
            canPlay = false;
        }
        passedTime += Time.deltaTime;
    }
    
}
