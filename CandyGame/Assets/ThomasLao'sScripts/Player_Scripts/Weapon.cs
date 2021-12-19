using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform shootPosition;
    public GameObject projectile, crosshair;
    CharacterController2D cc2d;
    private Vector2 mousepos;
    Vector2 targetDelta;
    float angle;



    private void Start()
    {
        cc2d = GetComponentInParent<CharacterController2D>();
    }
    private void Update()
    {

        mousepos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        crosshair.transform.position = mousepos;
        angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;


        if (!cc2d.m_FacingRight && angle < 90.0f)
        {
            cc2d.Flip();
            Debug.Log("Mouse Right");
        }
        else if (cc2d.m_FacingRight && angle > 90.0f)
        {
            cc2d.Flip();
            Debug.Log("Mouse Left");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


    }
    private void aim()
    {


    }
    private void Shoot()
    {
        //    targetDelta =               destination                 -           source
        targetDelta = new Vector2(mousepos.x, mousepos.y) - new Vector2(transform.position.x, transform.position.y);
        GameObject bullet = Instantiate(projectile, shootPosition.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(targetDelta.normalized * 100f);

    }


}
