using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner_Script : MonoBehaviour
{

    public GameObject[] ratPrefab;

    GameObject inGameManager;
    // Start is called before the first frame update
    void Start()
    {
        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
