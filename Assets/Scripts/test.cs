using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private bool pressedFlag = false;
    private bool EnterFlag = false;
    public int layer;
    public int dir;
    private Vector2 touchFirst = Vector2.zero;
    private Vector2 touchSecond = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && EnterFlag)
        {
            touchFirst = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pressedFlag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (pressedFlag)
            {
                touchSecond = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if(dir == 0)
                {
                    if(touchSecond.x - touchFirst.x > 1)
                    {
                        SuccessSlide();
                    }
                }
                else
                {
                    if (touchSecond.x - touchFirst.x < -1)
                    {
                        SuccessSlide();
                    }
                }
            }
            pressedFlag = false;
            //EnterFlag = false;
        }
    }

    void OnMouseEnter()
    {
        //isShowTip = true;
        //if (pressedFlag)
        //{
        //    EnterFlag = true;
        //    Debug.Log("Mouse Enter");//可以得到物体的名字
        //}
        EnterFlag = true;
    }

    private void OnMouseExit()
    {
        //Debug.Log("In Mouse Exit");
        EnterFlag = false;
    }

    void SuccessSlide()
    {
        //Debug.Log("A successful SLIDE!");
        SendMessageUpwards("Cut", layer);
    }

    //void EnterCore()
    //{
    //    Debug.Log("In Enter Core! EnterFlag: " + EnterFlag);

    //    if (EnterFlag)
    //    {
    //        Debug.Log("A successful SLIDE!");
    //        SendMessageUpwards("Cut",layer);
    //        EnterFlag = false;
    //    }
    //}
}
