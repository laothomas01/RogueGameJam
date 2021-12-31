using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezDespenser : MonoBehaviour
{

    private Rigidbody2D rb;
    public GameObject gun, bullet, firepoint;
    private float x, y, z;
    public float hitDistance;
    [SerializeField] private LayerMask PlayerMask;
    private Vector2 direction;
    public float amp = 1;
    private RaycastHit2D hit;
    public float freq = 1;
    private float time,dir = 0;
    private bool spotted;
    public float fireGap = 2;
    public Animator turretAnimator, headAnimator, bodyAnimator;
    private EnemyScript enemy;
    public bool facingRight=true;
    private float yScaleNeg, yScalePos;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        headAnimator = transform.GetChild(0).GetComponent<Animator>();
        bodyAnimator = transform.GetChild(1).GetComponent<Animator>();
        turretAnimator = GetComponent<Animator>();
        yScaleNeg = -gun.transform.localScale.y;
        yScalePos = gun.transform.localScale.y;
        rb = GetComponent<Rigidbody2D>();
        x = gun.transform.rotation.x;
        y = gun.transform.rotation.y;
        //gun.transform.right = -gun.transform.right;
        //transform.right = -transform.right;
        dir = facingRight ? 0 : 180;
        
    }

    // Update is called once per frame
    void Update()
    {

        headAnimator.SetBool("Hit", enemy.damaged);
        bodyAnimator.SetBool("Hit", enemy.damaged);

        if (enemy.dead)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = true;
            turretAnimator.SetBool("death", true);
        }

        hit = Physics2D.Raycast(gun.transform.position, gun.transform.right, hitDistance, PlayerMask);

        if (!hit)
        {
            //gun.transform.rotation = Quaternion.AngleAxis(z, transform.forward);

            //gun.transform.rotation  = Quaternion.Euler(gun.transform.rotation.x, gun.transform.rotation.y, gun.transform.rotation.z);
            gun.transform.rotation = Quaternion.Euler(0, dir , z);
            if (!facingRight)
            {
                gun.transform.localScale = new Vector3(gun.transform.localScale.x, yScalePos, gun.transform.localScale.z);
            }
            z = Mathf.Sin(Time.time * freq) * amp;
            spotted = false;
        }
        else
        {
            direction = hit.transform.position - gun.transform.position;
            gun.transform.right = direction;
            if (!facingRight)
            {
                gun.transform.localScale = new Vector3(gun.transform.localScale.x, yScaleNeg, gun.transform.localScale.z);
            }
            if (!spotted)
            {
                Debug.Log("Should return");
            }
            spotted = true;
        }
        
        Debug.DrawRay(gun.transform.position, gun.transform.right * hitDistance, Color.green);


        time += Time.deltaTime;
        if (time > fireGap && !enemy.dead)
        {
            shoot();
            time = 0;
        }
        else
        {
            headAnimator.SetBool("PezShoot", false);
        }
        if (this.GetComponent<EnemyScript>().damaged)
        {
            FindObjectOfType<SoundManager>().splat("splat");
        }
        if (this.GetComponent<EnemyScript>().dead)
        {
            FindObjectOfType<SoundManager>().Play2("sizzle");
        }

    }

    void shoot()
    {
        headAnimator.SetBool("PezShoot", true);
        Instantiate(bullet, firepoint.transform.position, gun.transform.rotation);
        //headAnimator.SetBool("PezShoot", false);
    }

}
