using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezDespenser : MonoBehaviour
{

    private Rigidbody2D rb;
    public GameObject gun,bullet,firepoint;
    private float x, y, z;
    public float hitDistance;
    [SerializeField] private LayerMask PlayerMask;
    private Vector2 direction;
    public float amp = 1;
    private RaycastHit2D hit;
    public float freq = 1;
    private float time = 0;
    private bool spotted;
    public float fireGap = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        x = gun.transform.rotation.x;
        y = gun.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        hit = Physics2D.Raycast(gun.transform.position, gun.transform.right, hitDistance, PlayerMask);

        if (!hit)
        {
            gun.transform.rotation = Quaternion.AngleAxis(z, Vector3.forward);
            z = Mathf.Sin(Time.time * freq) * amp;
            spotted = false;
        }
        else
        {
            direction = hit.transform.position - gun.transform.position;
            gun.transform.right = direction;
            if (!spotted)
            {
                //z = -60f;
                Debug.Log("Should return");
            }
            spotted = true;
        }
        //gun.transform.Rotate(x, y, z);
         Debug.DrawRay(gun.transform.position, gun.transform.right * hitDistance, Color.green);


        time += Time.deltaTime;
        if(time > fireGap)
        {
            shoot();
            time = 0;
        }
    }

    void shoot()
    {
        Instantiate(bullet, firepoint.transform.position,gun.transform.rotation);
    }
}
