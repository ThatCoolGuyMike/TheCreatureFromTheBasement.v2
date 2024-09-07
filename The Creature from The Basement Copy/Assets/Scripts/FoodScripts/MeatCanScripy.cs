using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeatCanScripy : MonoBehaviour, IInteractable
{
    public GameObject Lights;
    GameObject gameManager;
    GameObject player;
    GameObject CanManger;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        

    }
    public void Interact()
    {
        gameManager.GetComponent<MainManager>().totalMeat++;
        Destroy(gameObject);//distroys self
    }
    public void interactAble()
    {
        Lights.SetActive(true);

    }
    public void Update()
    {
        if (player.GetComponent<InteracterScript>().notInteracting)
        {
        Lights.SetActive(false);
        }
    }
}