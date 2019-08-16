using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeOut : MonoBehaviour
{
    public float speed = 0.5f;
    Text text;
    public Color color;
    public float colorIndex =1;


    void Start()
    {


        text = GetComponent<Text>();
        color = text.color;
    }

    void Update()
    {


        if (gameObject.activeSelf)
        { 
            if(color.a < 0.5)
            {
                colorIndex = 6;
            }
            color.a -= Time.deltaTime * speed;
            text.color = color;
            colorIndex = color.a;
            //print(color.a + "color.a");
            //print(color + "color");
        }

    }

}
