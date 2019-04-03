using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private bool pressedFlag = false;
    private bool EnterFlag = false;
    public int layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressedFlag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pressedFlag = false;
            EnterFlag = false;
        }
    }


    void OnMouseEnter()
    {
        //isShowTip = true;
        if (pressedFlag)
        {
            EnterFlag = true;
            Debug.Log("Mouse Enter");//可以得到物体的名字
        }
        

    }

    private void OnMouseExit()
    {
        Debug.Log("In Mouse Exit");
        //EnterFlag = false;
    }

    void EnterCore()
    {
        Debug.Log("In Enter Core! EnterFlag: " + EnterFlag);

        if (EnterFlag)
        {
            Debug.Log("A successful SLIDE!");
            SendMessageUpwards("Cut",layer);
            EnterFlag = false;
        }
    }
}
