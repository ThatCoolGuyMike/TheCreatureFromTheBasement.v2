using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class BedScript : MonoBehaviour, IInteractable
{
   
    public Animator animator;
    [SerializeField] float distanceToPInteract; // makes a float to be used to see if the player if close enough

    [SerializeField] string playerTag;
    GameObject player;
    GameObject gameManager;
    GameObject inGameManager;
    GameObject JoanneDialouge;
    public  GameObject JoanneText;
    public GameObject Lights;
    public GameObject sleepDialouge, creatureNoice3, creatureNoice2, creatureNoice1;
    int i, j;

    public bool isSameDay;

    public string isSleeping = "isSleeping";
    bool timer, timerJ;
    public bool canSleep;
    // Start is called before the first frame update
    AudioSource NotEppyAudio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        creatureNoice3.SetActive(false);
        creatureNoice1.SetActive(false);
        creatureNoice2.SetActive(false);
        JoanneText.SetActive(false);


    }
    public void Interact()
    {
        if (!inGameManager.GetComponent<GameManagerScript>().IsDay)
        {

            animator.SetTrigger("isSleeping");
            gameManager.GetComponent<MainManager>().numDay++;

            timer = true;
            canSleep = false;
            if (inGameManager.GetComponent<GameManagerScript>().creature3)
            {
                creatureNoice3.SetActive(true);
            }
            if (inGameManager.GetComponent<GameManagerScript>().creature2)
            {
                creatureNoice2.SetActive(true);
            }
            if (!inGameManager.GetComponent<GameManagerScript>().creature2 && !inGameManager.GetComponent<GameManagerScript>().creature3)
            {
                //      creatureNoice1.SetActive(true);
            }

            MainManager.Instance.SaveVariables();//use to save data

        }
        if (inGameManager.GetComponent<GameManagerScript>().IsDay)
        {
            NotEppyAudio.Play();
            JoanneDialouge.SetActive(true);
            sleepDialouge.SetActive(true);
            JoanneText.SetActive(true);

            timerJ = true;

        }
    }
    public void interactAble()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        Lights.SetActive(true);

    }


    void Update()
    {

        if (player.GetComponent<InteracterScript>().notInteracting)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            Lights.SetActive(false);
        }

     

        TimerI();
        TimerJ();
        //Check to see if you just set the toggle to positive

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
            JoanneText.SetActive(false);
            j = 0;
            timerJ = false;
        }
    }
}
