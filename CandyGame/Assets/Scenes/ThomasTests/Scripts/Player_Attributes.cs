using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Attributes : MonoBehaviour
{


    public int maxHealth = 10;
    public int currentHealth = 0;
    private Vector2 currentPosition;
    private bool playerIsDead = false;
    private bool isInvincible = false;
    AnimationHandler ah;
    [SerializeField] private float iFramesDuration;


    void Start()
    {
        ah = GetComponent<AnimationHandler>();
        currentHealth = maxHealth;
        currentPosition = this.transform.position;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }



    //player takes damage
    public void TakeDamage(int damage)
    {

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

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public IEnumerator Invunerability()
    //{

    //    Debug.Log("Player turned invincible!");
    //    isInvincible = true;


    //    yield return new WaitForSeconds(iFramesDuration);



    //    isInvincible = false;
    //    Debug.Log("Player no longer invincible!");

    //}
}
