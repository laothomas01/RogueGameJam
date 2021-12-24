using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform shootPosition;
    //public GameObject projectile, crosshair;
    public GameObject crosshair;
    [SerializeField] float bulletSpeed = 0.0f;
    Vector2 MOUSE_POSITION;
    Vector2 direction;
    float angle;
    bool canShoot = true;
    float time = 0;
    public float fireRate = 1.0f;

    PlayerScript playerScript;
    public GameObject arm;
    public float rotationZ;
    //public float rotationY;
    private void Start()
    {
        playerScript = GetComponentInParent<PlayerScript>();

        //playerScript.Flip();
    }
    private void Update()
    {
        gunTurning();
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


    }
    private void gunTurning()
    {

        /*
         * my logic:
         * quite a lot of thnigs will be based on my mouse position from screen to world
         * get mouse position
         * 
         * make mouse position from screen to world point
         * 
         * set cross hair position = to mouse so I can see where I am pointing
         * 
         * get the direction of where the arm gun should point
         * 
         * get the gun's angle for later usage which is based on the position of your
         */
        //mouse position
        Vector2 mousepos = Input.mousePosition;


        //from the screen to the world
        MOUSE_POSITION = Camera.main.ScreenToWorldPoint(mousepos);


        //set the cross hair object's position = to my mouse position
        crosshair.transform.position = MOUSE_POSITION;


        //  direction = Mouse Position.transform.position - this.transform.position
        direction = new Vector2(MOUSE_POSITION.x, MOUSE_POSITION.y) - new Vector2(transform.position.x, transform.position.y);

        //use this to point our arm in the direction we want
        arm.transform.right = direction;


        rotationZ = arm.transform.eulerAngles.z;




    }

    private void Shoot()
    {

        //    targetDelta =               destination                 -           source
        direction = new Vector2(MOUSE_POSITION.x, MOUSE_POSITION.y) - new Vector2(transform.position.x, transform.position.y);
        //GameObject bullet = Instantiate(projectile, shootPosition.position, Quaternion.identity);
        GameObject bullet = ObjectPool.instance.Get_Bullets();
        if (bullet != null)
        {
            bullet.transform.position = shootPosition.position;
            bullet.transform.rotation = arm.transform.rotation;

            bullet.SetActive(true);

        }

        bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Force);

        //this.GetComponentInParent<Player>().TakeDamage(damage);
    }


}
