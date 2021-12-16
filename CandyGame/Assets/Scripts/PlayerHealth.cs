using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float health;
    private Vector2 size;

    void Start()
    {
        health = 1.5f;
    }
    void Update()
    {
        transform.localScale = new Vector2(health, health);

        if (health < 1) {
            Destroy(gameObject);
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "drop" )
        {
            if (health < 2)
            {
                health += .1f;

                collision.gameObject.GetComponent<ParticleSystem>().Play();

                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

                Destroy(collision.gameObject, .5f);
            }
            else {
                collision.gameObject.GetComponent<ParticleSystem>().Play();

                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

                Destroy(collision.gameObject, .5f);
            }
        }
    }
}
