using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text GameScore;

    void Start()
    {
        GameScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameScore.text = "得分:"+Game.Score.ToString();
    }
}
