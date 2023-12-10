using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayFoodScript : MonoBehaviour
{


    GameObject food1, food2, food3, food4, food5, gameManager;
    // Start is called before the first frame update
    void Start()
    {
        food1 = GameObject.FindGameObjectWithTag("Day1Food");
        food2 = GameObject.FindGameObjectWithTag("Day2Food");
        food3 = GameObject.FindGameObjectWithTag("Day3Food");
        food4 = GameObject.FindGameObjectWithTag("Day4Food");
        food5 = GameObject.FindGameObjectWithTag("Day5Food");


        gameManager = GameObject.FindGameObjectWithTag("gamemanager");


        if (gameManager.GetComponent<MainManager>().numDay == 0)
        {
            food1.SetActive(true);
            food2.SetActive(false);
            food3.SetActive(false);
            food4.SetActive(false);
            food5.SetActive(false);
               
        }
        if (gameManager.GetComponent<MainManager>().numDay == 1)
        {
            food1.SetActive(false);
            food2.SetActive(true);
            food3.SetActive(false);
            food4.SetActive(false);
            food5.SetActive(false);

        }
        if (gameManager.GetComponent<MainManager>().numDay == 3)
        {
            food1.SetActive(false);
            food2.SetActive(false);
            food3.SetActive(true);
            food4.SetActive(false);
            food5.SetActive(false);

        }
        if (gameManager.GetComponent<MainManager>().numDay == 4)
        {
            food1.SetActive(false);
            food2.SetActive(false);
            food3.SetActive(false);
            food4.SetActive(true);
            food5.SetActive(false);

        }
        if (gameManager.GetComponent<MainManager>().numDay >= 5)
        {
            food1.SetActive(false);
            food2.SetActive(false);
            food3.SetActive(false);
            food4.SetActive(false);
            food5.SetActive(true);

        }
        
    }


}
