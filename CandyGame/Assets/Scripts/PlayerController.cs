using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

   //private variables
    private Rigidbody2D rb;
    private float inputX;

    //public variables
    public float moveSpeed, jumpspeed;
    private bool isGrounded, canJump, isIdle;
    public Animator anim;
    public SpriteRenderer rend;
     
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "flag")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "die")
        {
            Destroy(gameObject);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if (collision.gameObject.tag == "enemy")
        {
            PlayerHealth.health -= .5f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if (isGrounded && Input.GetButton("Jump")){
            isIdle = false;
            canJump = true;
        }
        else {
            isIdle = true;
            canJump = false;
        }

        if (Input.GetButtonDown("Fire1")){
            isIdle = false;
            anim.SetBool("IsShooting", true);
        }
        else {
            isIdle = true;
            anim.SetBool("IsShooting", false);
        }


        if (canJump == true){
            isIdle = false;
            anim.SetBool("IsJumping", true);
        }
        else {
            isIdle = true;
            anim.SetBool("IsJumping", false);
        }

        if (inputX != 0){
            isIdle = false;
            anim.SetBool("IsRunning", true);
            rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
        }
        else{
            isIdle = true;
            anim.SetBool("IsRunning", false);
        }

        if (isIdle == true) {
            anim.SetBool("IsIdle", false);
        }

        //make the sprite face the direction we move by flipping it
        if (inputX > 0)
        {
            rend.flipX = false;
        }
        else {
            rend.flipX = true;
        }
    }
    private void FixedUpdate()
    {
        //animations and jumping
        if (canJump == true)
        {
            
            rb.AddForce(Vector2.up * jumpspeed);
        }
    }
}

