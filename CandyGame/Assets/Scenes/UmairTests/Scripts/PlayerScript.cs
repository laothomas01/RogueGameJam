using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;

    //Ground Checks
    private RaycastHit2D hit,enemyHit;
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



    private bool facingRight = true;  // For determining which way the player is currently facing.
    public bool moving = false; //check whether the character is moving. 
    private Vector3 velocity = Vector3.zero;


    public float horizontalMove = 0f;
    public float runSpeed = 40f;

    private bool damaged;
    public float hitDamage=5;
    private float time = 0;
    Color curr;
   

    private void Awake()
    {
        damaged = false;
        cl = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        curr = GetComponent<SpriteRenderer>().color;
        //Physics2D.IgnoreLayerCollision(31, 6, true);
    }

    private void Update()
    {
        GroundCheck();

        //cl.sharedMaterial.friction = grounded ? 10f : 0f;
        //cl.sharedMaterial. = grounded ? 10f : 0f;
        //Debug.Log(cl.friction);
        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire1")){
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
        }

        

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 6)
        {
             float dis =  transform.position.x- col.transform.position.x;
            dis = dis>0?1f:-1f;
            //Vector2 norm = new Vector2((dis)*2f, 2f);
            Vector2 norm = transform.position - col.transform.position;
            Debug.Log(norm+","+dis);
            damaged = true;
            rb.AddForce(norm*hitDamage,ForceMode2D.Impulse);
            
            Debug.DrawRay(transform.position,  norm*5, Color.red);
        }
    }
    private void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Vertical") == 0 ? transform.right.x : Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(horizontal, Input.GetAxisRaw("Vertical"));
        arm.transform.right = direction;


        if (!damaged)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime;
            Move();
            time = 0;
        }
        else
        {
            time += Time.fixedDeltaTime;
            
            GetComponent<SpriteRenderer>().color = Color.red;
            if(time > 0.2)
            {
                GetComponent<SpriteRenderer>().color = curr;
            }
            if(time > 1)
            {
                
                damaged = false;
            }
        }
        
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


    private void Flip()
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer != 3)
    //    {
    //        Debug.Log(collision.transform.name);
    //        Physics2D.IgnoreCollision(collision.collider , GetComponent<Collider2D>(),true);
    //    }
    //}
}



