using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private static score _instance;

    public static score Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("sumScore").GetComponent<score>();
            }
            return _instance;
        }
    }
    float bonus;
    public GameObject text_bonus1;
    public GameObject text_bonus2;
    public Text bonusText;
 
    void Awake()
    {
        bonus=1;
    }

    void Update()
    {
        if (GameManager.Instance.GetSpeed() >= 0.014f)
        {
            text_bonus2.SetActive(true);
            bonus = 2;
            bonusText.text = "2";
        }
        else if (GameManager.Instance.GetSpeed() >= 0.012f)
        {
            text_bonus1.SetActive(true);
            bonus = 1.5f;
            bonusText.text = "1.5";
        }
        if (GameManager.Instance.GetSpeed() < 0.012f)
        {
            bonus = 1f;
            text_bonus1.SetActive(false);
            bonusText.text = "1";
        }
        if (GameManager.Instance.GetSpeed() < 0.014f)
        {
            text_bonus2.SetActive(false);
        }

        SumScore.Add(Mathf.RoundToInt(Time.deltaTime * GameManager.Instance.GetSpeed() * 4000 * bonus));
        SumScore.SaveHighScore();

        //if (HitBonus()) {
          
        //}
    }

    public void HitBonus()
    {
        SumScore.Add(1000);
    }
}
