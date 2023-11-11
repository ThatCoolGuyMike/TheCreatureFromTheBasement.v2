using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class BedScript : MonoBehaviour
{

public Animator animator;
    [SerializeField] float distanceToPInteract; // makes a float to be used to see if the player if close enough

    [SerializeField] string playerTag;
    GameObject gameManager;
    int i;

    public string isSleeping = "isSleeping";
    bool timer;
    // Start is called before the first frame update

    void Start()
    {
        playerTag = "Player"; // interactible tagged object
       
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        timer = false;
    }





    void Update()
    {
        //updates the day count
        if (Input.GetKeyDown(KeyCode.E) && BedCanInteract())
        {
            gameManager.GetComponent<MainManager>().numDay++;
            animator.SetBool(isSleeping, true);
            timer = true;
        }

        if(timer)
        {
             i++;
            if(i > 100)
            {
                animator.SetBool(isSleeping, false);
                timer = false;
                i = 0;
            }
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
    public void SleepAnimationFinnish()
    {
        animator.SetBool(isSleeping, false);
    }
}
