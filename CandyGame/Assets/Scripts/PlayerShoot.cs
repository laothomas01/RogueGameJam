using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootPosition;
    public GameObject projectile, crosshair;
    public float bulletSpeed;
    public Animator anim;
    private Vector2 mousepos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        crosshair.transform.position = mousepos;

        if (Input.GetButtonDown("Fire1")) {
            shoot();
        }
    }
    private void shoot() {
        Vector2 targetDelta = new Vector2(mousepos.x,mousepos.y) - new Vector2(transform.position.x , transform.position.y) ;
        PlayerHealth.health -= .1f;
        GameObject bullet = Instantiate(projectile, shootPosition.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(targetDelta.normalized * bulletSpeed);
    }
}
