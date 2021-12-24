using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //variable for referencing the class
    public static ObjectPool instance;
    private List<GameObject> poolBullets = new List<GameObject>(); //pool for bullets
    private List<GameObject> poolEnemies = new List<GameObject>(); // pool for enemies you want to spawn from other enemies
    private List<GameObject> pool_Hazardous_Sludge = new List<GameObject>(); // sludge prefabs you can create from a pool
    private List<GameObject> pool_Health_Drops = new List<GameObject>(); // health drops from the pool

    /// <summary>
    /// MAXIMUM POOL SIZES WE WILL USE FOR OBJECT INSTANTIATION 
    /// </summary>
    private int bulletPool = 15;
    public int enemyPool;
    public int sludgePool;
    public int health_drop_Pool;
    public int health_restock_amount, sludge_restock_amount, enemy_restock_amount; // how much should be restocked to the pool when the limit is reached

    public bool poolCandyCreatures = false, poolSludge = false, pool_health_item = false; // toggle which pool you want working

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject babyCandyCreaturePrefab;
    [SerializeField] private GameObject sludgePrefab;
    [SerializeField] private GameObject healthDropPrefab;
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
        createBulletPool();
        /// <summary>
        /// 
        /// 
        /// TOGGLE THESE BUTTONS ON OR OFF BEFORE PLAYING YOUR SCENE 
        /// 
        /// 
        /// </summary>
        /// 

        //if (poolCandyCreatures)
        //{
        //    createCandyCreaturePool();
        //}

        if (poolSludge)
        {
            createSludgePool();
        }
        if (pool_health_item)
        {
            createHealthDropPool();
        }

    }

    /// <summary>
    /// FILL THE POOLS WITH INACTIVE OBJECTS
    /// CALL THIS IN THE START METHOD TO FILL THE OBJECT POOL, AN EMPTY OBJECT IN THE GAME'S SCENE, WITH INACTIVE OBJECTS
    /// </summary>
    public void createBulletPool()
    {
        for (int i = 0; i < bulletPool; i++)
        {
            GameObject obj1 = Instantiate(bulletPrefab);
            obj1.SetActive(false);
            poolBullets.Add(obj1);
        }
    }

    //public void createCandyCreaturePool()
    //{
    //    for (int j = 0; j < enemyPool; j++)
    //    {
    //        GameObject obj = Instantiate(babyCandyCreaturePrefab);
    //        obj.SetActive(false);
    //        poolEnemies.Add(obj);
    //    }
    //}

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
            GameObject obj = Instantiate(healthDropPrefab);
            obj.SetActive(false);
            pool_Health_Drops.Add(obj);
        }
    }


    /// <summary>
    /// 
    /// USED TO RETRIEVE THE OBJECTS FROM THE POOL
    /// 
    /// </summary>
    /// 
    /// 
    /// <returns>
    /// RETURN A GAME OBJECT
    /// </returns>
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
    //public GameObject Get_Enemies()
    //{
    //    for (int i = 0; i < poolEnemies.Count; i++)
    //    {
    //        if (!poolEnemies[i].activeInHierarchy)
    //        {
    //            return poolEnemies[i];
    //        }

    //    }
    //    //Debug.Log(poolEnemies.Count);
    //    return null;

    //}
    public GameObject Get_Health_Drops()
    {
        for (int i = 0; i < pool_Health_Drops.Count; i++)
        {
            if (!pool_Health_Drops[i].activeInHierarchy)
            {
                return pool_Health_Drops[i];
            }

        }
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

    //public GameObject Re_Stock_Enemies()
    //{
    //    enemyPool += enemy_restock_amount;
    //    for (int j = 0; j < enemyPool; j++)
    //    {
    //        GameObject obj = Instantiate(babyCandyCreaturePrefab);
    //        obj.SetActive(false);
    //        poolEnemies.Add(obj);
    //    }
    //    return Get_Enemies();
    //}
    ////should the amount of sludge set active be over its list limit, it will add 5 more to itself. 
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
        for (int i = 0; i < health_drop_Pool; i++)
        {
            GameObject obj = Instantiate(healthDropPrefab);
            obj.SetActive(false);
            pool_Health_Drops.Add(obj);
        }
        return Get_Health_Drops();

    }





}
