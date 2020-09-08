using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float mouseSensitivity = 1;
    public float cameraSpeed = 10;
    public float clampAngle = 80;

    public GameObject ballPrefab;

    // FixedUpdate for the move
    void Update()
    {
        // Grab inputs first
        // Keyboard 
        Vector3 translation = new Vector3(0, 0, 0);

        translation.z = Input.GetAxisRaw("Vertical");
        translation.x = Input.GetAxisRaw("Horizontal");
        translation.y = Input.GetAxisRaw("Jump");

        // Mouse 
        float horz = 0;
        float vert = 0;


        horz = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        vert = -Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        //  Relative translation because it depends on the normal
        translation *= Time.deltaTime * cameraSpeed;
        transform.Translate(translation);

        // Rotation
        if (Cursor.lockState != CursorLockMode.None)
        {
            transform.RotateAround(transform.position, Vector3.up, horz);
            Vector3 rot = transform.localRotation.eulerAngles;
            rot.x = (transform.localRotation.eulerAngles.x + 180) % 360 - 180 + vert;
            rot.x = Mathf.Clamp(rot.x, -clampAngle, clampAngle);
            transform.localRotation = Quaternion.Euler(rot);
        }


        // Mouse control
        if (Input.GetMouseButton(1)) // Right click
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // Mouse control
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            // Add stuff here
            Ray myRay;      // initializing the ray
            RaycastHit hit; // initializing the raycasthit
            public GameObject objectToinstantiate;
            void Update ()
            {
                myRay = Camera.main.ScreenPointToRay (Input.mousePosition); // telling my ray variable that the ray will go from the center of 
                if (Physics.Raycast (myRay, out hit)) { // here I ask : if myRay hits something, store all the info you can find in the raycasthit varible.
                if (Input.GetMouseButtonDown (0)) {// what to do if i press the left mouse button
             Instantiate (objectToinstantiate, hit.point, Quaternion.identity);// instatiate a prefab on the position where the ray hits the floor.
             Debug.Log (hit.point);// debugs the vector3 of the position where I clicked
         }// end upMousebutton
     }// end physics.raycast    
 }// end Update method
        }
    }
}
