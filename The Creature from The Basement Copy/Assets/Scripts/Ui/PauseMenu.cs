using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public GameObject optionMenu;

    public GameObject cameraScript;
    public GameObject playerScript;

    [SerializeField] TMP_Text foodCounterText;
    [SerializeField] TMP_Text foodEattenCounterText;

    GameObject gameManager;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;

        DontDestroyOnLoad(gameObject);

        optionMenu.SetActive(false);
        playerScript = GameObject.FindGameObjectWithTag("Player");
        cameraScript = GameObject.FindGameObjectWithTag("PlayerCamera");
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && cameraScript != null && !SceneManager.GetSceneByName("MainMenu").isLoaded)
        {
            //enables menu and cursor
            optionMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            //disables the player
            cameraScript.GetComponent<CamraMovment>().enabled = false;
            playerScript.GetComponent<PlayerMovment>().enabled = false;
        }


        //finds the objects when switching scenes
        if(cameraScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player");
            cameraScript = GameObject.FindGameObjectWithTag("PlayerCamera");
        }

        if (gameManager != null)
            foodCounterText.text = ("Food Count:" + gameManager.GetComponent<MainManager>().totalMeat);
    }

    public void BackButton()
    {
        optionMenu.SetActive(false);
        cameraScript.GetComponent<CamraMovment>().enabled = true;
        playerScript.GetComponent<PlayerMovment>().enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        optionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();//exits program
    }
}
