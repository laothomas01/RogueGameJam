using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed=20f;
    private float horizontal;
    public GameObject splat;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = Input.GetAxisRaw("Vertical") == 0 ? transform.right.x : Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(horizontal, Input.GetAxisRaw("Vertical"));
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
       GameObject splt =  Instantiate(splat, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(splt,2);
    }
}
