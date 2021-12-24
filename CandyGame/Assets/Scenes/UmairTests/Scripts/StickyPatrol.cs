using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private RaycastHit2D[] hits = new RaycastHit2D[4];
    private RaycastHit2D forwardHit;
    private RaycastHit2D currentGroundHit;
    public float hitDistance,speed;
    [SerializeField] private LayerMask GroundedMask;
    public Vector2 gravity = new Vector2(0f, -1f);
    public bool grounded;
    private float time=0;
    Quaternion newRot;
    // Start is called before the first frame update
    void Start()
    {
        
        
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        newRot = Quaternion.LookRotation(Vector3.forward, transform.up);
        //transform.right = -transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        gravity = -transform.up;

        Vector2 forward = new Vector2(transform.right.x, -transform.up.y);
        //Vector2 back= new Vector2(-transform.right.x, -transform.up.y);
        //Debug.DrawRay(transform.position, -transform.up * hitDistance, Color.red);
        Debug.DrawRay(transform.position, forward * hitDistance, Color.black);
        //Debug.DrawRay(transform.position, transform.right * hitDistance, Color.yellow);
        //Debug.DrawRay(transform.position, back * hitDistance, Color.blue);
        forwardHit = Physics2D.Raycast(transform.position, forward, hitDistance, GroundedMask);
        if (currentGroundHit)
        {
            grounded = true;
        }
        else
        {
            //Debug.Log("NOT GROUNDED");
            grounded = false;
        }

        for (int i=1; i<= hits.Length/2; i++)
        {
            int dir = i % 2 == 0 ? 1 : -1;
            hits[i] = Physics2D.Raycast(transform.position, dir*transform.up, hitDistance, GroundedMask);
            hits[i+1] = Physics2D.Raycast(transform.position, dir*transform.right, hitDistance, GroundedMask);

            

            if(hits[i] || hits[i + 1]){
                currentGroundHit = hits[i] ? hits[i] : hits[i + 1];
            }


            if ((hits[i] ) && !forwardHit)
            {
                //transform.right = gravity;
                //transform.up = hits[i].normal;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, hits[i].normal);
                Debug.DrawRay(transform.position, dir * transform.up * hitDistance, Color.green);
                Debug.DrawRay(transform.position, dir * transform.right * hitDistance, Color.blue);

            }
            else if((hits[i+1])&& !forwardHit)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, hits[i+1].normal);

                //transform.right = gravity;
                //transform.up = hits[i+1].normal;
                Debug.DrawRay(transform.position, dir * transform.up * hitDistance, Color.cyan);
                Debug.DrawRay(transform.position, dir * transform.right * hitDistance, Color.grey);

            }
            
          

        }
        

        //groundHit = Physics2D.Raycast(transform.position, -transform.up, hitDistance, GroundedMask);
        
        //backHit = Physics2D.Raycast(transform.position, back, hitDistance, GroundedMask);
        //Debug.DrawRay(transform.position, gravity * 50, Color.yellow);
        //if (groundHit)
        //{
        //    grounded = true;
        //}

        //Debug.Log(groundHit.transform.name);
        //if (!forwardHit && !groundHit && grounded)
        //{
        //    transform.right = Vector2.Lerp(transform.right, -transform.up,0);
        //    //transform.right = -transform.up;
        //    //gravity = -transform.up;
        //    gravity = Vector2.Lerp(gravity, -transform.up, 0);
        //    grounded = false;
        //}



    }


    private void FixedUpdate()
    {
        rb.AddForce(gravity * 100f, ForceMode2D.Force);
        if (grounded)
        {
            rb.velocity = transform.right * speed;
            time = 0;
            
        }
        if (!grounded)
        {
            time += Time.fixedDeltaTime;
            if(time > 1)
            {
                gravity = -transform.up;
            }
        }
        
    }
}
