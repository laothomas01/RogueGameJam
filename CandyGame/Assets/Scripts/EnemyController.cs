using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //private variables
    private Rigidbody2D rb;

    //public variables
    public float accelerationTime = .5f;
    public float maxSpeed = 10f;
    private Vector2 movement;
    private float timeLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), 0);
            timeLeft += accelerationTime;
        }
     

    }
    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }
}
