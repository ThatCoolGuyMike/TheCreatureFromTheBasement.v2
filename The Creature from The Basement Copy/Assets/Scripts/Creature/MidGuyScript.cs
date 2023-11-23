using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidGuyScript : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera2Texture;

    [SerializeField] string playerTag = "Player"; // interactible tagged object

    [SerializeField] float distanceToPInteract; // makes a float to be used to see if the player if close enough


    // Update is called once per frame
    void Update()
    {
        MidGuyCanInteract();


        if (Input.GetKeyDown(KeyCode.E) && MidGuyCanInteract())// sees if object is able to be interacted with
        {

            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Camera2Texture.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

        }
    }
    public bool MidGuyCanInteract()
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