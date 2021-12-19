using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float speed = 20f;
    //public int damage = 1;
    public Rigidbody2D rb;

    public float lifeTime = 0.0f;
    void Start()
    {

    }

    void Update()
    {
        //SelfDestroy();
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo);

        //put code here later:
        //Instantiate(impactEffect,transform.positon,transform.rotation);
        //Destroy(gameObject);
    }


    private void SelfDestroy()
    {
        //destroy object after a certain time. 
        Destroy(gameObject, lifeTime);
    }


}
