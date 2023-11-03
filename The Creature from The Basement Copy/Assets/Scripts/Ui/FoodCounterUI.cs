using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodCounterUI : MonoBehaviour
{
    [SerializeField] TMP_Text foodCounterText;
    [SerializeField] TMP_Text foodEattenCounterText;



    GameObject gameManager;
    GameObject littleGuy;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
       // gameManager = GameObject.FindGameObjectWithTag("creature");


    }


    void Update()
    {


        if (gameManager != null)
            foodCounterText.text = ("Food Count:" + gameManager.GetComponent<MainManager>().totalMeat);

        //if(littleGuy != null)
       // foodEattenCounterText.text = ("Food Eatten:" + gameManager.GetComponent<MainManager>().totalEatten);
    }
  
}
