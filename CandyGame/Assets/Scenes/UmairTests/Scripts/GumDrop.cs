using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumDrop : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpInterval;
    public float jumpForce;
    private float time;
    private float horizontal;
    // Start is called before the first frame update
    void Awake()
    {
        time = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time > jumpInterval)
        {
            horizontal = Random.Range(-1, 2);
            
            rb.velocity = new Vector2(Vector2.right.x * horizontal,Vector2.up.y* jumpForce);
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
        
    }
}
