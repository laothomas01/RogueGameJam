using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{

    public float moveDistance=10f;
    public float hitDistance=2f;
    private RaycastHit2D hit;
    private bool playerSpotted;
    [SerializeField] private LayerMask GroundedMask;
    private Rigidbody2D rb;
    public float speed;

    private Vector2 pos;


    // Start is called before the first frame update
    void Start()
    {
        playerSpotted = false;
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        hit = Physics2D.Raycast(transform.position, -transform.up, hitDistance, GroundedMask);

      
        if (!playerSpotted && hit)
        {
            if(Mathf.Abs(transform.position.x)-Mathf.Abs(pos.x) < 10)
            {
                rb.velocity = transform.right * speed;
            }
            else if(Mathf.Abs(pos.x)-Mathf.Abs(transform.position.x) < 10)
            {
                rb.velocity = -transform.right * speed;
            }
            
        }
    }
}
