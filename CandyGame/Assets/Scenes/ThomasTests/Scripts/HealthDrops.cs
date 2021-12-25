using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrops : MonoBehaviour
{
    public int heal = 1;
    public float lifeSpan;
    void Start()
    {

    }
    public void selfDestroy()
    {
        Destroy(this.gameObject, lifeSpan);
    }

    void Update()
    {
        selfDestroy();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Attributes pa = collision.gameObject.GetComponent<Player_Attributes>();
        if (collision.gameObject.tag == "Player")
        {
            if (pa != null)
            {
                pa.Heal(heal);
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
        }
    }



}
