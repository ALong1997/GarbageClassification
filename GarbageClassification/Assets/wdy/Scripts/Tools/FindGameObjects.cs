using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindGameObjects : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public Button WDY;
    public Button ZCD;
    public Button CL;
    public Button LHX;
    public Button FC;


    public static bool SetBg;
    public static bool SetOther;

    // Start is called before the first frame update
    void Start()
    {
        GlobalData.GameStop = transform.Find("pause").gameObject;
        GlobalData.GameSuccess = transform.Find("success").gameObject;
        GlobalData.GameList = transform.Find("select").gameObject;
        ButtonSound.clip = clip;
        ButtonSound.source = source;
        SetBg = true;
        SetOther = true;
        WDY.onClick.AddListener(OnClick);
        ZCD.onClick.AddListener(OnClick);
        CL.onClick.AddListener(OnClick);
        LHX.onClick.AddListener(OnClick);
        FC.onClick.AddListener(OnClick);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        if (SetOther)
        {
            source.PlayOneShot(clip);
        }
    }
}
