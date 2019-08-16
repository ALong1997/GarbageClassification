using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitSet : MonoBehaviour
{
    public GameObject setUI;
    /// <summary>
    /// 跳转到游戏设置界面
    /// </summary>

    public void QuitSetUI()
    {
        OnClick();
        setUI.SetActive(false);
    }
    public void OnClick()
    {
        if (FindGameObjects.SetOther)
        {
            ButtonSound.source.PlayOneShot(ButtonSound.clip);
        }
    }
}
