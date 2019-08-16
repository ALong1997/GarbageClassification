using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public float speed = 0.7f;
    Text text;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        color = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        color.a -= Time.deltaTime * speed;
        text.color = color;
    }
}
