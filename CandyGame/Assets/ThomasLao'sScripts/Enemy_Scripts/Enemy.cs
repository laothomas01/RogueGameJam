using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 
 * Enemy must have BoxCollider2D to use this script
 */
public class Enemy : MonoBehaviour
{

    [SerializeField] private float iFramesDuration;
    private bool isInvincible = false;
    public int health = 10;
    //public GameObject deathEffect; //implement later
    public Animator animator;

    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");                   // Animator component to trigger the enemy hurt animation.

        // Gives enemy invincibility in between taking damage.
        if (!isInvincible)
        {
            StartCoroutine(Invunerability());
        }
        if (health <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        //Debug.Log("Enemy Died!");
        animator.SetBool("isDead", true);                // Animator component to set death animation to true.

        GetComponent<EnemyAI>().enabled = false;        // Disables Enemy AI and movement
        Physics2D.IgnoreLayerCollision(8, 9, true);      // Collision of dying enemy is ignored.

        StartCoroutine(DeleteObject());                 // Destroys enemy object after a fixed amount of time.
    }

    // Suspends time inbetween invulnerability frames.
    public IEnumerator Invunerability()
    {

        //Debug.Log("enemy turned invincible!");
        isInvincible = true;
        Physics2D.IgnoreLayerCollision(8, 9, true);      // Removes collision properties for enemy to mimick invulnerability.


        yield return new WaitForSeconds(iFramesDuration);

        Physics2D.IgnoreLayerCollision(8, 9, false);     // Restores collision properties for enemy.
        isInvincible = false;
        //Debug.Log("enemy no longer invincible!");

    }


    // Destroys a game object after a given amount of time.
    public IEnumerator DeleteObject()
    {
        yield return new WaitForSeconds(0.5f);     // Waits 0.7 of a second.
        Destroy(gameObject);
    }





}
