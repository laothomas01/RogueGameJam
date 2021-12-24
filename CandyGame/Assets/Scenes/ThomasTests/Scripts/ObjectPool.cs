using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> poolBullets = new List<GameObject>();
    private List<GameObject> poolEnemies = new List<GameObject>();
    private List<GameObject> pool_Hazardous_Sludge = new List<GameObject>();
    private List<GameObject> pool_Health_Drops = new List<GameObject>();
    private int bulletPool = 15;
    private int enemyPool = 10;
    private int sludgePool = 5;
    private int health_drop_Pool;
    public int health_restock_amount, sludge_restock_amount, enemy_restock_amount;

    public bool poolCandyCreatures = false, poolSludge = false, pool_health_item = false;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject babyCandyCreatures;
    [SerializeField] private GameObject sludgePrefab;
    [SerializeField] private GameObject healthDrops;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //set the object you want to pool before you play your scene
    void Start()
    {


        if (poolCandyCreatures)
        {
            createCandyCreaturePool();
        }

        else if (poolSludge)
        {
            createSludgePool();
        }
        else if (pool_health_item)
        {
            createHealthDropPool();
        }

    }

    public void createBulletPool()
    {
        for (int i = 0; i < bulletPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);


            obj.SetActive(false);
            poolBullets.Add(obj);
        }
    }
    public void createCandyCreaturePool()
    {
        for (int j = 0; j < enemyPool; j++)
        {
            GameObject obj = Instantiate(babyCandyCreatures);
            obj.SetActive(false);
            poolEnemies.Add(obj);
        }
    }
    public void createSludgePool()
    {
        for (int i = 0; i < sludgePool; i++)
        {
            GameObject obj = Instantiate(sludgePrefab);
            obj.SetActive(false);
            pool_Hazardous_Sludge.Add(obj);
        }
    }
    public void createHealthDropPool()
    {
        for (int i = 0; i < health_drop_Pool; i++)
        {
            GameObject obj = Instantiate(healthDrops);
            obj.SetActive(true);
            pool_Health_Drops.Add(obj);
        }
    }
    public GameObject Get_Bullets()
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
    public GameObject Get_Enemies()
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
    public GameObject Get_Health_Drops()
    {
        for (int i = 0; i < pool_Health_Drops.Count; i++)
        {
            if (!pool_Health_Drops[i].activeInHierarchy)
            {
                return pool_Health_Drops[i];
            }

        }
        Debug.Log(poolEnemies.Count);
        return null;

    }
    public GameObject Get_Hazardous_Sludge()
    {
        for (int i = 0; i < pool_Hazardous_Sludge.Count; i++)
        {
            if (!pool_Hazardous_Sludge[i].activeInHierarchy)
            {
                return pool_Hazardous_Sludge[i];
            }
        }
        return null;
    }

    public GameObject Re_Stock_Enemies()
    {
        enemyPool += enemy_restock_amount;
        for (int j = 0; j < enemyPool; j++)
        {
            GameObject obj = Instantiate(babyCandyCreatures);
            obj.SetActive(false);
            poolEnemies.Add(obj);
        }
        return Get_Enemies();
    }
    //should the amount of sludge set active be over its list limit, it will add 5 more to itself. 
    public GameObject Re_Stock_Sludge()
    {
        sludgePool += sludge_restock_amount;
        for (int i = 0; i < sludgePool; i++)
        {
            GameObject obj = Instantiate(sludgePrefab);
            obj.SetActive(false);
            pool_Hazardous_Sludge.Add(obj);
        }
        return Get_Hazardous_Sludge();

    }

    public GameObject Re_Stock_Health_Drops()
    {
        health_drop_Pool += health_restock_amount;
        for (int i = 0; i < sludgePool; i++)
        {
            GameObject obj = Instantiate(sludgePrefab);
            obj.SetActive(false);
            pool_Hazardous_Sludge.Add(obj);
        }
        return Get_Health_Drops();

    }





}
