using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private RaycastHit2D[] hits = new RaycastHit2D[4];

    private RaycastHit2D forwardHit, wallHit, currentGroundHit;
    public float hitDistance, speed, gravityForce, dlDistance;

    [SerializeField] private LayerMask GroundedMask;
    private Vector2 gravity = new Vector2(0f, -1f);
    public bool grounded;
    private float time = 0;
    Quaternion newRot;
    public bool right = true;
    private Vector3 forwardRotation;
    private Color curr;
    private EnemyScript enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        curr = GetComponent<SpriteRenderer>().color;
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        newRot = Quaternion.LookRotation(Vector3.forward, transform.up);
        //transform.right = -transform.right;
        if (!right)
        {
            transform.right = -transform.right;
            forwardRotation = -Vector3.forward;
        }
        else
        {
            forwardRotation = Vector3.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = enemy.damaged ? Color.red : curr;
        gravity = -transform.up;
        Vector2 forward = new Vector2(transform.right.x, -transform.up.y);

        Debug.DrawRay(transform.position, forward * hitDistance, Color.black);
        forwardHit = Physics2D.Raycast(transform.position, forward, hitDistance, GroundedMask);
        grounded = onTheGround();

        wallHit = Physics2D.Raycast(transform.position, transform.right, hitDistance, GroundedMask);
        if (wallHit)
        {
            Debug.DrawRay(transform.position, transform.up * hitDistance, Color.green);

            Debug.DrawRay(transform.position, transform.right * hitDistance, Color.blue);
            transform.rotation = Quaternion.LookRotation(forwardRotation, -transform.right);
        }

        for (int i = 1; i <= hits.Length / 2; i++)
        {
            int dir = i % 2 == 0 ? 1 : -1;
            if (i == 0)
            {
                Debug.DrawRay(transform.position, dir * transform.up * (hitDistance + dlDistance), Color.red);
                Debug.DrawRay(transform.position, dir * transform.right * (hitDistance + dlDistance), Color.blue);

            }
            hits[i] = Physics2D.Raycast(transform.position, dir * transform.up, hitDistance, GroundedMask);
            hits[i + 1] = Physics2D.Raycast(transform.position, dir * transform.right, hitDistance, GroundedMask);

        



            if (hits[i] || hits[i + 1])
            {
                currentGroundHit = hits[i] ? hits[i] : hits[i + 1];
            }


            if ((hits[i]) && !forwardHit)
            {
                //transform.right = gravity;
                //transform.up = hits[i].normal;
                transform.rotation = Quaternion.LookRotation(forwardRotation, hits[i].normal);
                Debug.DrawRay(transform.position, dir * transform.up * hitDistance, Color.green);
                Debug.DrawRay(transform.position, dir * transform.right * hitDistance, Color.blue);

            }
            else if ((hits[i + 1]) && !forwardHit)
            {
                transform.rotation = Quaternion.LookRotation(forwardRotation, hits[i + 1].normal);

                //transform.right = gravity;
                //transform.up = hits[i+1].normal;
                Debug.DrawRay(transform.position, dir * transform.up * hitDistance, Color.cyan);
                Debug.DrawRay(transform.position, dir * transform.right * hitDistance, Color.grey);

            }

            if (this.GetComponent<EnemyScript>().damaged)
            {
                FindObjectOfType<SoundManager>().Play("wormhit");
            }
            if (this.GetComponent<EnemyScript>().dead)
            {
                FindObjectOfType<SoundManager>().Play("sizzle");
            }

        }

 

        bool onTheGround()
        {

            for(int i=0; i < hits.Length; i++)
            {
                if (hits[i])
                {
                    return true;
                }
            }
            return false;
        }


    }


    private void FixedUpdate()
    {
        rb.AddForce(gravity * gravityForce, ForceMode2D.Force);

        if (grounded || time < 0.5f)

        {
            rb.velocity = transform.right * speed;
            time = 0;

        }
        if (!grounded)
        {
            time += Time.fixedDeltaTime;

            if(time > 2)

            {
                gravity = -Vector2.up;
            }
        }

    }
}
