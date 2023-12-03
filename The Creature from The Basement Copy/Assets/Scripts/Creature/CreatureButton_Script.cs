using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureButton_Script : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera2Texture;
    GameObject gameManager;
    public GameObject JoanneDialouge;
    public GameObject GuyDialouge;
    public GameObject LittleGuyDialouge;

    int j,i;
    bool timerJ, timerI;

    private void Start()
    {
   
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        JoanneDialouge.SetActive(false);
        GuyDialouge.SetActive(false);
        LittleGuyDialouge.SetActive(true);
        timerI = true;
        
    }


    public void Feed()
    {
        if (gameManager.GetComponent<MainManager>().totalMeat >= 5 )
        {
            gameManager.GetComponent<MainManager>().totalMeat -= 5;

            gameManager.GetComponent<MainManager>().totalEatten += 5;
            JoanneDialouge.SetActive(true);
            GuyDialouge.SetActive(true);
            timerJ = true;
        }
    }
    public void Back()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera2Texture.SetActive(false);
        LittleGuyDialouge.SetActive(false);
        JoanneDialouge.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if(timerI)
        {
            i++;
        }
        if (timerJ)
        {
            j++;
        }

        if (j >= 500)
        {
            JoanneDialouge.SetActive(false);
            GuyDialouge.SetActive(false);
            j = 0;
            timerJ = false;
        }
        if(i >= 500)
        {
            LittleGuyDialouge.SetActive(false);
            i = 0;
            timerI = false;
        }
    }
}
