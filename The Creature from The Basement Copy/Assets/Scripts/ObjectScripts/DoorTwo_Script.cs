using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTwo_Script : MonoBehaviour
{


    [SerializeField] float distanceToPInteract; // makes a float to be used to see if the player if close enough

    [SerializeField] string playerTag;
    // Start is called before the first frame update
    void Start()
    {
        playerTag = "Player"; // interactible tagged object
    }

    // Update is called once per frame
    void Update()
    {
        if (DoorCanInteract() && Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public bool DoorCanInteract()
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