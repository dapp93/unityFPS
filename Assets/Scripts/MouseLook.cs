using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //enum to set values by nameinstead of number.
    //makes code more readable!
    public float sensitivityHorz = 9.0f;
    public float sensitivityVert=9.0f;
    public float minVert=-45.0f;
    public float maxVert=45.0f;
    private float rotationX=0.0f;
    private bool isActive=true;
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.UIPOPUP_OPENED,OnUIOpen);
        Messenger<int>.AddListener(GameEvent.UIPOPUP_CLOSED, OnUIClose);

    }

    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.UIPOPUP_OPENED, OnUIOpen);
        Messenger<int>.RemoveListener(GameEvent.UIPOPUP_CLOSED, OnUIClose);
    }

    private void OnUIClose(int popupCount)
    {
        isActive = popupCount == 0;
    }
    private void OnUIOpen(int popupCount)
    {
        isActive = false;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (axes == RotationAxes.MouseX)
            {
                //horizontalrotationhere
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorz, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                //verticalrotationhere
                rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

                transform.localEulerAngles = new Vector3(rotationX, 0, 0);

            }
            else
            {
                //bothhorizontalandverticalrotationhere

                //verticalrotationhere
                rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
                float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHorz;
                float rotationY = transform.localEulerAngles.y + deltaHoriz;

                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            }

        }
    }
}
