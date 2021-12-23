using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> poolBullets = new List<GameObject>();
    private List<GameObject> poolEnemies = new List<GameObject>();
    private List<GameObject> poolHazardousSludge = new List<GameObject>();
    private int bulletPool = 15;
    private int enemyPool = 10;
    private int sludgePool = 5;


    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject babyCandyCreatures;
    [SerializeField] private GameObject sludgePrefab;
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
        for (int i = 0; i < sludgePool; i++)
        {
            GameObject obj3 = Instantiate(sludgePrefab);
            obj3.SetActive(false);
            poolHazardousSludge.Add(obj3);
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
    //should the amount of sludge set active be over its list limit, it will add 5 more to itself. 
    public GameObject Re_Stock_Sludge()
    {
        sludgePool += 5;
        for (int i = 0; i < sludgePool; i++)
        {
            GameObject obj3 = Instantiate(sludgePrefab);
            obj3.SetActive(false);
            poolHazardousSludge.Add(obj3);
        }
        return Pool_Hazardous_Sludge();

    }
    public GameObject Pool_Hazardous_Sludge()
    {
        for (int i = 0; i < poolHazardousSludge.Count; i++)
        {
            if (!poolHazardousSludge[i].activeInHierarchy)
            {
                return poolHazardousSludge[i];
            }
        }
        return null;
    }



    void Update()
    {

    }
}
