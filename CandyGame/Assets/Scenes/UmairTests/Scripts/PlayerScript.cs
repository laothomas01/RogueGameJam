using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
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


    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        GroundCheck();
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
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime;

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


        //only control the player if grounded or airControl is turned on
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
        rb.velocity = targetVelocity;

        // If the input is moving the player right and the player is facing left...
        if (horizontalMove > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }


    }


    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
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



