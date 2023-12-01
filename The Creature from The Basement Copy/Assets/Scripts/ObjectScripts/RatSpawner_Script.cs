using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatSpawner_Script : MonoBehaviour
{

    public GameObject[] ratPrefab;
    public GameObject JoanneDialouge;
    GameObject inGameManager;
    GameObject mainGameManager;
    public GameObject ratDialouge;
    bool timerJ;
    int j;

    Vector3 ratPosition;

    // Start is called before the first frame update
    void Start()
    {
        ratDialouge.SetActive(false);
        JoanneDialouge.SetActive(false);

        mainGameManager = GameObject.FindGameObjectWithTag("gamemanager");

        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");


        ratPosition = transform.position;



        if (mainGameManager.GetComponent<MainManager>().numDay > 1)
        {
            Instantiate(ratPrefab[0], ratPosition, Quaternion.LookRotation(ratPosition));
            JoanneDialouge.SetActive(true);
            ratDialouge.SetActive(true);
            timerJ=true;

            if (mainGameManager.GetComponent<MainManager>().numDay > 4)
            {
                Instantiate(ratPrefab[0], ratPosition, Quaternion.LookRotation(ratPosition));
            }
        }
        if(!inGameManager.GetComponent<GameManagerScript>().IsDay && mainGameManager.GetComponent<MainManager>().numDay > 1)
        {
            Instantiate(ratPrefab[0], ratPosition, Quaternion.LookRotation(ratPosition));
        }

    }

    // Update is called once per frame
    void Update()
    {
        TimerJ();

    }
    void TimerJ()
    {
        if (timerJ)
        {
            j++;
        }
        if (j >= 500)
        {
            JoanneDialouge.SetActive(false);
            ratDialouge.SetActive(false);
            j = 0;
            timerJ = false;
        }
    }
}
