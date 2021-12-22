using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> poolBullets = new List<GameObject>();
    private List<GameObject> poolEnemies = new List<GameObject>();
    private int bulletPool = 15;
    private int enemyPool = 10;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject babyCandyCreatures;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < bulletPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);


            obj.SetActive(false);
            poolBullets.Add(obj);



        }
        for (int j = 0; j < enemyPool; j++)
        {
            GameObject obj2 = Instantiate(babyCandyCreatures);
            obj2.SetActive(false);
            poolEnemies.Add(obj2);
        }
    }
    public GameObject Pool_Bullets()
    {
        for (int i = 0; i < poolBullets.Count; i++)
        {
            if (!poolBullets[i].activeInHierarchy)
            {
                return poolBullets[i];
            }
        }

        return null;
    }
    public GameObject Pool_Enemies()
    {
        for (int i = 0; i < poolEnemies.Count; i++)
        {
            if (!poolEnemies[i].activeInHierarchy)
            {
                return poolEnemies[i];
            }

        }
        Debug.Log(poolEnemies.Count);
        return null;

    }
    public GameObject Re_Stock_Enemies()
    {
        enemyPool += 10;
        for (int j = 0; j < enemyPool; j++)
        {
            GameObject obj2 = Instantiate(babyCandyCreatures);
            obj2.SetActive(false);
            poolEnemies.Add(obj2);
        }
        return Pool_Enemies();
    }



    void Update()
    {

    }
}
