using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
    //public GameObject Layer1;
    //public GameObject Layer2;
    public GameObject[] LayerList;

    //float L1liftHight = 0f;
    //float L2liftHight = 0f;
    //float L1hoverTime = 0f;
    //float L2hoverTime = 0f;

    float[] liftHightList = { 0f, 0f };
    float[] hoverTimeList = { 0f, 0f };
    // Start is called before the first frame update
    //bool L1cutFlag = false;
    //bool[] cutFlagList = { false, false };
    //bool L1liftFlag = false;
    //bool L1hoverFlag = false;
    //bool L1lowerFlag = false;
    //bool L2cutFlag = false;
    //bool L2liftFlag = false;
    //bool L2hoverFlag = false;
    //bool L2lowerFlag = false;

    bool[] liftFlagList = { false, false };
    bool[] hoverFlagList = { false, false };
    bool[] lowerFlagList = { false, false };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ////Layer1
        ///
        for(int layer = 0; layer < 2; layer++)
        {
            if (liftFlagList[layer])
            {
                if (liftHightList[layer] < 1f)
                {
                    //liftHightList[layer] += Time.deltaTime * 2;
                    liftHightList[layer] += Time.deltaTime * Mathf.Pow((4 * (1f - liftHightList[layer])),2);
                    liftHightList[layer] += Time.deltaTime;
                }
                else
                {
                    liftHightList[layer] = 1f;
                    hoverFlagList[layer] = true;
                    liftFlagList[layer] = false;
                }
                LayerList[layer].transform.localPosition = new Vector3(0, liftHightList[layer]);
            }

            if (hoverFlagList[layer])
            {
                if (hoverTimeList[layer] < 0.5f)
                {
                    hoverTimeList[layer] += Time.deltaTime;
                }
                else
                {
                    hoverTimeList[layer] = 0;
                    hoverFlagList[layer] = false;
                    lowerFlagList[layer] = true;
                }
            }

            if (lowerFlagList[layer])
            {
                if (liftHightList[layer] > 0f)
                {
                    liftHightList[layer] -= Time.deltaTime * 2;
                }
                else
                {
                    liftHightList[layer] = 0;
                    //hoverFlag = true;
                    lowerFlagList[layer] = false;
                }
                LayerList[layer].transform.localPosition = new Vector3(0, liftHightList[layer]);

            }
        }
    }

    void Cut(int layer)
    {
        int i = layer - 1;
        if (!liftFlagList[i] && !hoverFlagList[i] && !lowerFlagList[i])
        {
            liftFlagList[i] = true;
        }
        
    }
}
