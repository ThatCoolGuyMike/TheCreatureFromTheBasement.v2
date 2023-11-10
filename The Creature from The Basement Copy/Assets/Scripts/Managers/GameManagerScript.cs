using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    GameObject gameManager;
    public bool creature2, creature3;
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
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
