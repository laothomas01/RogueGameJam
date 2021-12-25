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
    public Transform weaponPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //SelfDestroy();
        //SelfDisable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //CandyBirthMother cbm = collision.gameObject.GetComponent<CandyBirthMother>();
    //    //if (cbm != null)
    //    //{
    //    //    cbm.TakeDamage(damage);
    //    //    gameObject.SetActive(false);
    //    //    //Destroy(this.gameObject);
    //    //}


    //}
    ////private void OnCollision(Collider2D collision)
    ////{

    ////    //string tag = collision.gameObject.tag;
    ////    //CandyBirthMother cbm = collision.GetComponent<CandyBirthMother>();
    ////    //switch (tag)
    ////    //{
    ////    //    case "wall":
    ////    //        gameObject.SetActive(false);
    ////    //        break;
    ////    //    case "enemy":
    ////    //        Debug.Log("Enemy Hit");
    ////    //        if (cbm != null)
    ////    //        {
    ////    //            cbm.TakeDamage(damage);
    ////    //        }
    ////    //        gameObject.SetActive(false);
    ////    //        break;
    ////    //}
    ////    //CandyBirthMother cbm = collision.GetComponent<CandyBirthMother>();
    ////    //if (cbm != null)
    ////    //{
    ////    //    //    cbm.TakeDamage(damage);
    ////    //    Destroy(this.gameObject);
    ////    //}



    ////}




    //private void SelfDestroy()
    //{
    //    //destroy object after a certain time. 
    //    //Destroy(gameObject, lifeTime);
    //    time += Time.deltaTime;
    //    //Debug.Log(time);
    //    if (time > lifeTime)
    //    {
    //        Destroy(this.gameObject);
    //        time = 0;
    //    }
    //}


}
