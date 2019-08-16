using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetButtonBg : MonoBehaviour, IPointerDownHandler
{
    public Button btn;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (FindGameObjects.SetBg)
        {
            GlobalFunction.SaveSet("BGM1", 0);
            FindGameObjects.SetBg = false;
            btn.GetComponent<Image>().sprite = Resources.Load("Image/Option/关", typeof(Sprite)) as Sprite;
        }
           
        else
        {
            GlobalFunction.SaveSet("BGM1", 1);
            FindGameObjects.SetBg = true;
            btn.GetComponent<Image>().sprite = Resources.Load("Image/Option/开", typeof(Sprite)) as Sprite;
        }
    }
}
