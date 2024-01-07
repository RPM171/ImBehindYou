using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variables
    public float velocidad = 0f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad * Time.deltaTime;

        transform.Translate(movimiento, Space.Self);
        Run(Walk());
        animator.SetFloat("walk", velocidad);
    } 
    
    public void Run(bool walk)
    {
        if (Input.GetKey(KeyCode.LeftShift)&& walk ==true)
        {
            velocidad = 1f;
        }
        else if (walk == true)
        {
            velocidad = 0.25f;
        }
        else
        {
            velocidad = 0;
        }
        
    }
    public bool Walk()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            
            return false;
        }
       
    }

}

   /* public CharacterController controller;

    public float speed = 10f;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20f;

        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed = 5f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }*/


