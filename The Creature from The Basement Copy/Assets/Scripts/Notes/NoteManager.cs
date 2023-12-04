using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    public GameObject[] note;

    GameObject gameManager, inGameManager;
    int j;
    bool timerJ;
    AudioSource findNoice;
    // Start is called before the first frame update
    void Start()
    {
        findNoice = GetComponent<AudioSource>();
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
        if (inGameManager.GetComponent<GameManagerScript>().i >= 2000 && j <= 0 && gameManager.GetComponent<MainManager>().numDay < 1)
        {
            if(findNoice!=null)
            findNoice.Play();
            timerJ = true;
            if (timerJ)
            {
                j++;
            }
            if (j >= 500)
            {
                if (findNoice != null)
                    findNoice.Stop();
                j = 10;
                timerJ = false;
            }

        }
    }
}
