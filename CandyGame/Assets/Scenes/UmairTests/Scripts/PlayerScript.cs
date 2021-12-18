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
    private float initgroundPos;
    public float jumpHeight = 3;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;  
    [SerializeField] private LayerMask GroundedMask;                    
    
    
    
    private bool facingRight = true;  // For determining which way the player is currently facing.
    public bool moving = false; //check whether the character is moving. 
    private Vector3 velocity = Vector3.zero;


    private float horizontalMove = 0f;
    public float runSpeed = 35f;
    


    public UnityEvent OnLandEvent;

    public class BoolEvent : UnityEvent<bool> { }


    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        initgroundPos = transform.position.y;
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed*Time.fixedDeltaTime;
        Move();
        // Jump control and animation
        GroundCheck();

        if(transform.position.y - initgroundPos > jumpHeight && !grounded)
        {
            Physics2D.gravity = new Vector2(0, -50);
            Debug.Log("Peak Reached");
        }
        else
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
            
        }
        if (grounded)
        {
            initgroundPos = transform.position.y;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Jump();
        }
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
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

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


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        if (grounded)
        {
            grounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }
}



