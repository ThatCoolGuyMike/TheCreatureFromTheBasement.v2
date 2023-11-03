using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeatCanScripy : MonoBehaviour
{
    

        [SerializeField] PlayerPickUpScript playerInteractScript;// gets player script

        [SerializeField] string playerTag = "Player"; // interactible tagged object

        [SerializeField] float distanceToPickUp; // makes a float to be used to see if the player if close enough



    GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
    }

    void Update()
    {
        //gets methods 
        FoodCanInteract();


        if (Input.GetKeyDown(KeyCode.E) && FoodCanInteract())// sees if object is able to be interacted with
        {

            gameManager.GetComponent<MainManager>().totalMeat++;
            Destroy(gameObject);//distroys self
            

        }


    }


    public bool FoodCanInteract()
    {
        GameObject[] InteractibleObject = GameObject.FindGameObjectsWithTag(playerTag); //adds the player object to the player tag in script

        foreach (GameObject tempInteractibleObject in InteractibleObject)
        {
            float distance = Vector3.Distance(transform.position, tempInteractibleObject.transform.position); // gets the distance between the player object and food object

            if (distance < distanceToPickUp) // if statment to see if the player is close enough and presses space
            {
  
                return true;

            }
        }
        return false;
    }
  
}