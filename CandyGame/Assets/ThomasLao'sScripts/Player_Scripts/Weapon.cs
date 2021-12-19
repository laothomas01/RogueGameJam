using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform shootPosition;
    public GameObject projectile, crosshair;
    CharacterController2D cc2d;
    [SerializeField] float bulletSpeed = 0.0f;
    private Vector2 mousepos;
    Vector2 targetDelta;
    float angle;
    bool canShoot = true;
    float time = 0;
    public float fireRate = 1.0f;
    public int damage = 1;
    public GameObject player;

    private void Start()
    {
        cc2d = GetComponentInParent<CharacterController2D>();
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
        angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;




    }

    private void Shoot()
    {

        //    targetDelta =               destination                 -           source
        targetDelta = new Vector2(mousepos.x, mousepos.y) - new Vector2(transform.position.x, transform.position.y);
        GameObject bullet = Instantiate(projectile, shootPosition.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(targetDelta * bulletSpeed, ForceMode2D.Force);
        this.GetComponentInParent<Player>().TakeDamage(damage);
    }


}
