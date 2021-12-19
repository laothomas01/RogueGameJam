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
    void Start()
    {

    }

    void Update()
    {
        //SelfDestroy();
        SelfDisable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        string tag = collision.gameObject.tag;
        switch (tag)
        {
            case "wall":
                gameObject.SetActive(false);
                break;
            case "enemy":
                Debug.Log("Enemy Hit");
                gameObject.SetActive(false);
                break;


        }
    }




    private void SelfDisable()
    {
        //destroy object after a certain time. 
        //Destroy(gameObject, lifeTime);
        time += Time.deltaTime;
        Debug.Log(time);
        if (time > 1)
        {
            gameObject.SetActive(false);
            time = 0;
        }
    }


}
