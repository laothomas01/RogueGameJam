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

    Vector2 objectPivot;
    void Start()
    {
        //calculate pivot distance
        objectPivotDistance = objectSize * objectsInRow / 2;
        //use this value to create a pivot vector
        objectPivot = new Vector3(objectPivotDistance, objectPivotDistance);

        //explosionUpward = 0.4f;
        //explosionSideWays = Random.Range(-5, -1);
        //explosionForce = ;

    }

    // Update is called once per frame
    public void createPieces(int x, int y)
    {
        if (poolEnemies)
        {
            Vector3 explosionPos = this.transform.position;
            GameObject enemies = ObjectPool.instance.Pool_Enemies();
            if (enemies == null)
            {
                ObjectPool.instance.Re_Stock_Enemies();
            }
            else
            {

                enemies.SetActive(true);
                enemies.transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(objectSize * x, objectSize * y) - objectPivot;
                enemies.GetComponent<Rigidbody2D>().AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionUpward);

            }


            //enemies.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);
            //enemies.GetComponent<Rigidbody2D>().AddForce(new Vector2(explosionSideWays, explosionUpward) * explosionPos.normalized * explosionForce);

        }
        else if (poolSludge)
        {
            Vector3 explosionPos = this.transform.position;
            GameObject sludge = ObjectPool.instance.Pool_Hazardous_Sludge();
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
        //else if (poolItems)
        //{

        //}
        //else if (poolEnemies && poolItems)
        //{

        //}
        //GameObject babyCandyCreatures = ObjectPool.instance.GetPooledObject2();

        //babyCandyCreatures.transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(cubeSize * x, cubeSize * y) - cubesPivot;
        //babyCandyCreatures.SetActive(true);
        //babyCandyCreatures.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, -1), (Random.Range(1, 5))), ForceMode2D.Impulse);
        //if (poolEnemies && poolItems && poolSpecialEffects)
        //{

        //}
        //else if (poolEnemies && poolItems)
        //{

        //}
        //else if (poolItems && poolSpecialEffects)
        //{

        //}


    }

    public void explode()
    {

        for (int i = 0; i < objectsInRow; i++)
        {
            for (int j = 0; j < objectsInRow; j++)
            {
                createPieces(i, j);
            }
        }


    }
}

