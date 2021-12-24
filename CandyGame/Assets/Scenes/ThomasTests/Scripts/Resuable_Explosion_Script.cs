using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resuable_Explosion_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public float objectSize = 0f;
    public int objectsInRow = 0;
    //public float explosionRadius = 0f;
    public float explosionForce = 0f;
    public float explosionUpward = 0f;
    float explosionSideWays = 0;
    private float objectPivotDistance;
    public float explosionRadius = 0f;

    //public bool poolItems = false;
    //public bool poolSpecialEffects = false;
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

    // Update is called once per frame
    public void createPieces(int x, int y)
    {
        //if (poolEnemies)
        //{
        //    Vector3 explosionPos = this.transform.position;
        //    GameObject enemies = ObjectPool.instance.Pool_Enemies();
        //    if (enemies == null)
        //    {
        //        ObjectPool.instance.Re_Stock_Enemies();
        //    }
        //    else
        //    {

        //        enemies.SetActive(true);
        //        enemies.transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(objectSize * x, objectSize * y) - objectPivot;
        //        enemies.GetComponent<Rigidbody2D>().AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionUpward);

        //    }


        //    //enemies.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);
        //    //enemies.GetComponent<Rigidbody2D>().AddForce(new Vector2(explosionSideWays, explosionUpward) * explosionPos.normalized * explosionForce);

        //}
        //else
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

