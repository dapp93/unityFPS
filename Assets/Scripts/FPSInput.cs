using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
    {
    public float gravity = -9.8f;
    private float pushForce=5.0f;

    private CharacterController charController;
    public float speed = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();

        Debug.Log("cc started");
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Clamp magnitude for diagonal movement
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;


        // Movement code Frame Rate Independent
        movement *= Time.deltaTime;

        //Debug.Log("Movement prior:" + movement);
        // Convert local to global coordinates
        movement =  transform.TransformDirection(movement);
        //Debug.Log("movement after" + movement) ;

        charController.Move(movement);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        // does it have a rigidbody and is Physics enabled?
        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }


}
