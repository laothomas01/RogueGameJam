using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject[] Enemy;
    public Transform[] enemyPosition;
    private float repeatRate = 2.0f;    // repeats every 2 seconds.
    public int enemyCount = 0;
    public int maxEnemyCount = 2;
    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Spawn Area Triggered by: " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            //EnemySpawner();
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void EnemySpawner()
    {
        //int randEnemy = Random.Range(0,Enemy.Length);
        //int randPosition = Random.Range(0, enemyPosition.Length);
        //Instantiate(Enemy[randEnemy], enemyPosition[randPosition].position, transform.rotation);

        //Instantiate(Enemy[0], enemyPosition[0].position, enemyPosition[0].rotation);
        //Instantiate(Enemy[1], enemyPosition[1].position, enemyPosition[1].rotation);
        /*  Instantiate(Enemy[2], enemyPosition[2].position, enemyPosition[2].rotation);
          Instantiate(Enemy[3], enemyPosition[3].position, enemyPosition[3].rotation);
          Instantiate(Enemy[4], enemyPosition[4].position, enemyPosition[4].rotation); */
    }
}
