using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > -9)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = new Vector3(9, transform.position.y);
        }
        
    }

    void OnCollisionEnter2D(Collision collision)
    {
        // 销毁当前游戏物体
        Debug.Log(collision.collider.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
