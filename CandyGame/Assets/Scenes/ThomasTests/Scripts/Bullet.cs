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
    int damage = 1;
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
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            GameObject splt = Instantiate(splat, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(splt, 2);
        }
        else
        {
            GameObject splt = Instantiate(splat, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(splt, 2);
        }

    }
    private void SelfDestroy()
    {
        Destroy(gameObject, lifeTime);
    }


}
