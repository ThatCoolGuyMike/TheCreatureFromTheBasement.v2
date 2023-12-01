using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_JoannePlan : MonoBehaviour
{


    public GameObject Note;

    int i;
    bool timer;

    [SerializeField] float distanceToPickUp; // makes a float to be used to see if the player if close enough


    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Note != null && Input.GetKeyDown(KeyCode.E))
        {
            Note.SetActive(false);
        }
        if (NoteCanInteract() && Input.GetKeyDown(KeyCode.E) && !timer)
        {
            Note.SetActive(true);
            timer = true;
        }

        if (timer)
        {
            i++;
            if (i > 500)
            {

                timer = false;
                i = 0;

            }
        }

    }
    public bool NoteCanInteract()
    {
        GameObject[] InteractibleObject = GameObject.FindGameObjectsWithTag("Player"); //adds the player object to the player tag in script

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
