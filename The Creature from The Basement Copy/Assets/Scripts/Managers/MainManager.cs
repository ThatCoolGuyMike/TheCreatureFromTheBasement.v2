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

    public int totalMeat;
    public int totalEatten;
    public int numDay;

   

    private void Awake()
    {
        totalEatten = 0;
        totalMeat = 0;

        //makes sure there is no copys
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //this needs to be last
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    

    [System.Serializable]
    class SaveData
    {
        public int totalMeat;
        public int totalEatten;

    }

    public void SaveVariables()
    {
        //saves variables
        SaveData data = new SaveData();
        data.totalMeat = totalMeat;
        data.totalEatten = totalEatten;

        string json = JsonUtility.ToJson(data);
        //saves variable to file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(json);

    }

    
    public void LoadSaveVariables()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            //calls file
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //loads defind veryibles
            totalMeat = data.totalMeat;
            totalEatten = data.totalEatten;

        }
    }

    //save method for buttons
    public void SaveColorClicked()
    {

        MainManager.Instance.totalMeat = totalMeat;
        MainManager.Instance.totalEatten = totalEatten;
        
        MainManager.Instance.SaveVariables();//use to save data
    }

    //load method for buttons
    public void LoadColorClicked()
    {

        MainManager.Instance.LoadSaveVariables();//use to load data
        totalMeat = MainManager.Instance.totalMeat;
        totalEatten = MainManager.Instance.totalEatten;


    }


}
