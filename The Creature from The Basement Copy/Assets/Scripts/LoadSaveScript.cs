using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveScript : MonoBehaviour
{
    public int totalMeatValue;
    public void SaveColorClicked()
    {

    //    MainManager.Instance.totalMeat = totalMeatValue;

        MainManager.Instance.SaveVariables();//use to save data
    }

    public void LoadColorClicked()
    {
        //  MainManager.Instance.SaveVariables();

        MainManager.Instance.LoadSaveVariables();//use to load data
      //  totalMeatValue = MainManager.Instance.totalMeat;
        //   mc.SelectColor(MainManager.Instance.totalMeat);

    }
}
