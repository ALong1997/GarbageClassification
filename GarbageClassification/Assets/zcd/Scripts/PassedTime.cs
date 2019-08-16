using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassedTime : MonoBehaviour {
    public static int time = 0;
    private float timeInterval;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Text>().text = "0000" ;
	}
	
	// Update is called once per frame
	void Update () {
        bool isStartAnimation = StartAnimator.IsStartAnimator;
        //float colorIndex = GameObject.Find("GameObject").transform.Find("Go").gameObject.GetComponent<TextFadeOut>().colorIndex;
        // print(colorIndex);
        if (!isStartAnimation)
        {
           // print("我开始运行了");
            if (timeInterval > 0.001&&!Qnum.Stop)
            {
                time += 1;
                if (time < 10)
                {
                    this.gameObject.GetComponent<Text>().text = "000" + time.ToString();
                }
                else if (time < 100)
                {
                    this.gameObject.GetComponent<Text>().text = "00" + time.ToString();
                }
                else if (time < 1000)
                {
                    this.gameObject.GetComponent<Text>().text = "0" + time.ToString();
                }
                else if (time > 9999)
                {
                    this.gameObject.GetComponent<Text>().text = "9999";
                }
                else
                {
                    this.gameObject.GetComponent<Text>().text = time.ToString();
                }

                timeInterval = 0;
            }
            timeInterval += Time.deltaTime;

        }
    }
}
