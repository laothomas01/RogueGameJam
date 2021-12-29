using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int currentHealth = 10;
    public int deathTime = 0;
    [HideInInspector]
    public bool dead=false;
    private bool playerIsDead = false;
    AnimationHandler ah;
    public int damage;
    public bool damaged;
    private float time=0f;

    private void Start()
    {
        
        ah = GetComponent<AnimationHandler>();

    }
    public void Update()
    {
        if (damaged)
        {
            time += Time.deltaTime;
        }
        if(time > 0.5f)
        {
            damaged = false;
            time = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        damaged = true;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            dead = true;
            currentHealth = 0;
            Die();
        }
    }

    //touch damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        Player_Attributes pa = collision.gameObject.GetComponent<Player_Attributes>();
        if (collision.gameObject.tag == "Player")
        {
            if (pa != null)
            {
                pa.TakeDamage(damage);
            }
        }

    }

    private void Die()
    {
        Destroy(this.gameObject,deathTime);
    }
}
