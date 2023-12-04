using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManagerScript : MonoBehaviour
{
    public GameObject DayLight, NightLight;
    GameObject inGameManager;

    // Start is called before the first frame update
    void Start()
    {
        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");
    }

    // Update is called once per frame
    void Update()
    {

        if(inGameManager.GetComponent<GameManagerScript>().IsDay)
        {
            DayLight.SetActive(true);
            NightLight.SetActive(false);
        }else
        {
            DayLight.SetActive(false);
            NightLight.SetActive(true);
        }
    }
}
