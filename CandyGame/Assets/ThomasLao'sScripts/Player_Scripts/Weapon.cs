using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform shootPosition;
    //public GameObject projectile, crosshair;
    public GameObject crosshair;
    Player cc2d;
    [SerializeField] float bulletSpeed = 0.0f;
    private Vector2 mousepos;
    Vector2 targetDelta;
    float angle;
    bool canShoot = true;
    float time = 0;
    public float fireRate = 1.0f;
    public int damage = 1;
    PlayerScript playerScript;
    public GameObject arm;

    private void Start()
    {
        playerScript = GetComponentInParent<PlayerScript>();

    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
            canShoot = false;
        }
        else if (Input.GetMouseButtonUp(0) && canShoot == false)
        {
            canShoot = true;
        }


    }
    private void FixedUpdate()
    {
        mousepos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        crosshair.transform.position = mousepos;



        //Debug.Log(angle);

        //Debug.Log(rotationZ);
        //if (angle > 90 && angle < -90 && playerScript.facingRight)
        //{
        //    playerScript.Flip();
        //}
        //else if (angle <= 90 && angle >= -90 && !playerScript.facingRight)
        //{
        //    playerScript.Flip();
        //}
        //if (angle > 90 || angle < -90)
        //{
        //    playerScript.
        //}
        //if (playerScript.facingRight)
        //{
        //    if (this.transform.rotation.z > 90)
        //    {
        //        playerScript.Flip();
        //    }
        //}
        //else if (!playerScript.facingRight)
        //{
        //    if (this.transform.rotation.z >= -90)
        //    {
        //        playerScript.Flip();
        //    }
        //}

        //if (playerScript.facingRight &&)
        //{
        //    //facing Right = true -> facingRight = false

        //    playerScript.Flip();
        //}
        //else if (!playerScript.facingRight &&)
        //{
        //    playerScript.Flip();
        //}
        //Debug.Log(angle);
        targetDelta = new Vector2(mousepos.x, mousepos.y) - new Vector2(transform.position.x, transform.position.y);

        arm.transform.right = targetDelta;
        float rotationZ = arm.transform.eulerAngles.z;
        Debug.Log(rotationZ);
        if (playerScript.facingRight)
        {
            if (rotationZ <= 90)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            }
            else if (rotationZ >= 270)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            }
            else if (rotationZ > 90 && rotationZ < 270)
            {
                playerScript.Flip();
            }
        }
        //else if (!playerScript.facingRight)
        //{

        //    if (rotationZ > 90)
        //    {
        //        this.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        //    }
        //    else if (rotationZ < 270)
        //    {
        //        this.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        //    }
        //    else if (rotationZ <= 90 && rotationZ >= 270)
        //    {
        //        playerScript.Flip();
        //    }
        //}
        //else if (rotationZ >= 270)
        //{
        //    transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        //}
        //else if (rotationZ > 90 && rotationZ < 270)
        //{
        //    playerScript.Flip();
        //}


        //if (rotationZ > 90 && rotationZ < 270)
        //{
        //    playerScript.Flip();
        //}

    }

    private void Shoot()
    {

        //    targetDelta =               destination                 -           source
        targetDelta = new Vector2(mousepos.x, mousepos.y) - new Vector2(transform.position.x, transform.position.y);
        //GameObject bullet = Instantiate(projectile, shootPosition.position, Quaternion.identity);
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = shootPosition.position;

            bullet.SetActive(true);

        }
        bullet.GetComponent<Rigidbody2D>().AddForce(targetDelta * bulletSpeed, ForceMode2D.Force);
        //this.GetComponentInParent<Player>().TakeDamage(damage);
    }


}
