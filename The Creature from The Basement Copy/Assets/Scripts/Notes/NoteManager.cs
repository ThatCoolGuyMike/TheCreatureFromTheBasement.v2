using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameObject[] note;

    GameObject gameManager, inGameManager; 
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetComponent<MainManager>().numDay >= 1)
        {
            note[0].SetActive(false);
        }
        if(inGameManager.GetComponent<GameManagerScript>().creature3 && gameManager.GetComponent<MainManager>().numDay >= 3)
        {
            note[1].SetActive(true);
        }
    }
}
