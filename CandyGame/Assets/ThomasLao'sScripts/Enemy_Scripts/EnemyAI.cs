using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] private float distanceOffset;

    //float horizontalMove = 0f;

    Rigidbody2D rb2d;
    private double ENEMY_SCALE = 1.3;
    private Vector3 playerPosition;
    public Animator animator;
    public Player player;
    private int index = 0;
    private float wait;
    private bool StopPatrol = false;
    [SerializeField] private float initWait;

    [SerializeField] private List<Vector2> points = new List<Vector2>();
    [SerializeField] private List<Transform> points2 = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance to player
        if (StopPatrol == false)
        {
            Patrol();
        }

        //if (player.isPlayerDead != true)
        //{

        //    playerPosition = GameObject.FindWithTag("Player").transform.position;
        //    float distToPlayer = Vector2.Distance(transform.position, playerPosition);
        //    //print("distToPlayer:" + distToPlayer);

        //    if (distToPlayer < agroRange)
        //    {
        //        //code to chase player
        //        StopPatrol = true;
        //        ChasePlayer();
        //    }
        //    /*    else if (player.isPlayerDead == true) {
        //           StopChasingPlayer();
        //       } */
        //    else
        //    {
        //        //code to stop chasing player
        //        StopChasingPlayer();
        //    }


        //}






    }
    private void Patrol()
    {
        if (points.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[index], moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[index]) < distanceOffset)
            {
                if (wait <= 0)
                {
                    Flip();
                    index = (index + 1) % points.Count;
                    wait = initWait;
                }
                else
                {
                    wait -= Time.deltaTime;
                }
            }
        }
        else if (points2.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, points2[index].transform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, points2[index].transform.position) < distanceOffset)
            {
                if (wait <= 0)
                {
                    Flip();
                    index = (index + 1) % points2.Count;
                    wait = initWait;
                }
                else
                {
                    wait -= Time.deltaTime;
                }
            }
        }
    }

    private void ChasePlayer()
    {

        //StopPatrol = false;
        if (transform.position.x < playerPosition.x)
        {
            //enemy is to the left of player, enemy moves right 
            rb2d.velocity = new Vector2(moveSpeed * 1f, 0);
            animator.SetFloat("Speed", Mathf.Abs(moveSpeed * 1.2f));

            // flips the enemy sprite to 
            transform.localScale = new Vector2((float)-(ENEMY_SCALE), (float)ENEMY_SCALE);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed * 1f, 0);
            animator.SetFloat("Speed", Mathf.Abs(-moveSpeed * 1f));
            transform.localScale = new Vector2((float)ENEMY_SCALE, (float)ENEMY_SCALE);
        }

    }

    public void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        animator.SetFloat("Speed", Mathf.Abs(0));
    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, agroRange);
    }

    private void Flip()
    {


        transform.Rotate(0f, -180f, 0f);
        //// Multiply the player's x local scale by -1.
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
    }
}
