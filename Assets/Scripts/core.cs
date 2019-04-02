using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            //Debug.DrawLine(ray.origin, hit.point);
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "CoreObject")
            {
                //Debug.Log("Enter Core!");
                SendMessageUpwards("EnterCore");
                break;
            }
        }
    }

    //void OnMouseEnter()
    //{
    //    Debug.Log("Enter Core!");
    //    SendMessageUpwards("EnterCore");
    //}

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    Debug.Log("Enter Core!");
    //}

}
