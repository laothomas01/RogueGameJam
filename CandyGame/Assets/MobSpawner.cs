using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    float x, y, ox;
    public float freq = 1;
    public float amp = 1;
    private void Start()
    {
        x = 0;
        ox = transform.position.x;
        y = transform.position.y;
    }
    public void Spawn()
    {
        int range = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[range], transform.position, Quaternion.identity);
        if (enemy.GetComponent<StickyPatrol>() != null)
        {
            enemy.GetComponent<StickyPatrol>().right = Random.Range(-1, 2) < 0;
        }
    }
    private void Update()
    {
        x = Mathf.Sin(Time.time * freq) * amp;
        transform.position = new Vector2(ox + x, y);

    }


}
