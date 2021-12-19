using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;

    //bullet
    public GameObject bullet;
    public Transform firepoint;
    public GameObject arm;

    //Ground Checks
    private RaycastHit2D hit;
    public float hitDistance = 1f;
    public bool grounded;
    private Collider2D cl;

    //Jump Checks
   
    public float highJump = 2.5f;
    public float lowJump = 2f;

    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;  
    [SerializeField] private LayerMask GroundedMask;                    
    
    
    
    private bool facingRight = true;  // For determining which way the player is currently facing.
    public bool moving = false; //check whether the character is moving. 
    private Vector3 velocity = Vector3.zero;


    private float horizontalMove = 0f;
    public float runSpeed = 40f;
   

    private void Awake()
    {
        cl = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        GroundCheck();

        //cl.sharedMaterial.friction = grounded ? 10f : 0f;
        //cl.sharedMaterial. = grounded ? 10f : 0f;
        Debug.Log(cl.friction);
        if (Input.GetKeyDown(KeyCode.X)){
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * highJump * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJump * Time.deltaTime;
        }

    }
    private void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Vertical") == 0 ? transform.right.x : Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(horizontal, Input.GetAxisRaw("Vertical"));
        arm.transform.right = direction;



        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed*Time.fixedDeltaTime;
        Move();
        // Jump control and animation
        
        if (Input.GetKeyDown(KeyCode.Space))
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
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
        if(Input.GetAxisRaw("Vertical") == 0)
        {
            rb.velocity = targetVelocity;
        }
            

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
            //rb.AddForce(new Vector2(0f, jumpForce));
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}



