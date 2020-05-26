using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private bool doorIsOpen = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Operate()
    {
        if (doorIsOpen)
        {
            iTween.MoveTo(this.gameObject, new Vector3(0.01f, 0, -12.43f), 5);

        }
        else
        {
            iTween.MoveTo(this.gameObject, new Vector3(0.01f, -3.92f, -12.43f), 5);

        }
        doorIsOpen = !doorIsOpen;
    }


}
