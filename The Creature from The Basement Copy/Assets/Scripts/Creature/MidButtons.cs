using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidButtons : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera2Texture;
    GameObject gameManager;
    public GameObject MidGuyDialouge;

    int i;
    bool timerI;
    private void Start()
    {

        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        MidGuyDialouge.SetActive(true);
        timerI = true;
    }


    public void Feed()
    {
        if (gameManager.GetComponent<MainManager>().totalMeat >= 5)
        {
            gameManager.GetComponent<MainManager>().totalMeat -= 5;

            gameManager.GetComponent<MainManager>().totalEatten += 5;
        }
    }
    public void Back()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera2Texture.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (timerI)
        {
            i++;
        }
        if (i >= 500)
        {
            MidGuyDialouge.SetActive(false);
            i = 0;
            timerI = false;
        }
    }
}
