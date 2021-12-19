using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float startTime = 0;
    public bool jump = false;

    //int jumpClickCount = 0;
    // Start is called before the first frame update
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Keeps same speed in each horizontal direction
        //controller.animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Jump control and animation
        if (Input.GetKeyDown(KeyCode.W))
        {

            jump = true;

            startTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log(Time.time - startTime);
            if (Time.time - startTime < 0.6f)
            {
                controller.m_Rigidbody2D.gravityScale = 15f;
            }
            else if (Time.time - startTime <= 1.5 && Time.time - startTime >= 0.6f)
            {
                controller.m_Rigidbody2D.gravityScale = 12.5f;
            }
            else if (Time.time - startTime >= 1.5)
            {
                controller.m_Rigidbody2D.gravityScale = 10f;
            }

        }
        if (jump)
        {
            controller.m_AirControl = true;
        }



    }

    public void OnLanding()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }


}
