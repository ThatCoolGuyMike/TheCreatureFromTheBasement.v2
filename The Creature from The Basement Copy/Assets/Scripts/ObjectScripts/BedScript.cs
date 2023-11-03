using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedScript : MonoBehaviour
{

    [SerializeField] float distanceToPInteract; // makes a float to be used to see if the player if close enough

    [SerializeField] string playerTag;
    GameObject gameManager;
    // Start is called before the first frame update

    void Start()
    {
        playerTag = "Player"; // interactible tagged object
       
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
    }



 
    void Update()
    {
        //updates the day count
        if (BedCanInteract() && Input.GetKeyDown(KeyCode.E))
        {
            gameManager.GetComponent<MainManager>().numDay++;

        }
    }


    public bool BedCanInteract()
    {
        GameObject[] InteractibleObject = GameObject.FindGameObjectsWithTag(playerTag); //adds the player object to the player tag in script

        foreach (GameObject tempInteractibleObject in InteractibleObject)
        {
            float distance = Vector3.Distance(transform.position, tempInteractibleObject.transform.position); // gets the distance between the player object and food object

            if (distance < distanceToPInteract) // if statment to see if the player is close enough and presses space
            {

                return true;

            }
        }
        return false;
    }
}
