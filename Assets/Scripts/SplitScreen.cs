using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    void Start()
    {
        //cam1.enabled = false;
       // cam2.enabled = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSplitScreen();

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeVertScreen();

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player2fullScreen();

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player1fullScreen();

        }

    }


    public void ChangeSplitScreen()
    {
        cam1.enabled = true;
        cam2.enabled = true;
        cam1.rect = new Rect(0, 0, 1, 0.5f);
        cam2.rect = new Rect(0, 0.5f, 1f, 0.5f);
    }

    public void ChangeVertScreen()
    {
        cam1.enabled = true;
        cam2.enabled = true;
        cam1.rect = new Rect(0f, 0f, 0.5f, 1f);
        cam2.rect = new Rect(0.5f, 0f, 0.5f, 1f);
    }

    public void Player2fullScreen()
    {
        cam2.enabled = true;
        cam1.enabled = false;
        cam2.rect = new Rect(0f, 0f, 1f, 1f);
        // cam2.rect = new Rect(0f, 0f, 1f, 1f);
        
    }

    public void Player1fullScreen()
    {
        // cam1.rect = new Rect(0f, 0f, 1f, 1f);
        cam2.enabled = false;
        cam1.enabled = true;
        cam1.rect = new Rect(0f, 0f, 1f, 1f);
    }

}
