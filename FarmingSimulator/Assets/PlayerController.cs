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
    //public GameObject moneyText;
    //public GameObject cornSeedsText;

    private int cornCount=0;
    private double moneyCount=1;
    private int cornSeedsCount=0;

    private EnableDisableTool toolScript;
    private string currentTool;

    private bool menuOn = true;

    void Start()
    {
        toolScript = this.GetComponent<EnableDisableTool>();
        menu.SetActive(false);
    }

    void Update()
    {
        currentTool = toolScript.currtool;

        // Menu

        if (Input.GetKey(KeyCode.Tab))
        {
            menu.SetActive(true);
            // menuOn = !menuOn;
            //moneyText.GetComponent<UnityEngine.UI.Text>().text = "\n Money:" + moneyCount;
            cornText.GetComponent<UnityEngine.UI.Text>().text = "Corn: " + cornCount + "\nSeeds:" + cornSeedsCount + "\nMoney: $" + moneyCount + ". Buy seed for $0.1? (Y)";
            while (true)
            {
                if (Input.GetKeyUp(KeyCode.Y))
                {
                    if (moneyCount < 0.1)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = "Corn: " + cornCount + "\nSeeds:" + cornSeedsCount + "\nMoney: $" + moneyCount + ". Not enough for seeds.";
                        moneyCount = 0;
                    }
                    else
                    {
                        moneyCount = moneyCount - 0.1;
                        cornSeedsCount++;
                        cornText.GetComponent<UnityEngine.UI.Text>().text = "Corn: " + cornCount + "\nSeeds:" + cornSeedsCount + "\nMoney: $" + moneyCount + ". Buy seed for $0.1? (Y)";

                    }
                }
            }
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
                    cornText.GetComponent<UnityEngine.UI.Text>().text = "Corn: " + cornCount
                        + "\nMoney: " + moneyCount + "$. Buy seed for $0.1?"; 

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
