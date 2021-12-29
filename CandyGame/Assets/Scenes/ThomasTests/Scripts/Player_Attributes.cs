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
    public static bool playerIsDead;
    AnimationHandler ah;
    private Rigidbody2D rb;
    public bool damaged;
    private float time = 0;
    public GameObject healthBar;
    private HealthBar hb;
    public GameObject GameOverScreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ah = GetComponent<AnimationHandler>();
        currentHealth = maxHealth;
        hb = healthBar.GetComponent<HealthBar>();
        playerIsDead = false;

    }


    //player takes damage
    public void TakeDamage(int damage)
    {
        damaged = true;
        currentHealth -= damage;
        hb.setHealth(currentHealth);

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
            hb.setHealth(currentHealth);
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            hb.setHealth(currentHealth);
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
        GameOverScreen.SetActive(true);


    }




}
