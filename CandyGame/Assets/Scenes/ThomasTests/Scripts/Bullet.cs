using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float speed = 20f;
    //public int damage = 1;
    public Rigidbody2D rb;

    public float lifeTime = 0.0f;
    float time = 0;
    public static int damage = 1;
    public float speed = 20f;
    public GameObject splat;
    //public Transform weaponPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        SelfDestroy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.layer == 6 && collision.gameObject.tag != "boss")
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            GameObject splt = Instantiate(splat, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(splt, 2);
        }
        else if (collision.gameObject.tag == "Player")
        {

            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            GameObject splt = Instantiate(splat, transform.position, transform.rotation);
            FindObjectOfType<SoundManager>().Play("splat");
            Destroy(gameObject);
            Destroy(splt, 2);
        }

    }
    private void SelfDestroy()
    {
        Destroy(gameObject, lifeTime);
    }


}
