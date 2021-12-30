using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public GameObject boss;
    public float speed;
    private float time;
    private EnemyScript es;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        es = boss.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (es.dead)
        {
            time += Time.deltaTime;
            if(time < 2)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed);
            }
            
        }
    }
}
