using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTwo_Script : MonoBehaviour, IInteractable
{

    public GameObject Lights;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Interact()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void interactAble()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        Lights.SetActive(true);

    }
    public void Update()
    {
        if (player.GetComponent<InteracterScript>().notInteracting)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            Lights.SetActive(false);
        }
    }



}