using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    public int amountOfParts;
    public GameObject[] partsOfPlant;
    public int secondsToGrow;

    public ParticleSystem readyParticles;

    private float timer = 0;

    private int index = 0;

    private bool finishedGrowing = false;


    void Start()
    {
        foreach (GameObject part in partsOfPlant)
        {
            part.SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime; // Timer

        if (timer > secondsToGrow && finishedGrowing != true)
        {
            partsOfPlant[index].SetActive(true);

            if (index == 6)
            {
                Instantiate(readyParticles, partsOfPlant[amountOfParts - 1].transform.position, Quaternion.identity);
            }

            if (finishedGrowing != true)
                index++;
            timer = 0;
        }

        if (index > amountOfParts)
        {
            finishedGrowing = true;
            //Instantiate(readyParticles, partsOfPlant[amountOfParts - 1].transform.position, Quaternion.identity);
        }
           
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        if (finishedGrowing == true)
        {
            Destroy(gameObject);
            // Add corn counter here
        }
    }
}
