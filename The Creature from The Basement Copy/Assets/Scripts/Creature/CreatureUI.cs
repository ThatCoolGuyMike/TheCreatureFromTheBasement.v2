using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreatureUI : MonoBehaviour
{

    [SerializeField] TMP_Text foodCounterText;
    [SerializeField] TMP_Text foodEattenCounterText;
  
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null)
        {
            foodCounterText.text = ("Food Count:" + gameManager.GetComponent<MainManager>().totalMeat);
            foodEattenCounterText.text = ("Food Eatten: " + gameManager.GetComponent<MainManager>().totalEatten);
        }
    }
}
