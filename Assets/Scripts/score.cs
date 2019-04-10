using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    float bonus;
    float speed;
 
    void Start()
    {
        bonus=1;
        speed=100;//test
    }

    void Update()
    {
        if(GameManager.Instance.GetSpeed() >= 0.009f)
        {
            bonus = 2;
        }
        SumScore.Add(Mathf.RoundToInt(Time.deltaTime * GameManager.Instance.GetSpeed() * 2000 * bonus));
    }
}
