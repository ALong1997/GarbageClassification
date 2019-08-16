using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSoundCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindGameObjects.SetOther)
        {
            GetComponent<AudioSource>().mute = false;
        }
        if (!FindGameObjects.SetOther)
        {
            GetComponent<AudioSource>().mute = true;
        }
    }
}
