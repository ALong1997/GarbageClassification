using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetButtonOther : MonoBehaviour, IPointerDownHandler
{
    public Button btn;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (FindGameObjects.SetOther)
        {
            GlobalFunction.SaveSet("BGM2", 0);
            FindGameObjects.SetOther = false;
            btn.GetComponent<Image>().sprite = Resources.Load("Image/Option/关", typeof(Sprite)) as Sprite;
        }
           
        else
        {
            GlobalFunction.SaveSet("BGM2", 1);
            FindGameObjects.SetOther = true;
            btn.GetComponent<Image>().sprite = Resources.Load("Image/Option/开", typeof(Sprite)) as Sprite;
        }

    }
}
