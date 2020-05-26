using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{

    private int score;
    private float maxHp;
    
    [SerializeField] private Text scoreValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private Image crossHair;
    [SerializeField] private SettingsPopup settingsPopup;


    [SerializeField] private GameOverScreen gameOverScreen;
    private int popupCount;




    // Start is called before the first frame update
    void Start()
    {
        popupCount = 0;
           //settingsPopup.Close();
           // init score
           maxHp = 1f;
        score = 0;
        scoreValue.text = score.ToString();
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;

        
    }

    // Update is called once per frame
    void Update()
    {
        /*
           if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive())
              {
                   PauseGame();
                   optionsPopup.Open();
                   Debug.Log("pause");
               }
       */

        //if you hit the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           //if there are no windows open, then pause the game
            if (popupCount == 0)
            {
                //PauseGame();
                //optionsPopup.Open();
                gameOverScreen.Open();
            }

        }



    }

    private void PauseGame()

    {
        Debug.Log("Pause game");

        Time.timeScale = 0;

        crossHair.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;

    }


    public void ResumeGame()

    {
        Debug.Log("Resume game");

        Time.timeScale = 1;

        crossHair.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;

    }
    void Awake()
    {
        Messenger.AddListener(GameEvent.RESTART_GAME, OnRestartGame);
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED,OnPopupOpen);
       Messenger.AddListener(GameEvent.POPUP_CLOSED,OnPopupClosed);
        Messenger.AddListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        //Listen for these events in the UIController.
        //RESTART_GAME event (ensure both AddListener() and RemoveListener() are called) and trigger OnRestartGame() when it is called.
       
    }
    void OnDestroy()
    {

        
        Messenger.RemoveListener(GameEvent.RESTART_GAME, OnRestartGame);
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, OnPopupOpen);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
        Messenger.RemoveListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
    }
    private void OnPlayerDead()
    {
        PauseGame();

       gameOverScreen.Open();
    }
    private void OnPopupClosed()
    {
        Debug.Log("OnPopupClosed");

        popupCount = popupCount - 1;
      
        if (popupCount == 0)
        {
            
            ResumeGame();

        }
        Messenger<int>.Broadcast(GameEvent.UIPOPUP_CLOSED, popupCount);
    }



    private void OnPopupOpen()
    {
        Debug.Log("OnPopupOpen");
        
        if (popupCount == 0)
        {
            PauseGame();
        }
        popupCount = popupCount + 1;
        //broadbast
        Messenger<int>.Broadcast(GameEvent.UIPOPUP_OPENED,popupCount);
        

    }


    private void OnEnemyDead()
    {//This method should have a private access modifier. 
        //Increment the score, and update the scoreValue UI Text.
        score = score + 1;
        scoreValue.text = score.ToString();
        Debug.Log("OnEnemyDead");


       
    }
     void OnHealthChanged(float percentageRemaining)
    {
      if (percentageRemaining==1)
        {
            percentageRemaining = percentageRemaining + 0.2f;
        }

            Debug.Log(percentageRemaining + "percentageRemaining");
        healthBar.fillAmount=percentageRemaining;
        healthBar.color = Color.Lerp(Color.red, Color.green, percentageRemaining);
        
 }
    public void OnRestartGame()
    {
        Debug.Log("OnRestartGame");
        ResumeGame();

        SceneManager.LoadScene(0);
    }





}
