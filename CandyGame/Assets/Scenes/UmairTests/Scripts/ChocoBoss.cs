using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoBoss : MonoBehaviour
{
    private float time;
    public float duration,speed = 0;
    public float intensity,groundHitDistance, playerDetector;
    private Vector2 forward, left, right,down ;
    [SerializeField] private LayerMask GroundedMask,PlayerMask;
    private int direction;
    private Rigidbody2D rb;
    private RaycastHit2D leftHit, rightHit, downHit, groundHit;
    private bool spotted;
    Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        spotted = false;
        direction = 1;
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        forward = new Vector2(direction * transform.right.x, direction * transform.up.y);
        left = new Vector2(-transform.right.x*direction, -transform.up.y*direction);
        right = new Vector2(transform.right.x*direction, -transform.up.y*direction);
        down = direction*-transform.up;


        groundHit = Physics2D.Raycast(transform.position, forward, groundHitDistance, GroundedMask);
        leftHit = Physics2D.Raycast(transform.position, left, groundHitDistance, PlayerMask);
        rightHit = Physics2D.Raycast(transform.position, right, groundHitDistance, PlayerMask);
        downHit = Physics2D.Raycast(transform.position, down, groundHitDistance, PlayerMask);


        Debug.DrawRay(transform.position, forward * groundHitDistance, Color.black);
        Debug.DrawRay(transform.position, left * groundHitDistance, Color.green);
        Debug.DrawRay(transform.position, right * groundHitDistance, Color.yellow);
        Debug.DrawRay(transform.position, down * groundHitDistance, Color.blue);

        time += Time.deltaTime;
        if(downHit || time > duration)
        {
            direction *= -1;
            time = 0;
        }
        else if (leftHit)
        {
            spotted = true;
             target = new Vector2(leftHit.transform.position.x,transform.position.y);
            
        }
        else if (rightHit)
        {
             target = new Vector2(rightHit.transform.position.x, transform.position.y);
             spotted = true;
        }

        if (spotted)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target) <= 2f)
            {
                spotted = false;
            }
        }

        target = new Vector2(target.x, transform.position.y);
        rb.velocity = Vector2.up * intensity * direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            direction *= -1;
        }
    }

    private void FixedUpdate()
    {


        target = new Vector2(target.x, transform.position.y);
        rb.velocity = Vector2.up * intensity * direction;
    }
}
