using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class MainManager : MonoBehaviour
{
    //making vaibles 
    public static MainManager Instance;

    public int totalMeat, totalMeatValue;
    public int totalEatten, totalEattenValue;

    public int numDay;

    public GameObject creature1, creature2, creature3;

    public GameObject pauseMenu;

    bool creature2Bool, creature3Bool;
   

    private void Awake()
    {
       // totalEatten = 0;
        totalMeat = 0;

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PauseMenu();

    }

    private void Update()
    {
        if(!creature2Bool && !creature3Bool)LilCreature();
        if(creature2Bool)MidCreature();
        if(creature3Bool)BigCreature();
    }

    void LilCreature()
    {
        creature1.SetActive(true);
        creature2.SetActive(false);
        creature3.SetActive(false);

        if(totalEatten >= 10 && totalEatten <= 25 && SceneManager.sceneCount != 3)
        {
            creature2Bool = true;
        }

    }

    void MidCreature()
    {
        creature1.SetActive(false);
        creature2.SetActive(true);
        creature3.SetActive(false);
        if (totalEatten >= 25 && SceneManager.sceneCount != 3)
        {
            creature3Bool = true;
            creature2Bool=false;
        }
    }

    void BigCreature()
    {
        creature1.SetActive(false);
        creature2.SetActive(false);
        creature3.SetActive(true);
    }
    [System.Serializable]
    class SaveData
    {
        public int totalMeat;
    }

    public void SaveVariables()
    {
        //saves variables
        SaveData data = new SaveData();
        data.totalMeat = totalMeat;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log ("Is Working?");
        Debug.Log(json);

    }

    public void LoadSaveVariables()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //loads defind veryibles
            totalMeat = data.totalMeat;

        }
    }
    public void SaveColorClicked()
    {

        MainManager.Instance.totalMeat = totalMeatValue;
        
        MainManager.Instance.SaveVariables();//use to save data
    }

    public void LoadColorClicked()
    {
      //  MainManager.Instance.SaveVariables();

        MainManager.Instance.LoadSaveVariables();//use to load data
        totalMeatValue = MainManager.Instance.totalMeat;
     //   mc.SelectColor(MainManager.Instance.totalMeat);
        
    }

    void PauseMenu()
    {
        if(SceneManager.sceneCount == 0)
        {
            pauseMenu.SetActive(false);
        }

        if (SceneManager.sceneCount != 0)
        {
            pauseMenu.SetActive(true);
        }
    }
}
