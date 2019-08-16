using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManger : MonoBehaviour
{

    public Joystick joystick;
    public Transform moveTarget;
    public float moveSpeed;


    void Start()
    {
        joystick.OnTouchMove += OnJoystickMove;
    }

    private void OnJoystickMove(JoystickData joystickData)
    {
        if (PlayerController.gameOver)
        {
            joystick.m_enabled = false;
        }
        else
        {
            float moveX = Mathf.Cos(joystickData.radians) * moveSpeed *
            Time.deltaTime * joystickData.power;
            float moveY = Mathf.Sin(joystickData.radians) * moveSpeed *
                Time.deltaTime * joystickData.power;
            moveTarget.Translate(new Vector3(moveX, moveY, 0));
        }
    }
}
