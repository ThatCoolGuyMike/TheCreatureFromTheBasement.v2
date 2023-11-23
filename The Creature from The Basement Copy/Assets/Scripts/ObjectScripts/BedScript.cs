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
    bool timer, timerJ, dialougeDelay;
    public bool canSleep;
    // Start is called before the first frame update

    void Start()
    {
        playerTag = "Player"; // interactible tagged object
       
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");
        JoanneDialouge = GameObject.FindGameObjectWithTag("JoanneDialouge");
        timer = false;
        timerJ = false;
        canSleep = true;
        JoanneDialouge.SetActive(false);
        sleepDialouge.SetActive(false);
        dialougeDelay = false;
    }

    void Update()
    {
        //updates the day count
        if (Input.GetKey(KeyCode.E) && BedCanInteract() && canSleep)
        {
           
            animator.SetBool(isSleeping, true);
            gameManager.GetComponent<MainManager>().numDay++;
            timer = true;
            canSleep=false;
            dialougeDelay=false;

            MainManager.Instance.SaveVariables();//use to save data

        }

        if (Input.GetKeyDown(KeyCode.E) && BedCanInteract() && !canSleep && dialougeDelay)
        {
            JoanneDialouge.SetActive(true);
            sleepDialouge.SetActive(true);

            timerJ = true;
            
        }

        TimerI();
        TimerJ();
     
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
                animator.SetBool(isSleeping, false);
                timer = false;
                i = 0;
                canSleep = false;
                dialougeDelay = true;
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
