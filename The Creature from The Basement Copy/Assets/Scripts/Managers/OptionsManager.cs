using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance;
    public AudioMixer audioMixer;

    GameObject playerCam;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;

        DontDestroyOnLoad(gameObject);
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void Update()
    {
        if (playerCam == null)
        {
            playerCam = GameObject.FindGameObjectWithTag("PlayerCamera");
        }
    }
   
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetSensitivity(float sensitivity)
    {
        playerCam.GetComponent<CamraMovment>().sensY = sensitivity;
        playerCam.GetComponent<CamraMovment>().sensX = sensitivity;
    }

}
