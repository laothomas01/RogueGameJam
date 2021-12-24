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
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    string tag = collision.gameObject.tag;
    //    Player_Attributes pa = collision.GetComponent<Player_Attributes>();
    //    if (tag == "Player")
    //    {
    //        if (pa != null)
    //        {
    //            pa.Heal(1);

    //            Destroy(this.gameObject);
    //        }

    //    }



    //}
   

}
