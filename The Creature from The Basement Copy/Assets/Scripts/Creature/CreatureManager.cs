using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureManager : MonoBehaviour
{
    public GameObject creature1, creature2, creature3;
    // Start is called before the first frame update


    GameObject inGameManager;
    void Start()
    {
        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");


        if (!inGameManager.GetComponent<GameManagerScript>().creature2 && !inGameManager.GetComponent<GameManagerScript>().creature3) LilCreature();

        if (inGameManager.GetComponent<GameManagerScript>().creature2) MidCreature();

        if (inGameManager.GetComponent<GameManagerScript>().creature3) BigCreature();
    }

    // Update is called once per frame

    void LilCreature()
    {
        if (creature1 != null)
        {
            creature1.SetActive(true);
            creature2.SetActive(false);
            creature3.SetActive(false);
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
