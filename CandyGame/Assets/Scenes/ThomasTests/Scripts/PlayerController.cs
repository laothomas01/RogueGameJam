using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    //Ground Checks
    private RaycastHit2D hit;
    public float hitDistance = 1f;
    public bool grounded;

    //Jump Checks

    //public float jumpHeight = 3;
    public float highJump = 2.5f;
    public float lowJump = 2f;
    public bool jump = false;


    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private LayerMask GroundedMask;



    public bool facingRight = true;  // For determining which way the player is currently facing.
    public bool moving = false; //check whether the character is moving. 
    private Vector3 velocity = Vector3.zero;


    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    AnimationHandler ah;
    //player weapon
    public Gun weapon;



    private void Start()
    {
        ah = this.GetComponent<AnimationHandler>();
    }
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Gun>();
    }
    private void Update()
    {
        GroundCheck();
        Flip_Player_Based_On_Rotation_Of_The_Mouse_Input();
        //CheckFlip();

        //Flip_Player_Based_On_Rotation_Of_The_Mouse_Input();
        //if (transform.position.y - initgroundPos > jumpHeight && !grounded)
        //{
        //    Physics2D.gravity = new Vector2(0, -50);
        //    Debug.Log("Peak Reached");
        //}
        //else
        //{
        //    Physics2D.gravity = new Vector2(0, -9.81f);

        //}
        //if (grounded)
        //{
        //    initgroundPos = transform.position.y;
        //}

        //if falling increase gravity, else if holding jump, keep jumping until max height
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * highJump * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJump * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
        }


    }
    private void FixedUpdate()
    {


        Move();
        // Jump control and animation
        Jump();

    }





    private void GroundCheck()
    {

        hit = Physics2D.Raycast(transform.position, -transform.up, hitDistance, GroundedMask);
        Debug.DrawRay(transform.position, -transform.up * hitDistance, Color.red);

        grounded = hit ? true : false;

    }

    private void Move()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime;
        //only control the player if grounded or airControl is turned on
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
        rb.velocity = targetVelocity;

        if (rb.velocity.x != 0)
        {
            ah.ChangeAnimationState(ah.PLAYER_MOVEMENT);
        }
        else
        {
            ah.ChangeAnimationState(ah.PLAYER_IDLE);
        }
        //if (rb.velocity.x < 0)
        //{

        //}
        //else if (rb.velocity.x > 0)
        //{

        //}
        //else
        //{

        //}


    }


    public void Player_Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        //Vector3 scale = transform.localScale;
        //scale.x *= -1;
        //transform.localScale = scale;
        transform.Rotate(0f, 180f, 0f);
    }
    public void Flip_Player_Based_On_Rotation_Of_The_Mouse_Input()
    {

        Vector3 gunPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float thingy = gunPos.x - this.transform.position.x;
        float abs = Mathf.Abs(thingy);
        //float gunAngle = Mathf.Atan2(gunPos.y, gunPos.x) * Mathf.Rad2Deg;
        //Debug.Log(gunAngle);
        //Debug.Log(gunPos);
        if (facingRight)
        {
            if (weapon.rotationZ <= 90)
            {
                weapon.transform.rotation = Quaternion.Euler(weapon.transform.rotation.x, weapon.transform.rotation.y, weapon.rotationZ);
            }
            else if (weapon.rotationZ >= 270)
            {
                weapon.transform.rotation = Quaternion.Euler(weapon.transform.rotation.x, weapon.transform.rotation.y, weapon.rotationZ);
            }
            if (weapon.rotationZ > 90 && weapon.rotationZ < 270)
            {
                if (abs > 1)
                {

                    Player_Flip();
                }


            }
        }
        if (facingRight == false)
        {

        }
        //Debug.Log(weapon.rotationZ);
        //Debug.Log(facingRight);
        if (facingRight == false)
        {
            if (weapon.rotationZ >= 90)
            {
                weapon.transform.rotation = Quaternion.Euler(weapon.transform.rotation.x, weapon.transform.rotation.y, weapon.rotationZ);
            }
            else if (weapon.rotationZ <= 270)
            {
                weapon.transform.rotation = Quaternion.Euler(weapon.transform.rotation.x, weapon.transform.rotation.y, weapon.rotationZ);
            }
            if (weapon.rotationZ < 90 || weapon.rotationZ > 270)
            {
                //if (abs > 1)
                //{
                Player_Flip();

                weapon.rotationZ = 0;
                //}
            }
        }

    }


    private void Jump()
    {
        if (grounded && jump)
        {
            grounded = false;
            //rb.AddForce(new Vector2(0f, jumpForce));
            rb.velocity = Vector2.up * jumpForce;

        }
    }
}
