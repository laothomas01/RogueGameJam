using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// SCRIPT USED TO MAINTAIN THE PLAYER'S MOVEMENTS
/// 
/// NOTE: MAKE SURE PLAYER IS GROUNDED.
/// </summary>
public class PlayerController : MonoBehaviour
{


    private Rigidbody2D rb;

    //Ground Checks
    private RaycastHit2D hit, enemyHit;
    public float hitDistance = 1f;
    public bool grounded;

    //Jump Checks

    public float highJump = 2.5f;
    public float lowJump = 2f;
    public static bool jump = false;
    private float time = 0;

    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private LayerMask GroundedMask;



    public bool facingRight = true;  // For determining which way the player is currently facing.
    public static bool walking;
    private Vector3 velocity = Vector3.zero;

    public float stepRate = 0.5f;
    public float stepcooldown;
    private float horizontalMove = 0f;
    public float runSpeed = 40f;


    //used to call animations we want to play
    AnimationHandler ah;

    //hit
    private Collider2D cl;

    //call the gun script
    public Gun weapon;

    Player_Attributes pa;

    [SerializeField] private float knockback;


    private void Start()
    {
        ah = this.GetComponent<AnimationHandler>();
        cl = GetComponent<Collider2D>();
        pa = this.GetComponent<Player_Attributes>();
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Gun>();
        walking = false;

    }

    private void Update()
    {
        stepcooldown -= Time.deltaTime;
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

        if (!Player_Attributes.playerIsDead)
        {
            if (!PauseController.gameisPaused)
            {
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

                if (stepcooldown < 0f)
                {
                    FindObjectOfType<SoundManager>().Step();
                    stepcooldown = stepRate;
                }



            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    return;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    return;
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    return;
                }

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartLevel();
            }
        }


        //if (moving)
        //{
        //    FindObjectOfType<SoundManager>().Play("HardShoesSound1");
        //}

    }

    private void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    private void FixedUpdate()
    {



        if (!pa.damaged)
        {
            Move();
            time = 0;
        }
        else
        {
            time += Time.fixedDeltaTime;


            if (time > 0.5)
            {
                pa.damaged = false;
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;

                }
                this.GetComponentInChildren<Gun>().enabled = true;
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

                walking = true;
                FindObjectOfType<SoundManager>().Step();

            }
            else
            {
                ah.ChangeAnimationState(ah.PLAYER_IDLE);
                walking = false;
            }
        }



    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.layer == 6)
        {

            pa.damaged = true;


            Vector2 norm = transform.position - col.transform.position;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;

            }
            this.GetComponentInChildren<Gun>().enabled = false;
            rb.AddForce(norm * knockback, ForceMode2D.Impulse);
            ah.ChangeAnimationState(ah.PLAYER_HURT);


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
            FindObjectOfType<SoundManager>().Play("JumpSound");
            rb.velocity = Vector2.up * jumpForce;
            ah.ChangeAnimationState(ah.PLAYER_JUMP);
            grounded = false;
        }
    }
}
