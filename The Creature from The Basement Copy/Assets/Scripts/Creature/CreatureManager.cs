using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureManager : MonoBehaviour
{
    public GameObject creature1, creature2, creature3;
    // Start is called before the first frame update
    bool creature2Bool, creature3Bool;
  

    GameObject inGameManager;
    void Start()
    {
        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");

    }

    // Update is called once per frame
    void Update()
    {
        if (!creature2Bool && !creature3Bool) LilCreature();

        if (creature2Bool) MidCreature();

        if (creature3Bool) BigCreature();

    }

    void LilCreature()
    {
        if (creature1 != null)
        {
            creature1.SetActive(true);
            creature2.SetActive(false);
            creature3.SetActive(false);
        }
        //uses bools from game manager to turn on these bools
        if (inGameManager.GetComponent<GameManagerScript>().creature2)
        {
            creature2Bool = true;
            creature3Bool = false;
        }
    }

    void MidCreature()
    {
        if (creature2 != null)
        {
            creature1.SetActive(false);
            creature2.SetActive(true);
            creature3.SetActive(false);
        }

        if (inGameManager.GetComponent<GameManagerScript>().creature3)
        {
            creature3Bool = true;
            creature2Bool = false;
        }
    }

    void BigCreature()
    {
        if (creature3 != null)
        {
            creature1.SetActive(false);
            creature2.SetActive(false);
            creature3.SetActive(true);
        }
    }

}
