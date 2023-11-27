using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    [Range(0.0f, 10.0f)]
    public float sliderSensitivity;

    [Range(0.0f, 1.0f)]
    public float _volume;
    //makes sure the mainMenu cursor 
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    //click play method
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);//loads next scene
    }
    
    //click quit method
    public void QuitGame()
    {
        Application.Quit();//exits program
    }
}
