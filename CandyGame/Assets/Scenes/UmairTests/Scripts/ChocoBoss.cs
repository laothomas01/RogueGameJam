using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoBoss : MonoBehaviour
{
    private float time,playerTime,injTime, direction,horizontal,range,jn,count;
    public float duration,hitPlayerTimer,injureTimer,distance,speed,jumpForce,horiDis,jumpNormalizer = 0;
    public Transform Player;
    public int SpawnCounter;
    public float intensity,groundHitDistance, playerDetector;
    private Vector2 forward, left, right,down ;
    [SerializeField] private LayerMask GroundedMask,PlayerMask;
    private int vertical;
    private Rigidbody2D rb;
    private RaycastHit2D leftHit, rightHit, downHit, groundHit,grounded;
    public bool spotted;
    Vector2 target;
    private EnemyScript choco;
    public GameObject mobSpawner;
    // Start is called before the first frame update
    void Start()
    {
        choco = GetComponent<EnemyScript>();
        spotted = false;
        vertical = 1;
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;
        jn = 1f;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

        forward = new Vector2(vertical * transform.right.x, vertical * transform.up.y);
        left = new Vector2(-transform.right.x*vertical, -transform.up.y*vertical);
        right = new Vector2(transform.right.x*vertical, -transform.up.y*vertical);
        down = vertical*-transform.up;


        groundHit = Physics2D.Raycast(transform.position, forward, groundHitDistance, GroundedMask);
        leftHit = Physics2D.Raycast(transform.position, left, groundHitDistance, PlayerMask);
        rightHit = Physics2D.Raycast(transform.position, right, groundHitDistance, PlayerMask);
        downHit = Physics2D.Raycast(transform.position, down, groundHitDistance, PlayerMask);
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 9.5f, GroundedMask);


        //Debug.DrawRay(transform.position, forward * groundHitDistance, Color.black);
        //Debug.DrawRay(transform.position, left * groundHitDistance, Color.green);
        //Debug.DrawRay(transform.position, right * groundHitDistance, Color.yellow);
        Debug.DrawRay(transform.position, down * groundHitDistance, Color.blue);

        time += Time.deltaTime;
        playerTime += Time.deltaTime;
        injTime += Time.deltaTime;
        if((downHit) && playerTime >hitPlayerTimer && injTime > injureTimer|| time > duration)
        {
            vertical *= -1;
            time = 0;
            range = 0;
            
        }

        if (choco.damaged)
        {
                vertical = -1;
                time = 0;
                injTime = 0;
                spotted = true;
            range = Random.Range(-1, 2);
            
            

        }
        else
        {
            count = 0;
        }
        if (choco.damaged && grounded && count < SpawnCounter)
        {
            count++;
            mobSpawner.GetComponent<MobSpawner>().Spawn();
        }

        //else if (leftHit)
        //{
        //    spotted = true;
        //     target = new Vector2(leftHit.transform.position.x,transform.position.y);

        //}
        //else if (rightHit)
        //{
        //     target = new Vector2(rightHit.transform.position.x, transform.position.y);
        //     spotted = true;
        //}

        //if (spotted)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //    if (Vector2.Distance(transform.position, target) <= 1f)
        //    {
        //        spotted = false;
        //    }
        //}

        direction = Player.position.x - transform.position.x;
        //Debug.Log(direction);
        if (Mathf.Abs(direction) < distance)
        {
            horizontal = direction / Mathf.Abs(direction);
        }
        else
        {
            horizontal = 0;
        }
        
        target = new Vector2(target.x, transform.position.y);
        //rb.velocity = Vector2.up * intensity * vertical;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            vertical *= -1;
            time = 0;
            playerTime = 0;
        }

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Collider2D col = GetComponent<Collider2D>();
        

    //        if (collision.gameObject.tag == "bullet")
    //        {
    //            vertical = -1;
    //            time = 0;
    //            injTime = 0;
    //            spotted = true;
    //            choco.TakeDamage(1);
    //            Debug.Log("Collisions");
    //        }
        
    //    Debug.Log(col.gameObject.name);
        
    //}

    private void FixedUpdate()
    {


        //target = new Vector2(target.x, transform.position.y);
        rb.AddForce(Vector2.up * intensity/jn * vertical, ForceMode2D.Force);

        
        if (vertical > 0)
        {
            rb.velocity = Vector2.right * horizontal * speed;
            jn = 1;
        }
        else
        {
            if(grounded && range < 0)
            {
                rb.AddForce(new Vector2(Vector2.right.x * horizontal * horiDis, Vector2.up.y * jumpForce), ForceMode2D.Impulse);
                jn = jumpNormalizer;
                
            }

        }
        
        
    }
}
