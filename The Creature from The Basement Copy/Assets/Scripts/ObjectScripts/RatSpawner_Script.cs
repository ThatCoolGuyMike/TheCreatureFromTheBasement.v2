using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatSpawner_Script : MonoBehaviour
{

    public GameObject[] ratPrefab;

    GameObject inGameManager;
    GameObject mainGameManager;

    Vector3 ratPosition;

    // Start is called before the first frame update
    void Start()
    {

        mainGameManager = GameObject.FindGameObjectWithTag("gamemanager");

        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");

        ratPosition = transform.position;



        if (mainGameManager.GetComponent<MainManager>().numDay > 1)
        {
            Instantiate(ratPrefab[0], ratPosition, Quaternion.LookRotation(ratPosition));

            if(mainGameManager.GetComponent<MainManager>().numDay > 4)
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


    }
}
