using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int currentHealth;
    public float deathTime = 0;
    [HideInInspector]
    public bool dead;
    private bool playerIsDead = false;
    AnimationHandler ah;
    public int damage;
    public bool damaged;
    private float time = 0f;
    private Resuable_Explosion_Script res;
    public bool explodable = false;
    private void Start()
    {
        dead = false;
        ah = GetComponent<AnimationHandler>();
        res = GetComponent<Resuable_Explosion_Script>();
    }
    public void Update()
    {
        if (damaged)
        {
            time += Time.deltaTime;
        }
        if (time > 0.5f)
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
                FindObjectOfType<SoundManager>().player_hurt("damage");
                pa.TakeDamage(damage);
            }
        }

        if (dead)
        {
            Physics2D.IgnoreLayerCollision(7, 6);
            Physics2D.IgnoreLayerCollision(6, 31);
        }


    }

    private void Die()
    {
        //Destroy(this.gameObject, deathTime);
        ////explode [ 1- >>>> 50 ]
        //if (explodable)
        //{
        //    res.explode();
        //    Destroy(this.gameObject, deathTime);
        //}
        //Debug.Log(dead);
        //dead = true;
        //res.explode();
        dead = true;
        res.explode();
        Destroy(this.gameObject, deathTime);


    }
}
