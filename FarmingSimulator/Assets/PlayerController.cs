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
    public GameObject dirtHole;
    public GameObject menu;

    public GameObject cornText;

    private int cornCount;

    private EnableDisableTool toolScript;
    private string currentTool;


    void Start()
    {
        toolScript = this.GetComponent<EnableDisableTool>();
    }

    void Update()
    {
        currentTool = toolScript.currtool;

        // Menu

        if (Input.GetKey(KeyCode.Tab))
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
        
        // Clicking

        if (Input.GetMouseButtonDown(0))
        {
            var screenPos = Input.mousePosition;
            var ray = cam.ScreenPointToRay(screenPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.name == "Terrain" && currentTool == "Hoe")
                {
                    Instantiate(dirtHole, new Vector3(hit.point.x, hit.point.y - 0.1f, hit.point.z), Quaternion.Euler(90.0f, 90.0f, 90.0f));
                    Debug.Log(ray);
                }
                if (hit.collider.name == "DirtHole(Clone)" && currentTool == "SeedBag")
                {
                    Instantiate(corn, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.name == "corn(Clone)" && currentTool == "Shovel")
                {
                    Destroy(hit.collider.gameObject);
                    cornCount++;
                    cornText.GetComponent<UnityEngine.UI.Text>().text = "Corn: " + cornCount;
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
