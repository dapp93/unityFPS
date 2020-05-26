using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    

    virtual public void Open()
    {
        Debug.Log(this + ".Open()");

        if (!IsActive())
        {

            this.gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPENED);

        }
        else
        {
            Debug.LogError(this + ".open() - trying to open a popup that is not closed");
        }
        
       
    }

    virtual public void Close()
    {
        
      

        Debug.Log(this + ".Close()");
        if (IsActive())
        {
            this.gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        }
        else
        {

            Debug.LogError(this+".close() - trying to close a popup that is not open");
        }

    }

    public bool IsActive()
    {
        return this.gameObject.activeSelf;
    }
}
