using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousSludge : MonoBehaviour
{
    public int damage = 1;
    public float lifeSpan;

    public void Update()
    {

        selfDestroy();
    }

    public void selfDestroy()
    {
        Destroy(this.gameObject, lifeSpan);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Player_Attributes pa = collision.gameObject.GetComponent<Player_Attributes>();
        if (collision.gameObject.tag == "Player")
        {

            if (pa != null)
            {
                pa.TakeDamage(damage);
            }
        }
    }




}

