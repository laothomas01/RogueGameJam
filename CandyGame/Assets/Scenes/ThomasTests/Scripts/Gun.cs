using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shootPosition;
    public Transform firePoint;
    public GameObject crosshair;
    Vector2 MOUSE_POSITION;
    Vector2 direction;
    float angle;
    bool canShoot = true;
    float time = 0;
    public GameObject projectile;
    PlayerScript playerScript;
    public float rotationZ;
    private void Start()
    {
        playerScript = GetComponentInParent<PlayerScript>();

        //playerScript.Flip();
    }
    private void Update()
    {
        if (!Player_Attributes.playerIsDead)
        {
            if (!PauseController.gameisPaused)
            {
                if (PlayerController.walking)
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
                else
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

            }
            else
            {
                return;
            }
        }



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
        shootPosition.right = direction;


        rotationZ = shootPosition.eulerAngles.z;




    }

    private void Shoot()
    {

        //    targetDelta =               destination                 -           source
        direction = new Vector2(MOUSE_POSITION.x, MOUSE_POSITION.y) - new Vector2(transform.position.x, transform.position.y);
        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
        Bullet bs = bullet.GetComponent<Bullet>();
        bullet.transform.rotation = shootPosition.rotation;
        bullet.GetComponent<Rigidbody2D>().AddForce(direction * bs.speed, ForceMode2D.Impulse);


        //USE THIS LATER

        //this.GetComponentInParent<Player_Attributes>().TakeDamage();
        this.GetComponentInParent<Player_Attributes>().TakeDamage(Bullet.damage);
    }


}
