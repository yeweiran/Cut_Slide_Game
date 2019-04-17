using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Selfdestroy", 2);
    }


    void Selfdestroy() {
        this.gameObject.SetActive(false);
    }

}
