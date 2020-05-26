using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScreen : BasePopup
{
   
    /*The GameOverScreen works exactly the same way as our other popups.
     * We’ll want to Open() it, Close() it, and it makes sense to ask if it IsActive(). 
     * Have the GameOverScreen.cs script inherit directly from the BasePopup class that we created in previous labs.
     * This will automatically provide these functions (via Inheritance), and it will automatically start broadcasting the GameEvent.POPUP_OPENED, and GameEvent.POPUP_CLOSED.*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnExitGameButton()
    {
        Application.Quit();
    }
    public void OnStartAgainButton()
    {
        Debug.Log("On start again button");
        Messenger.Broadcast(GameEvent.RESTART_GAME);
    }



}
