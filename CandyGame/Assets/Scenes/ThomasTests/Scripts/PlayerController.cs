using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// SCRIPT USED TO MAINTAIN THE PLAYER'S MOVEMENTS
/// </summary>
public class PlayerController : MonoBehaviour
{


    private Rigidbody2D rb;

    //Ground Checks
    private RaycastHit2D hit;
    public float hitDistance = 1f;
    public bool grounded;

    //Jump Checks

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

    //used to call animations we want to play
    AnimationHandler ah;

    //call the gun script
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }


    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

        if (grounded)
        {
            if (rb.velocity.x != 0)
            {
                ah.ChangeAnimationState(ah.PLAYER_MOVEMENT);

            }
            else
            {
                ah.ChangeAnimationState(ah.PLAYER_IDLE);
            }
        }



    }


    public void Player_Flip()
    {
        // Switch the way the player is facing. 
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
    public void Flip_Player_Based_On_Rotation_Of_The_Mouse_Input()
    {

        //gunPos is the position of our mouse cursor from screen to the game's world
        Vector3 gunPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // thingy is the position between the gun and the player object
        float thingy = gunPos.x - this.transform.position.x;
        float abs = Mathf.Abs(thingy);

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
                Player_Flip();

                weapon.rotationZ = 0;
            }
        }

    }


    private void Jump()
    {
        if (grounded && jump)
        {

            rb.velocity = Vector2.up * jumpForce;
            ah.ChangeAnimationState(ah.PLAYER_JUMP);
            grounded = false;



        }
    }
}
