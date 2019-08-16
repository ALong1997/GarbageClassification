using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBgMusic : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip_bg;
    public AudioClip clip_1;
    public AudioClip clip_2;
    private int b;
    // Start is called before the first frame update
    void Start()
    {
        b = 0;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(FindGameObjects.SetBg)
        {
            source.mute = false;
        }
        if (!FindGameObjects.SetBg)
        {
            source.mute = true;
        }
        switch (ButtonClick.GameStatus)
        {
            case 0: {
                    source.clip = clip_bg;
                    if (ButtonClick.GameStatus != b)
                    {
                        b = ButtonClick.GameStatus;
                        source.Play();
                    } } break;
            case 1:
                {
                    source.clip = clip_1;
                    if (ButtonClick.GameStatus != b)
                    {
                        b = ButtonClick.GameStatus;
                        source.Play();
                    }
                }
                break;
            case 2:
                {
                    source.clip = clip_1;
                    if (ButtonClick.GameStatus != b)
                    {
                        b = ButtonClick.GameStatus;
                        source.Play();
                    }
                }
                break;
            case 3:
                {
                    source.clip = clip_2;
                    if (ButtonClick.GameStatus != b)
                    {
                        b = ButtonClick.GameStatus;
                        source.Play();
                    }
                }
                break;
            case 4:
                {
                    source.clip = clip_2;
                    if (ButtonClick.GameStatus != b)
                    {
                        b = ButtonClick.GameStatus;
                        source.Play();
                    }
                }
                break;
            case 5:
                {
                    source.clip = clip_1;
                    if (ButtonClick.GameStatus != b)
                    {
                        b = ButtonClick.GameStatus;
                        source.Play();
                    }
                }
                break;
        }
    }

}
