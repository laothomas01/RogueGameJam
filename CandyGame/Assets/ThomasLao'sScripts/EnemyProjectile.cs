using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool flyHorizontal = true;
    public float lifeTime = 5.0f; // bullets will last 5 seconds
    public int damage = 1;
    private GameObject firePoint;
    public GameObject player;

    private void Start()
    {
        if (flyHorizontal)
        {
            rb.velocity = transform.right * -1 * speed; // shoot left
        }

    }
    private void Update()
    {
        Self_Destroy();
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            if (player.currentHealth == 0)
            {
                return;
            }
            else
            {
                player.TakeDamage(damage);
            }
        }
    }
    private void Self_Destroy()
    {
        Destroy(gameObject, lifeTime);
    }


}
