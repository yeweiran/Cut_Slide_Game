using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
    public GameObject Layer1;
    public GameObject Layer2;

    float L1liftHight = 0f;
    float L2liftHight = 0f;
    float L1hoverTime = 0f;
    float L2hoverTime = 0f;
    // Start is called before the first frame update
    bool L1cutFlag = false;
    bool L1liftFlag = false;
    bool L1hoverFlag = false;
    bool L1lowerFlag = false;
    bool L2cutFlag = false;
    bool L2liftFlag = false;
    bool L2hoverFlag = false;
    bool L2lowerFlag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ////Layer1
        ///
        if (L1liftFlag)
        {
            if(L1liftHight < 1f)
            {
                L1liftHight += Time.deltaTime * 2;
            }
            else
            {
                L1liftHight = 1f;
                L1hoverFlag = true;
                L1liftFlag = false;
            }
            Layer1.transform.localPosition = new Vector3(0, L1liftHight);
        }

        if (L1hoverFlag)
        {
            if(L1hoverTime < 0.5f)
            {
                L1hoverTime += Time.deltaTime;
            }
            else
            {
                L1hoverTime = 0;
                L1hoverFlag = false;
                L1lowerFlag = true;
            }
        }

        if (L1lowerFlag)
        {
            if (L1liftHight > 0f)
            {
                L1liftHight -= Time.deltaTime * 2;
            }
            else
            {
                L1liftHight = 0;
                //hoverFlag = true;
                L1lowerFlag = false;
            }
            Layer1.transform.localPosition = new Vector3(0, L1liftHight);
            
        }

        ////Layer2
        ///
        if (L2liftFlag)
        {
            if (L2liftHight < 1f)
            {
                L2liftHight += Time.deltaTime * 2;
            }
            else
            {
                L2liftHight = 1f;
                L2hoverFlag = true;
                L2liftFlag = false;
            }
            Layer2.transform.localPosition = new Vector3(0, L2liftHight);
        }

        if (L2hoverFlag)
        {
            if (L2hoverTime < 0.5f)
            {
                L2hoverTime += Time.deltaTime;
            }
            else
            {
                L2hoverTime = 0;
                L2hoverFlag = false;
                L2lowerFlag = true;
            }
        }

        if (L2lowerFlag)
        {
            if (L2liftHight > 0f)
            {
                L2liftHight -= Time.deltaTime * 2;
            }
            else
            {
                L2liftHight = 0;
                //hoverFlag = true;
                L2lowerFlag = false;
            }
            Layer2.transform.localPosition = new Vector3(0, L2liftHight);

        }
    }

    void Cut(int layer)
    {
        if(layer == 1)
        {
            if (!L1liftFlag && !L1hoverFlag && !L1lowerFlag)
            {
                L1liftFlag = true;
            }
        }
        else
        {
            if (!L2liftFlag && !L2hoverFlag && !L2lowerFlag)
            {
                L2liftFlag = true;
            }
        }      
        
    }
}
