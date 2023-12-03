using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManagerScript : MonoBehaviour
{
    public GameObject DayLight, NightLight;
    GameObject inGameManager;
    public AudioSource dayAudio;
    public AudioSource nightAudio;
    // Start is called before the first frame update
    void Start()
    {
        inGameManager = GameObject.FindGameObjectWithTag("inGameManager");
        //dayAudio = GetComponent<AudioSource>();
       // nightAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(inGameManager.GetComponent<GameManagerScript>().IsDay)
        {
            DayLight.SetActive(true);

            NightLight.SetActive(false);
            nightAudio.Stop();
        }else
        {
            dayAudio.Stop();
            DayLight.SetActive(false);
             nightAudio.Play();
            NightLight.SetActive(true);
        }
    }
}
