using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public GameObject horizontalFirePoint; // used to shoot left or right
    public GameObject verticalFirePoint; //used to shoot up or down
    public GameObject bulletPrefab; // create bullet objects
    public bool IsAimingUp = false; // shoot up
    public bool IsAimingHorizontal = true; // shoot left or right
    public bool isIdleShooting = false;
    public bool isHorizontalMoveShooting = false;
    public bool isVerticalMoveShooting = false;
    CharacterController2D cc2d;
    void Start()
    {
        cc2d = this.GetComponentInParent<CharacterController2D>();
    }
    void Update()
    {


        //if I am holding down the W key, my fire point should remain "UP"
        if (Input.GetKey(KeyCode.W))
        {

            //IsAimingUp = true;
            //IsAimingHorizontal = false;
            //bulletPrefab.GetComponent<Bullet>().flyVertical = true;
            //bulletPrefab.GetComponent<Bullet>().flyHorizontal = false;
            //verticalFirePoint.SetActive(IsAimingUp);
            //horizontalFirePoint.SetActive(IsAimingHorizontal);
            //cc2d.animator.SetBool("Is_Vertical_Idle_Shooting", true);
            //if (this.GetComponentInParent<PlayerMovement>().horizontalMove > 0 || this.GetComponentInParent<PlayerMovement>().horizontalMove < 0)
            //{
            //    cc2d.animator.SetBool("Is_Vertical_Move_Shooting", true);
            //    cc2d.animator.SetBool("Is_Vertical_Idle_Shooting", false);
            //    isVerticalMoveShooting = true;
            //    if (Input.GetKeyDown(KeyCode.J))
            //    {
            //        if (isVerticalMoveShooting)
            //        {
            //            Shoot();
            //        }
            //    }

            //}
            //else if (this.GetComponentInParent<PlayerMovement>().horizontalMove == 0)
            //{
            //    cc2d.animator.SetBool("Is_Vertical_Move_Shooting", false);
            //    cc2d.animator.SetBool("Is_Vertical_Idle_Shooting", true);
            //    if (Input.GetKeyDown(KeyCode.J))
            //    {
            //        Shoot();
            //    }
            //}



        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            IsAimingUp = false;
            IsAimingHorizontal = true;
            bulletPrefab.GetComponent<Bullet>().flyVertical = false;
            bulletPrefab.GetComponent<Bullet>().flyHorizontal = true;
            verticalFirePoint.SetActive(IsAimingUp);
            horizontalFirePoint.SetActive(IsAimingHorizontal);
            cc2d.animator.SetBool("Is_Vertical_Idle_Shooting", false);
            cc2d.animator.SetBool("Is_Vertical_Move_Shooting", false);
            //Debug.Log(IsAimingHorizontal);
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (this.GetComponentInParent<PlayerMovement>().horizontalMove == 0)
                {
                    isIdleShooting = true;
                    isHorizontalMoveShooting = false;
                    if (isIdleShooting)
                    {
                        cc2d.animator.SetBool("Is_Horizontal_Idle_Shooting", true);
                        Shoot();
                    }

                }
                else
                {
                    isIdleShooting = false;
                    isHorizontalMoveShooting = true;
                    if (isHorizontalMoveShooting)
                    {
                        cc2d.animator.SetBool("Is_Horizontal_Move_Shooting", true);
                        Shoot();
                    }
                    //cc2d.animator.SetBool("Is_Horizontal_Idle_Shooting", false);
                }

                //if (cc2d.m_IsMoving)
                //{
                //    //Debug.Log("Shooting Horizontal While Moving " + cc2d.m_IsMoving);

                //}

                //Debug.Log("Shooting Horizontal While Not Moving " + cc2d.m_IsMoving);

            }
            else if (Input.GetKeyUp(KeyCode.J))
            {
                cc2d.animator.SetBool("Is_Horizontal_Idle_Shooting", false);
                cc2d.animator.SetBool("Is_Horizontal_Move_Shooting", false);

            }





        }


    }
    void Shoot()
    {
        if (IsAimingUp)
        {
            Instantiate(bulletPrefab, verticalFirePoint.transform.position, verticalFirePoint.transform.rotation);
        }
        if (IsAimingHorizontal)
        {
            Instantiate(bulletPrefab, horizontalFirePoint.transform.position, horizontalFirePoint.transform.rotation);
        }
    }
    void StoppedIdleShooting()
    {

    }
    void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(horizontalFirePoint.transform.position, 1);
        //Gizmos.DrawWireSphere(verticalFirePoint.transform.position, 1);
    }

}
