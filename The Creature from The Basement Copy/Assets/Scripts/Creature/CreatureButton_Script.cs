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


    private void Start()
    {
   
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
    }


    public void Feed()
    {
        if (gameManager.GetComponent<MainManager>().totalMeat >= 5 && gameManager != null)
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
}
