using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Joystick : MonoBehaviour
{

    //事件
    public Action OnTouchDown;
    public Action<JoystickData> OnTouchMove;
    public Action OnTouchUp;
    public Image image;

    //Untiy 指定参数
    public GameObject joystick;//移动对象
    public float joystickRadius;//移动半径（UGUI像素）
    public Rect touchArea = new Rect(0, 0, 1f, 1f);//0~1

    //data
    public JoystickData data = new JoystickData();

    private Vector3 touchOrigin;//按下原点（Input.mousePosition）
    private float scaleFactor;//Screen 2 Canvas 的转换因子

    private Transform self;
    private Vector3 selfDefaultPosition;
    private Vector3 joystickDefaultLocalPos;//center的默认位置

    private bool isStarted = false;
    private bool isOnArea = false;//是否点击在区域上

    public bool m_enabled = true;//false = 看得见，无法操作

    // Use this for initialization
    void Start()
    {
        self = transform;
        selfDefaultPosition = self.position;

        //获取转换系数
        Canvas canvas = joystick.GetComponentInParent<Canvas>();
        scaleFactor = canvas.scaleFactor;
        Debug.Log(scaleFactor.ToString());

        //转换touchArea
        if (touchArea.width > 1 || touchArea.height > 1)
        {
            touchArea.x = touchArea.x * scaleFactor / Screen.width;
            touchArea.y = touchArea.y * scaleFactor / Screen.height;
            touchArea.width = touchArea.width * scaleFactor / Screen.width;
            touchArea.height = touchArea.height * scaleFactor / Screen.height;
        }
        joystickDefaultLocalPos = joystick.transform.localPosition;
        isStarted = true;

        Enabled = m_enabled;
    }

    public void OnDisable()
    {
        if (isStarted)
            Reset();
    }

    void Update()
    {
        if (!m_enabled)
            return;

        //按下
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y > 1080)
                return;
            else
            {
                TouchDown();
            }
        }

        //拖动
        if (Input.GetMouseButton(0))
        {
            TouchMove();
        }

        //放开
        if (Input.GetMouseButtonUp(0))
        {
            TouchUp();
        }

    }

    private void TouchDown()
    {
        Vector3 touchPosition = Input.mousePosition;
        Vector2 touchScreen = new Vector2(
            touchPosition.x / Screen.width, touchPosition.y / Screen.height);
        isOnArea = touchArea.Contains(touchScreen);
        if (!isOnArea)
            return;
;
        touchOrigin = touchPosition;
        Vector3 vecPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vecPos = new Vector3(vecPos.x, vecPos.y, 110f);
        image.rectTransform.position = vecPos;

        if (OnTouchDown != null)
            OnTouchDown();
    }
    private void TouchMove()
    {
        if (!isOnArea)
            return;

        Vector3 origin = touchOrigin / scaleFactor;
        Vector3 now = Input.mousePosition / scaleFactor;
        float distance = Vector3.Distance(now, origin);
        if (distance < 0.01f)
            return;

        Vector3 direction = now - origin;
        float radians = Mathf.Atan2(direction.y, direction.x);

        //移动摇杆
        if (joystick != null)
        {
            if (distance > joystickRadius)
                distance = joystickRadius;

            float mx = Mathf.Cos(radians) * distance;
            float my = Mathf.Sin(radians) * distance;
            Vector3 uiPos = joystickDefaultLocalPos;
            uiPos.x += mx;
            uiPos.y += my;
            joystick.transform.localPosition = uiPos;
        }

        //派发事件
        if (OnTouchMove != null)
        {
            data.power = distance / joystickRadius;
            data.radians = radians;
            data.angle = radians * Mathf.Rad2Deg;
            data.angle360 = data.angle < 0 ? 360 + data.angle : data.angle;
            OnTouchMove(data);
        }
    }
    private void TouchUp()
    {
        isOnArea = false;
        ReplaceImmediate();


        if (OnTouchUp != null)
            OnTouchUp();
    }

    // 重置状态
    public void Reset()
    {
        isOnArea = false;

        ReplaceImmediate();
    }

    // 立即复位
    public void ReplaceImmediate()
    {

        self.position = selfDefaultPosition;

        joystick.transform.localPosition = joystickDefaultLocalPos;
    }


    // 启用开关（SetActive是彻底看不见，这个是看得见但是无法操作）
    public bool Enabled
    {
        get { return m_enabled; }
        set
        {
            m_enabled = value;

            if (isStarted)
            {
                Reset();
            }
        }
    }

}