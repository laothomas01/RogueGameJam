using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyChildren : MonoBehaviour
{
    [SerializeField] float aggroRange;
    [SerializeField] float moveSpeed;
    public float jumpInterval;
    public float jumpForce;
    private float time;
    private float horizontal;
    Rigidbody2D rb2d;
    private Vector2 playerPosition;
    [SerializeField] private float initWait;
    private void Start()
    {
        time = 0;
        rb2d = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        float distToPlayer = Vector2.Distance(transform.position, playerPosition);
        if (aggroRange > distToPlayer)
        {
            ChasePlayer();
        }
    }
    private void ChasePlayer()
    {
        jumpInterval = Random.Range(1, 3);
        jumpForce = Random.Range(-1, 5);
        moveSpeed = Random.Range(1, 5);
        initWait += Time.deltaTime;
        if (initWait > 5)
        {
            if (transform.position.x < playerPosition.x)
            {
                if (time > jumpInterval)
                {

                    rb2d.velocity = new Vector2(Vector2.right.x * moveSpeed, Vector2.up.y * jumpForce);
                    time = 0;
                }
                else
                {
                    time += Time.deltaTime;
                }
            }
            else
            {
                if (time > jumpInterval)
                {
                    horizontal = Random.RandomRange(1, 3);
                    rb2d.velocity = new Vector2(-Vector2.right.x * moveSpeed, Vector2.up.y * jumpForce);
                    time = 0;
                }
                else
                {
                    time += Time.deltaTime;
                }
            }
        }
    }
    //void OnDrawGizmos()
    //{

    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(this.transform.position, aggroRange);
    //}
}
