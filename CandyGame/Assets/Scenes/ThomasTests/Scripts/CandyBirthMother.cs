using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBirthMother : MonoBehaviour
{
    [SerializeField] private float iFramesDuration;
    private bool isInvincible = false;
    public int health = 10;

    public Resuable_Explosion_Script res;

    private void Start()
    {



        res = GetComponent<Resuable_Explosion_Script>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Gives enemy invincibility in between taking damage.
        //if (!isInvincible)
        //{
        //    StartCoroutine(Invunerability());
        //}
        if (health <= 0)
        {
            Die();
        }
    }



    void Die()
    {


        StartCoroutine(DeleteObject());                 // Destroys enemy object after a fixed amount of time.
    }

    // Suspends time inbetween invulnerability frames.
    //public IEnumerator Invunerability()
    //{

    //    isInvincible = true;


    //    yield return new WaitForSeconds(iFramesDuration);

    //    isInvincible = false;

    //}


    // Destroys a game object after a given amount of time.
    //we will have baby candy children explode from this object
    public IEnumerator DeleteObject()
    {
        yield return new WaitForSeconds(0.5f);     // Waits 0.7 of a second.
        Destroy(gameObject);
        res.explodeSludge();
        res.explode_Out_HealthPacks();





    }

}
