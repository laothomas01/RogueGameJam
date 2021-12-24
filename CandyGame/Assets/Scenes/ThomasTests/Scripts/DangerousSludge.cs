using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousSludge : MonoBehaviour
{
    public int damage = 1;
    public float lifeSpan;
    //public GameObject player;
    // Start is called before the first frame update

    public void Update()
    {

        selfDestroy();
    }

    public void selfDestroy()
    {
        Destroy(this.gameObject, lifeSpan);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        Player_Attributes pa = collision.GetComponent<Player_Attributes>();
        if (tag == "Player")
        {
            if (pa != null)
            {
                pa.TakeDamage(damage);
            }
        }
    }



}

