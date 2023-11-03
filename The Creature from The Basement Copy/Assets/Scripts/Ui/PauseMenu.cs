using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionMenu;

    public GameObject cameraScript;
    public GameObject playerScript;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        optionMenu.SetActive(false);
        playerScript = GameObject.FindGameObjectWithTag("Player");
        cameraScript = GameObject.FindGameObjectWithTag("PlayerCamera");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && cameraScript != null)
        {
            optionMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            cameraScript.GetComponent<CamraMovment>().enabled = false;
            playerScript.GetComponent<PlayerMovment>().enabled = false;
        }
        if(cameraScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player");
            cameraScript = GameObject.FindGameObjectWithTag("PlayerCamera");
        }
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
    }

    public void QuitGame()
    {
        Application.Quit();//exits program
    }
}
