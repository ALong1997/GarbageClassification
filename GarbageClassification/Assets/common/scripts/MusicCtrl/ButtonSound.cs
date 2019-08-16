using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public static AudioClip clip;
    public static AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(FindGameObjects.SetOther)
        {
            source.PlayOneShot(clip);
        }
    }
}
