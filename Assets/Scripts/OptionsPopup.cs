using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsPopup : BasePopup
{
    
   // [SerializeField] private UIController uIController;
    [SerializeField] private SettingsPopup settingsPopup;



    void Start()
    {
        
        Debug.Log("op.start()");   
    }
    
    public void OnSettingsButton()
    {
        Close();
        settingsPopup.Open();
    }

    public void OnExitGameButton()
    {

        Application.Quit();

    }

    public void OnReturnToGameButton()
    {
         
        //uIController.ResumeGame();
        Close();
    }


   



}
