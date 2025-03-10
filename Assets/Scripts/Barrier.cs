﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    
    //public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > -10)
        {
            transform.position += new Vector3(-GameManager.Instance.GetSpeed() * Time.deltaTime * 700, 0);
        }
        else
        {
            //transform.position = new Vector3(38, transform.position.y);
            GameObject.Destroy(gameObject);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("speed reset");
       if(collision.tag == "Robot")
        {
            if(this.tag == "Barrier")
            {
                Debug.Log("Hit Barrier");
                GameManager.Instance.HitBarrier();
                
            }
            if(this.tag == "SpeedBonus")
            {
                Debug.Log("Hit Bonus");
                GameManager.Instance.HitSpeedBonus();
            }
            if (this.tag == "ScoreBonus")
            {
                Debug.Log("Hit Bonus");
                GameManager.Instance.HitScoreBonus();
            }

        }
        //GameObject.Find("BackgroundObject").GetComponent<BackgroundController>().speed = 0;
    }

}
