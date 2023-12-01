using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            note[0].SetActive(false);//Tutorial Notes/Joanne Plan 
        }
        if(inGameManager.GetComponent<GameManagerScript>().creature3 && gameManager.GetComponent<MainManager>().numDay >= 3 && !SceneManager.GetSceneByName("Basement").isLoaded)
        {
            note[1].SetActive(true);//Scary Note
        }
        if (inGameManager.GetComponent<GameManagerScript>().creature2 && !SceneManager.GetSceneByName("Basement").isLoaded)
        {
            note[2].SetActive(true);//The creature Evolved!?
        }
        if (inGameManager.GetComponent<GameManagerScript>().creature3 && !SceneManager.GetSceneByName("Basement").isLoaded)
        {
            note[2].SetActive(false);//The creature Evolved!?
            note[3].SetActive(false);
        }
        if(inGameManager.GetComponent<GameManagerScript>().creature2 && gameManager.GetComponent<MainManager>().numDay >= 2 && !SceneManager.GetSceneByName("Basement").isLoaded)
        {
            note[3].SetActive(true);
        }
    }
}
