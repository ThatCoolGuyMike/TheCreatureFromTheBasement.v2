using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveScript : MonoBehaviour
{
//method called by buttons
    public void SaveColorClicked()
    {

        MainManager.Instance.SaveVariables();//use to save data
    }
    //method called by buttons
    public void LoadColorClicked()
    {

        MainManager.Instance.LoadSaveVariables();//use to load data

    }
}
