using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    public int amountOfParts;
    public GameObject[] partsOfPlant;
    public int secondsToGrow;

    private float timer = 0;

    private int index = 0;


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

        if (timer > secondsToGrow)
        {
            partsOfPlant[index].SetActive(true);

            if (index <= amountOfParts)
                index++;
            timer = 0;
        }
    }
}
