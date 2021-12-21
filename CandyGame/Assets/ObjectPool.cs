using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledObjects1 = new List<GameObject>();
    private List<GameObject> pooledObjects2 = new List<GameObject>();
    private int bulletPool = 15;
    private int enemyPool = 15;

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
            pooledObjects1.Add(obj);



        }
        for (int j = 0; j < enemyPool; j++)
        {
            GameObject obj2 = Instantiate(babyCandyCreatures);
            obj2.SetActive(false);
            pooledObjects2.Add(obj2);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects1.Count; i++)
        {
            if (!pooledObjects1[i].activeInHierarchy)
            {
                return pooledObjects1[i];
            }
        }

        return null;
    }
    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < enemyPool; i++)
        {
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }
        return null;
    }

    void Update()
    {

    }
}
