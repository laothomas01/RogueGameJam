using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    //public float speed = 5f;
    //public GameObject bulletPrefab;
    public float fireRate = 3000f; // every 3 seconds, shoot
    //public float shootPower = 20f; // force of protection
    public float shootingTime;
    //public Transform target;
    //public Transform player;
    public GameObject horizontalFirePoint;
    public GameObject bulletPrefab;

    public float waitTime;

    private void Start()
    {
        waitTime = 0;
    }


    private void Update()
    {
        waitTime += 1;

        if (waitTime > 50)
        {

            Shoot();
        }

    }



    public void Shoot()
    {

        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000;
            Instantiate(bulletPrefab, horizontalFirePoint.transform.position, horizontalFirePoint.transform.rotation);

        }

    }





}
