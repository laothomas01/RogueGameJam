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

    //player weapon
    public Weapon weapon;

    private void Start()
    {

    }
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
    }
    private void Update()
    {
        GroundCheck();
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
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime;
        Flip_Player_Based_On_Rotation_Of_The_Mouse_Input();
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



    }

    public void CheckFlip()
    {

        // If the input is moving the player right and the player is facing left...
        if (horizontalMove > 0 && !facingRight)
        {
            // ... flip the player.
            Movement_Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove < 0 && facingRight)
        {
            // ... flip the player.
            Movement_Flip();
        }

    }
    public void Movement_Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        //transform.Rotate(0f, 180f, 0f);
    }
    public void Flip_Player_Based_On_Rotation_Of_The_Mouse_Input()
    {

        //Vector3 gunPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float gunAngle = Mathf.Atan2(gunPos.y, gunPos.x) * Mathf.Rad2Deg;
        //Debug.Log(gunAngle);
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
                Movement_Flip();
            }

        }
        Debug.Log(weapon.rotationZ);
        Debug.Log(facingRight);
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
                Movement_Flip();
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



