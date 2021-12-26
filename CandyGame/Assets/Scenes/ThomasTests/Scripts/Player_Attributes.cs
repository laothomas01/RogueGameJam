using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SCRIPT USED TO MANAGER PLAYER'S HEALTH
/// </summary>

public class Player_Attributes : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth = 0;
    private bool playerIsDead = false;
    AnimationHandler ah;
    private Rigidbody2D rb;


    public bool damaged;
    private float time = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ah = GetComponent<AnimationHandler>();
        currentHealth = maxHealth;

    }


    //player takes damage
    public void TakeDamage(int damage)
    {
        damaged = true;
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            playerIsDead = true;
            Die();
        }
    }

    //player heals health
    public void Heal(int heal)
    {

        if (playerIsDead)
        {
            return;
        }
        if (currentHealth > 0 && currentHealth <= maxHealth)
        {
            currentHealth += heal;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }


    }


    void Die()
    {

        //disable the child sprite renderers to properly show death animation
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }

        //this animation does not loop after the first play through
        ah.ChangeAnimationState(ah.PLAYER_DEATH);

        //disable player movement
        GetComponent<PlayerController>().enabled = false;
        this.GetComponentInChildren<Gun>().enabled = false;

    }




}
