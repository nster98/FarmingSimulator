using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{ 
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //this.gameObject.SetActive(true);
            //Debug.Log("Tab");
        }
        else
        {
            //this.gameObject.SetActive(false);
        }

    }
}
