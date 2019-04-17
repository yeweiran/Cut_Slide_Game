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

    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;
    public GameObject bonus1;
    public GameObject bonus2;
    public GameObject textEffect_bonus;
    public GameObject textEffect_gameover;
    public GameObject panel;
    public GameObject speedline;
    public GameObject snowEffect;

    public Robot robot;
    CameraController camCon;
    Slide slide;

    private float speed = 0f;
    private float bonusTime = 0f;
    private float shieldTime = 0f;
    private int lives = 3;
    // Start is called before the first frame update



    void Start()
    {
        Time.timeScale = 1;
        camCon = GameObject.Find("Main Camera").GetComponent<CameraController>();
        slide= GameObject.Find("SlideObject").GetComponent<Slide>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shieldTime > 0)
        {
            robot.ShowShield();
            shieldTime -= Time.deltaTime;
        }
        else
        {
            robot.HideShield();
        }

        if (bonusTime > 0)
        {
            speedline.SetActive(true);
            bonusTime -= Time.deltaTime;
            speed = 0.04f;
        }
        else
        {
            speedline.SetActive(false);
            if (speed > 0.016f)
            {
                speed = 0.016f;
            }
            if (speed > 0)
            {
                snowEffect.SetActive(true);
                speed -= Time.deltaTime * 0.001f;
            }
            else
            {
                snowEffect.SetActive(false);
                speed = 0;
            }
        }


        if (lives == 0) {
            StartCoroutine(GameOver());
        }
    }


    //public void GameOver() {
    //    Time.timeScale = 0;
    //}

    public void Slide()
    {
        if (speed <= 0.01)
            speed += 0.002f;
        else
        {
            speed += 0.001f;
            if (speed > 0.016)
            {
                speed = 0.016f;
            }
        }
        
    }

    public void HitBarrier()
    {
        if (shieldTime <= 0)
        {
            StartCoroutine(SoundManager.Instance.LoadAudio("hit.wav", 1, 1, 10, 0, false));
            camCon.shakeFlag = true;
            speed /= 2;
            speed -= 0.001f;
            if (speed < 0)
            {
                speed = 0;
            }
            lives--;
        }
        
    }

    public void HitSpeedBonus()
    {
        bonusTime = 4f;
        shieldTime = 6f;
        StartCoroutine(SoundManager.Instance.LoadAudio("speed.wav", 1, 1, 5, 0, false));
    }

    public void HitScoreBonus()
    {
        score.Instance.HitBonus();
        textEffect_bonus.SetActive(true);
        StartCoroutine(SoundManager.Instance.LoadAudio("score.wav", 1, 1, 5, 0, false));
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetLives()
    {
        return lives;
    }

    public void CreateBall()
    {
        int i = Random.Range(0, 100);
        if (i < 40)
        {
            GameObject.Instantiate(barrier1);
        }
        else if(i>=40 && i < 70)
        {
            GameObject.Instantiate(barrier2);
        }
        else if(i >= 70 && i < 90)
        {
            GameObject.Instantiate(barrier3);
        }
        else if (i>=90 && i < 95)
        {
            GameObject.Instantiate(bonus1);
        }else if(i >= 95)
        {
            GameObject.Instantiate(bonus2);
        }
    }


    public IEnumerator GameOver() {
        slide.enabled = false;
        textEffect_gameover.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
