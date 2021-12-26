using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// We will use this script to pool objects we want exploding out of objects.
/// 
/// This script calls the rigidbody2D addExplosion function
/// 
/// This script also instantiates inactive objects into an object pool
/// 
/// </summary>
public class Resuable_Explosion_Script : MonoBehaviour
{
    //scale objects
    public float objectSize = 0f;
    public int objectsInRow = 0;

    public float explosionForce = 0f;
    public float explosionUpward = 0f;

    float explosionSideWays = 0;

    private float objectPivotDistance;
    public float explosionRadius = 0f;

    //your choice on what pools you want to be active
    //note: check the boxes before starting the scene
    public bool poolEnemies = false;
    public bool poolSludge = false;
    public bool poolHealthPacks = false;


    Vector2 objectPivot;
    void Start()
    {
        explosionForce = Random.Range(300, 500);
        explosionUpward = Random.Range(0.4f, 0.7f);
        explosionRadius = Random.Range(3, 6);
        objectsInRow = Random.Range(1, 3);
        //calculate pivot distance
        objectPivotDistance = objectSize * objectsInRow / 2;
        //use this value to create a pivot vector
        objectPivot = new Vector3(objectPivotDistance, objectPivotDistance);
    }

    public void createPieces(int x, int y)
    {

        if (poolSludge)
        {
            Vector3 explosionPos = this.transform.position;
            GameObject sludge = ObjectPool.instance.Get_Hazardous_Sludge();
            if (sludge == null)
            {
                ObjectPool.instance.Re_Stock_Sludge();
            }
            else
            {
                sludge.SetActive(true);
                sludge.transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(objectSize * x, objectSize * y) - objectPivot;
                sludge.GetComponent<Rigidbody2D>().AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionUpward);
            }
        }
        if (poolHealthPacks)
        {
            Vector3 explosionPos = this.transform.position;
            GameObject healthDrops = ObjectPool.instance.Get_Health_Drops();
            if (healthDrops == null)
            {
                ObjectPool.instance.Re_Stock_Health_Drops();

            }

            else
            {
                healthDrops.SetActive(true);
                healthDrops.transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(objectSize * x, objectSize * y) - objectPivot;
                healthDrops.GetComponent<Rigidbody2D>().AddExplosionForce(explosionForce * 1.5f, explosionPos, explosionRadius, explosionUpward);
            }
        }



    }

    public void explodeSludge()
    {

        for (int i = 0; i < objectsInRow; i++)
        {
            for (int j = 0; j < objectsInRow; j++)
            {
                createPieces(i, j);
            }
        }

    }
    public void explode_Out_HealthPacks()
    {
        for (int i = 0; i < objectsInRow * 2; i++)
        {
            for (int j = 0; j < objectsInRow * 2; j++)
            {
                createPieces(i, j);
            }
        }
    }
}

