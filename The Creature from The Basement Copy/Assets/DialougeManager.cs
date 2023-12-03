using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    public GameObject JoanneDialouge;
    public GameObject NoiseDialouge;
    GameObject gameManager, InGameManager;
    bool timerJ;
    int j;

    AudioSource whatAudio;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        InGameManager = GameObject.FindGameObjectWithTag("inGameManager");
        JoanneDialouge.SetActive(false);
        NoiseDialouge.SetActive(false);
        whatAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InGameManager.GetComponent<GameManagerScript>().i >= 2000 && j <= 0 && gameManager.GetComponent<MainManager>().numDay < 1)
        {
            JoanneDialouge.SetActive(true);
            NoiseDialouge.SetActive(true);
            whatAudio.Play();
            timerJ = true;
           
        }
        if (timerJ)
        {
            j++;
        }
        if (j >= 500)
        {
            JoanneDialouge.SetActive(false);
            NoiseDialouge.SetActive(false);
            j = 10;
            timerJ = false;
        }
    }

}
