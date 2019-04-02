using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
    public GameObject Up;
    public GameObject Down;

    float liftHight = 0f;
    float hoverTime = 0f;
    // Start is called before the first frame update
    bool cutFlag = false;
    bool liftFlag = false;
    bool hoverFlag = false;
    bool lowerFlag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (liftFlag)
        {
            if(liftHight < 1f)
            {
                liftHight += Time.deltaTime * 2;
            }
            else
            {
                liftHight = 1f;
                hoverFlag = true;
                liftFlag = false;
            }
            Up.transform.localPosition = new Vector3(0, liftHight);
        }

        if (hoverFlag)
        {
            if(hoverTime < 0.5f)
            {
                hoverTime += Time.deltaTime;
            }
            else
            {
                hoverTime = 0;
                hoverFlag = false;
                lowerFlag = true;
            }
        }

        if (lowerFlag)
        {
            if (liftHight > 0f)
            {
                liftHight -= Time.deltaTime * 2;
            }
            else
            {
                liftHight = 0;
                //hoverFlag = true;
                lowerFlag = false;
            }
            Up.transform.localPosition = new Vector3(0, liftHight);
            
        }
    }

    void Cut()
    {
        if(!liftFlag && !hoverFlag && !lowerFlag)
        {
            liftFlag = true;
        }
        
    }
}
