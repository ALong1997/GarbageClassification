using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour
{
    public static bool gameOver = false;
    private Vector3 worldPos;
    private Vector3 origin;
    private Vector3 player;

    public Image image;
    public Sprite dry;
    public Sprite wet;
    public Sprite recyclable;
    public Sprite harmful;
    public static PlayerType btype;
    public GameObject sImage;
    //public GameObject Range;

    public enum PlayerType
    {
        Dry,Wet,Recyclable,Hamful
    }

    private void Start()
    {
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        //Debug.Log(Range.transform.GetComponent<RectTransform>().sizeDelta.x);
    }

    private void Update()
    {
        if(!gameOver)
        {
            if (Input.mousePosition.y > 1120)
                return;
            else
            {
                if (Input.GetMouseButtonDown(0))
                    TouchDown();
                if (Input.GetMouseButton(0))
                    TouchMove();
            }
            
        }
        if(GController.goal)
        {
            GameObject effect = Instantiate(sImage);
            GameObject Trash = GameObject.Find("Trash");
            effect.transform.SetParent(Trash.transform);
            effect.transform.localScale = new Vector3(1, 1, 1);
            effect.transform.localPosition = new Vector3(0,77,0);
            effect.GetComponent<Text>().CrossFadeAlpha(0, 0.5f, true);
            GController.goal = false;
        }
        
    }

    private void TouchDown()
    {      
        player = transform.localPosition;
        Vector3 touchPos = Input.mousePosition;
        origin = touchPos; 
    }
    private void TouchMove()
    {
        
        Vector3 touchNowPos = Input.mousePosition;
        Vector3 move = new Vector3
            (
            player.x + (touchNowPos.x - origin.x),
            player.y + (touchNowPos.y - origin.y),
            0
            );
        if (move.x < -255)
            move.x = -255;
        if (move.x > 255)
            move.x = 255;
        if (move.y < -475)
            move.y = -475;
        if (move.y > 475)
            move.y = 475;
        transform.localPosition = new Vector3(move.x, move.y, 0);
        //transform.localPosition = new Vector3(move.x, move.y, 0f);            
    }

    public void TrashColour(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Dry: { image.sprite = dry; }break;
            case PlayerType.Wet: { image.sprite = wet; }break;
            case PlayerType.Recyclable: { image.sprite = recyclable; }break;
            case PlayerType.Hamful: { image.sprite = harmful; }break;
        }
            

    }
}
