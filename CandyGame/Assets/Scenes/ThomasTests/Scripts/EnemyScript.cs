using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int currentHealth = 10;
    private bool playerIsDead = false;
    AnimationHandler ah;
    public int damage;
    public bool damaged;
    private void Start()
    {

        ah = GetComponent<AnimationHandler>();

    }

    public void TakeDamage(int damage)
    {
        damaged = true;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    //touch damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        Destroy(this.gameObject);
    }
}
