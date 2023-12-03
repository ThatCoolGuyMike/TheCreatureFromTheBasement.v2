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
    GameObject inGameManager;
    GameObject JoanneDialouge;
    public GameObject sleepDialouge;
    int i, j;

    public string isSleeping = "isSleeping";
    bool timer, timerJ;
    public bool canSleep;
    // Start is called before the first frame update
    AudioSource NotEppyAudio;

    void Start()
    {
        playerTag = "Player"; // interactible tagged object
       
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");
        JoanneDialouge = GameObject.FindGameObjectWithTag("JoanneDialouge");
        NotEppyAudio = GetComponent<AudioSource>();
        timer = false;
        timerJ = false;
        canSleep = false;
        JoanneDialouge.SetActive(false);
        sleepDialouge.SetActive(false);
        

    }

    void Update()
    {
        //updates the day count
        if (Input.GetKey(KeyCode.E) && BedCanInteract() && !inGameManager.GetComponent<GameManagerScript>().IsDay)
        {

            animator.SetTrigger("isSleeping");
            gameManager.GetComponent<MainManager>().numDay++;
            timer = true;
            canSleep = false;


            MainManager.Instance.SaveVariables();//use to save data

        }
        if (inGameManager.GetComponent<GameManagerScript>().IsDay)
        {
            animator.ResetTrigger("isSleeping");
        }
        if (Input.GetKeyDown(KeyCode.E) && BedCanInteract() && inGameManager.GetComponent<GameManagerScript>().IsDay)
        {
            NotEppyAudio.Play();
            JoanneDialouge.SetActive(true);
            sleepDialouge.SetActive(true);

            timerJ = true;

        }

        TimerI();
        TimerJ();
        //Check to see if you just set the toggle to positive

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

    void TimerI()
    {
        if (timer)
        {
            i++;
            if (i > 100)
            {

                timer = false;
                i = 0;
                canSleep = false;
                
            }
        }
    }
    void TimerJ()
    {
        if (timerJ)
        {
            j++;
        }
        if (j >= 500)
        {
            JoanneDialouge.SetActive(false);
            sleepDialouge.SetActive(false);
            j = 0;
            timerJ = false;
        }
    }
}
