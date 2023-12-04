using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuyButtons : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera2Texture;
    GameObject gameManager;
    public GameObject BigGuyDialouge;
    public AudioSource EatAudio;
    public AudioSource DoingGoodAudio;

    int i;
    bool timerI;
    private void Start()
    {

        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        BigGuyDialouge.SetActive(true);
        timerI = true;
        DoingGoodAudio.Play();
    }


    public void Feed()
    {
        if (gameManager.GetComponent<MainManager>().totalMeat >= 5)
        {
            gameManager.GetComponent<MainManager>().totalMeat -= 5;
            EatAudio.Play();
            gameManager.GetComponent<MainManager>().totalEatten += 5;
        }
    }

    public void FeedSelf()
    {

            EatAudio.Play();
            gameManager.GetComponent<MainManager>().totalEatten += 100;
        
    }
    public void Back()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera2Texture.SetActive(false);
        BigGuyDialouge.SetActive(false);
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
            BigGuyDialouge.SetActive(false);
            i = 0;
            timerI = false;
        }
    }
}
