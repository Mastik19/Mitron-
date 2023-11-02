using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;
    Vector3 direction;
    Vector3 velocity;

    InputAction move;
    InputAction jump;

    public Joystick joystick;

    public float speed;
    public float jumpHeight;
    public float gravity;

    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float radius;

    public Animator anim;


    void Start()
    {
        radius = 0.3f;
        controller = GetComponent<CharacterController>();
        speed = 10;
        gravity = -35;

        
        jump = new InputAction("PlayerJump", binding: "<keyboard>/space");

        move = new InputAction("PlayerMove", binding: "<Gamepad>/leftStick");
        move.AddCompositeBinding("Dpad").With("Up", binding: "<keyboard>/w").With("Up", binding: "<keyboard>/upArrow")
            .With("Down", binding: "<keyboard>/s").With("Down", binding: "<keyboard>/downArrow")
            .With("Left", binding: "<keyboard>/a").With("Left", binding: "<keyboard>/leftArrow")
            .With("Right", binding: "<keyboard>/d").With("Right", binding: "<keyboard>/rightArrow");

        move.Enable();
        jump.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        float x = joystick.Horizontal; //move.ReadValue<Vector2>().x
        float z = joystick.Vertical;  //move.ReadValue<Vector2>().y; 

        direction = transform.right * x + transform.forward * z;
        if(direction != Vector3.zero)
        {
         

            anim.SetBool("isMoving", true);

            if (z >0.6f)
            {
                anim.SetBool("isRunning", true);
                speed = 15;
            }
            else
            {
                speed = 10;
                anim.SetBool("isRunning", false);
            }
            
            
        }
        else
        {
            anim.SetBool("isMoving", false);
           
        }
        controller.Move(direction * speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, radius, groundLayer);
        
        if(isGrounded)
        {
            if (CrossPlatformInputManager.GetButtonDown("jump"))  //Mathf.Approximately(jump.ReadValue<float>(), 1)
            {
                Jump();
            }

        }
        else
        {
            velocity.y += gravity * Time.deltaTime;

        }

        controller.Move(velocity * Time.deltaTime);
       


        
    }

    public void Jump()
    {
        Debug.Log("Jump");
        velocity.y = Mathf.Sqrt(jumpHeight * 2 * (-gravity));
    }
}
