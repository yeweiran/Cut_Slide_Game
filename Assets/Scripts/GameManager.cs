using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            return _instance;
        }
    }

    private float speed = 0f;
    private float bonusTime = 0f;
    private int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bonusTime > 0)
        {
            bonusTime -= Time.deltaTime;
            speed = 0.02f;
        }
        else
        {
            if (speed > 0)
            {
                speed -= Time.deltaTime * 0.001f;
            }
            else
            {
                speed = 0;
            }
        }
        
    }

    public void Slide()
    {
        speed += 0.002f;
        if(speed > 0.01)
        {
            speed = 0.01f;
        }
    }

    public void HitBarrier()
    {
        speed -= 0.002f;
        if (speed < 0)
        {
            speed = 0;
        }
        lives--;
    }

    public void HitBonus()
    {
        bonusTime = 2f;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
