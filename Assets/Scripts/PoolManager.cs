using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager SharedInstance;
    public List<GameObject> pooledObjects;
    public List<GameObject> pooledZombies;
    public List<GameObject> pooledBullets;
    public GameObject[] objectsToPool;
    public GameObject zombieToPool;
    public GameObject bulletToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectsToPool[Random.Range(0, objectsToPool.Length)]);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        pooledZombies = new List<GameObject>();
        GameObject tmpZombie;
        for(int i = 0; i < amountToPool; i++)
        {
            tmpZombie = Instantiate(zombieToPool);
            tmpZombie.SetActive(false);
            pooledZombies.Add(tmpZombie);
        }

        pooledBullets = new List<GameObject>();
        GameObject tmpBullets;
        for(int i = 0; i < amountToPool; i++)
        {
            tmpBullets = Instantiate(bulletToPool);
            tmpBullets.SetActive(false);
            pooledBullets.Add(tmpBullets);
        }        
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++) {
            if(!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        return null;
    }       

    public GameObject GetPooledZombie()
    {
        for(int i = 0; i < amountToPool; i++) {
            if(!pooledZombies[i].activeInHierarchy) {
                return pooledZombies[i];
            }
        }
        return null;
    }    

    public GameObject GetPooledBullet()
    {
        for(int i = 0; i < amountToPool; i++) {
            if(!pooledBullets[i].activeInHierarchy) {
                return pooledBullets[i];
            }
        }
        return null;
    }       
}
