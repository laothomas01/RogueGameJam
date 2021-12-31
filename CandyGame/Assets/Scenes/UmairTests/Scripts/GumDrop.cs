using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumDrop : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpInterval, jumpForce, distance, horiDis;
    private float time, horizontal,direction;
    private Transform Player;
    // Start is called before the first frame update
    void Awake()
    {
        time = 0;
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        }
        direction = Player.position.x - transform.position.x;

        if (time > jumpInterval)
        {
            
            if (Mathf.Abs(direction) < distance)
            {
                horizontal = direction/Mathf.Abs(direction);
            }
            else
            {
                horizontal = Random.Range(-1, 2);
            }
            
            
            rb.velocity = new Vector2(Vector2.right.x * horizontal*horiDis,Vector2.up.y* jumpForce);
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
        Debug.Log(direction);
        
    }
}
