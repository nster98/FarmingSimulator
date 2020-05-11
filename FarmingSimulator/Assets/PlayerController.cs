using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject tool1; // Shovel
    public GameObject tool2; // Hoe
    public GameObject tool3; // Seedbag

    public Camera cam;

    public GameObject corn;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked?");
            var screenPos = Input.mousePosition;
            var ray = cam.ScreenPointToRay(screenPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.name == "Terrain")
                {
                    Instantiate(corn, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    Debug.Log(ray);
                }
                else
                    Debug.Log("Plane clicked but raycast hit something else");
            }
            else
            {
                Debug.Log("Plane was clicked but raycast missed");
            }
        }
    }
}
