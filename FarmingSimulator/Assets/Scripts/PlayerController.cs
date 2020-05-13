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

    public ParticleSystem dirtKick;

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
            string sellcorn = "\nWould you like to sell corn for $1 each? (Q)";
            string nocorn = ". You cannot sell corn.";
            string allgoodstring = "Corn: " + cornCount + sellcorn + "\nSeeds: " + cornSeedsCount + "\nMoney: $" + moneyCount.ToString("0.00") + ". Buy seed for $0.1? (Y)";
            string nocornstring = "Corn: " + cornCount + nocorn + "\nSeeds: " + cornSeedsCount + "\nMoney: $" + moneyCount.ToString("0.00") + ". Buy seed for $0.1? (Y)";
            string nomoneystring = "Corn: " + cornCount + sellcorn+ "\nSeeds: " + cornSeedsCount + "\nMoney: $" + moneyCount.ToString("0.00") + ". Not enough for seeds.";
            string allbadstring = "Corn: " + cornCount + nocorn + "\nSeeds: " + cornSeedsCount + "\nMoney: $" + moneyCount.ToString("0.00") + ". Not enough for seeds.";
            menu.SetActive(true);
            // menuOn = !menuOn;
            //moneyText.GetComponent<UnityEngine.UI.Text>().text = "\n Money:" + moneyCount;
            
            if(moneyCount<=0 && cornCount!=0)
            {
                cornText.GetComponent<UnityEngine.UI.Text>().text = nomoneystring;
            }
            else if(cornCount == 0 && moneyCount!=0)
            {
                cornText.GetComponent<UnityEngine.UI.Text>().text = nocornstring;
            }
            else if(cornCount==0 && moneyCount <= 0)
            {
                cornText.GetComponent<UnityEngine.UI.Text>().text = allbadstring;
            }
            else
            {
                cornText.GetComponent<UnityEngine.UI.Text>().text = allgoodstring;
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                if (moneyCount < 0.09)
                {
                moneyCount = 0;
                    if (moneyCount <= 0 && cornCount != 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = nomoneystring;
                    }
                    else if (cornCount == 0 && moneyCount != 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = nocornstring;
                    }
                    else if (cornCount == 0 && moneyCount <= 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = allbadstring;
                    }

                }
                else
                {
                moneyCount = moneyCount - 0.1;
                if (moneyCount < 0.09)
                {
                    moneyCount = 0;
                    cornSeedsCount++;
                        if (moneyCount <= 0 && cornCount != 0)
                        {
                            cornText.GetComponent<UnityEngine.UI.Text>().text = nomoneystring;
                        }
                        else if (cornCount == 0 && moneyCount != 0)
                        {
                            cornText.GetComponent<UnityEngine.UI.Text>().text = nocornstring;
                        }
                        else if (cornCount == 0 && moneyCount <= 0)
                        {
                            cornText.GetComponent<UnityEngine.UI.Text>().text = allbadstring;
                        }
                    }
                else { 
                    cornSeedsCount++;
                        if (moneyCount <= 0 && cornCount != 0)
                        {
                            cornText.GetComponent<UnityEngine.UI.Text>().text = nomoneystring;
                        }
                        else if (cornCount == 0 && moneyCount != 0)
                        {
                            cornText.GetComponent<UnityEngine.UI.Text>().text = nocornstring;
                        }
                        else if (cornCount == 0 && moneyCount <= 0)
                        {
                            cornText.GetComponent<UnityEngine.UI.Text>().text = allbadstring;
                        }
                        else
                        {
                            cornText.GetComponent<UnityEngine.UI.Text>().text = allgoodstring;
                        }

                    }
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(cornCount != 0 )
                {
                    moneyCount=moneyCount+1;
                    cornCount--;
                    if (moneyCount <= 0 && cornCount != 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = nomoneystring;
                    }
                    else if (cornCount == 0 && moneyCount != 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = nocornstring;
                    }
                    else if (cornCount == 0 && moneyCount <= 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = allbadstring;
                    }
                    else
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = allgoodstring;
                    }

                }

                else
                {
                    if (moneyCount <= 0 && cornCount != 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = nomoneystring;
                    }
                    else if (cornCount == 0 && moneyCount != 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = nocornstring;
                    }
                    else if (cornCount == 0 && moneyCount <= 0)
                    {
                        cornText.GetComponent<UnityEngine.UI.Text>().text = allbadstring;
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
                if (hit.collider.name == "DirtHole(Clone)" && currentTool == "SeedBag" && cornSeedsCount != 0)
                {
                    Instantiate(corn, new Vector3(hit.point.x, hit.point.y - 0.2f, hit.point.z), Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    Instantiate(dirtKick, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    cornSeedsCount--;
                }
                if (hit.collider.name == "corn(Clone)" && currentTool == "Shovel")
                {
                    Destroy(hit.collider.gameObject);
                    cornCount++;

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
