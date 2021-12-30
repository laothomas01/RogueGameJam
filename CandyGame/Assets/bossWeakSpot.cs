using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossWeakSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript boss = GetComponentInParent<EnemyScript>();


        if (collision.gameObject.tag == "bullet")
        {
            boss.TakeDamage(1);
            Debug.Log("Collisions");
        }

    }
}
