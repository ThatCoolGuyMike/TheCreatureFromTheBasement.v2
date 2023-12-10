using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigGuyButtons : MonoBehaviour
{
    public GameObject animator;
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera2Texture;
    GameObject gameManager;
    public GameObject BigGuyDialouge;
    public AudioSource EatAudio;
    public AudioSource DoingGoodAudio;
    public AudioSource ScreemAudio;

    int i, j;
    bool timerI,timerJ;
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
            ScreemAudio.Play();
        animator.SetActive(true);
        gameManager.GetComponent<MainManager>().totalEatten += 100;
     timerJ = true;
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
        if (timerJ)
        {
            j++;
        }
        if (i >= 500)
        {
            BigGuyDialouge.SetActive(false);
            i = 0;
            timerI = false;
        }
        if (j >= 800)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
