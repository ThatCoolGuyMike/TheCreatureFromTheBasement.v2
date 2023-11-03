using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpScript : MonoBehaviour
{

    [SerializeField] string InteractTag = "Interact"; // interactible tagged object

    [SerializeField] float distanceToPickUp; // makes a float to be used to see if the player if close enough

    [SerializeField] int foodCount;

    [SerializeField] bool _canInteract;

    // Update is called once per frame
    void Update()
    {

        //PickUp(); // calls pick up method
        CanInteract();

    }

    public bool CanInteract()
    {
        GameObject[] InteractibleObject = GameObject.FindGameObjectsWithTag(InteractTag); //adds the player object to the player tag in script

        foreach (GameObject tempInteractibleObject in InteractibleObject)
        {
            float distance = Vector3.Distance(transform.position, tempInteractibleObject.transform.position); // gets the distance between the player object and food object

            if (distance < distanceToPickUp) // if statment to see if the player is close enough and presses space
            {
                //Debug.Log("Object in Range ");
                return true;
            }

        }
        return false;
    }
}
