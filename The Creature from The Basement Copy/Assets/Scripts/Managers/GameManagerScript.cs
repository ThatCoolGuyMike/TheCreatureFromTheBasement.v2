using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject JoanneDialouge;
    public GameObject NoiseDialouge;
    public static GameManagerScript Instance;
    GameObject gameManager, bed;
    public bool creature2, creature3;
    public int i, j;
    public bool IsDay, IsInBasement, timerJ;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        IsInBasement = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
                if(SceneManager.GetSceneByName("MainFloor").isLoaded && bed == null)
        {
        bed = GameObject.FindGameObjectWithTag("Bed");
        }
        //ifs to check if creature is good to use
        if(gameManager.GetComponent<MainManager>().totalEatten >= 10 && gameManager.GetComponent<MainManager>().totalEatten <= 25 && !SceneManager.GetSceneByName("Basement").isLoaded)
        {
            creature2 = true;
            
        }

        if (gameManager.GetComponent<MainManager>().totalEatten >= 25 && !SceneManager.GetSceneByName("Basement").isLoaded)
        {
            creature3 = true;
            creature2 = false;
        }

        if(bed != null && !bed.GetComponent<BedScript>().canSleep)
        {
            IsDay = true;
            i++;
            if(i >= 5000)
            {
                bed.GetComponent<BedScript>().canSleep = true;
                i = 0;
                IsDay = false;
            }
           
        }
        if(SceneManager.GetSceneByName("Basement").isLoaded)
        {
            i = 5000;
            IsInBasement = true;
        }


    }
}
