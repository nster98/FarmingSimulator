using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableTool : MonoBehaviour
{
    public GameObject tool1;
    public GameObject tool2;
    public GameObject tool3;

    private GameObject currtool;
    //private int numberobjects = 3;
    //private float delay = 2.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //currtool.gameObject.SetActive(false);
            //currtool = tool1;
            tool3.gameObject.SetActive(false);
            tool2.gameObject.SetActive(false);
            tool1.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tool1.gameObject.SetActive(false);
            tool3.gameObject.SetActive(false);
            tool2.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tool1.gameObject.SetActive(false);
            tool2.gameObject.SetActive(false);
            tool3.gameObject.SetActive(true);
        }
    }
}
