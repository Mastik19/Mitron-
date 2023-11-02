using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity;
    float xRotation;
    float mouseX, mouseY;
    void Start()
    {
        mouseSensitivity = 1.5f;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {


        mouseX = 0;
        mouseY = 0;


        //if (Mouse.current != null)
        //{
        //    mouseX = Mouse.current.delta.ReadValue().x;
        //    mouseY = Mouse.current.delta.ReadValue().y;


        //}


        if (Touchscreen.current.touches.Count > 0 && Touchscreen.current.touches[0].isInProgress)
        {
            if (EventSystem.current.IsPointerOverGameObject(Touchscreen.current.touches[0].touchId.ReadValue()))
            {
                mouseX = Touchscreen.current.touches[1].delta.ReadValue().x;
                mouseY = Touchscreen.current.touches[1].delta.ReadValue().y;
            }

            else
            {
                mouseX = Touchscreen.current.touches[0].delta.ReadValue().x;
                mouseY = Touchscreen.current.touches[0].delta.ReadValue().y;
            }



        }



        mouseX *= mouseSensitivity;
        mouseY *= mouseSensitivity;
        

        xRotation -= mouseY * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -70, 70);

        transform.localRotation = Quaternion.Euler(xRotation,0,0 );

        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
        
    }
}
