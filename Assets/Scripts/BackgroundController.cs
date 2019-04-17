using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed = 0;
    private float length = 0;
    private Renderer rend;
    //private float X;
    // Use this for initialization
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Mathf.Repeat(Time.time * speed, 1);
        //if(speed <= 0.01){
        //    speed += Time.deltaTime * 0.001f;
        //}
        
        length += GameManager.Instance.GetSpeed();
        rend.material.mainTextureOffset = new Vector2(length, 0);
        if(length >= 2)
        {
            length = 0;
            GameManager.Instance.CreateBall();
        }
    }
}
