using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Note_Script : MonoBehaviour, IInteractable
{


    public GameObject Note;
    public GameObject Obj_Note;
    public GameObject Lights;
    GameObject player;

    bool timer;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Interact()
    {
        if (Note.active==false)
        {
            Note.SetActive(true);
            i = 0;
            timer = false;
        }
    }
    public void interactAble()
    {
        Obj_Note.SetActive(false);
        Lights.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Note != null && Input.GetKeyDown(KeyCode.E) && timer)
        {
           Note.SetActive(false);

        }
        if (i <= 60)
        {
            i++;
            
        }
        if (i >= 60)
        {
            timer = true;
        }

        if (player.GetComponent<InteracterScript>().notInteracting)
        {
            Obj_Note.SetActive(true);
            Lights.SetActive(false);
        }

    }
  
}
