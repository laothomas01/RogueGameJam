using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    public bool flyVertical = false;
    public bool flyHorizontal = true;

    public float lifeTime = 1.0f;
    void Start()
    {
        if (flyVertical)
        {
            //Debug.Log("VERTICAL");
            rb.velocity = transform.up * speed;

        }
        else if (flyHorizontal)
        {
            //Debug.Log("Horizontal");
            rb.velocity = transform.right * speed;
        }

    }

    void Update()
    {
        SelfDestroy();
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Boss boss = hitInfo.GetComponent<Boss>();
        if (enemy != null)
        {

            if (enemy.health == 0)
            {
                return;
            }
            else
            {
                enemy.TakeDamage(damage);
            }
        }
        if (boss != null)
        {
            if (boss.health == 0)
            {
                return;
            }
            else
            {
                boss.TakeDamage(damage);
            }
        }

        //put code here later:
        //Instantiate(impactEffect,transform.positon,transform.rotation);
        Destroy(gameObject);
    }
    public void LogMessage()
    {
        Debug.Log("Hello World");
    }

    private void SelfDestroy()
    {
        //destroy object after a certain time. 
        Destroy(gameObject, lifeTime);
    }


}
