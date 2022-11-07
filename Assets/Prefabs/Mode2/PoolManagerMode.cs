using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerMode : MonoBehaviour
{
    public static PoolManagerMode SharedInstance;
    public List<GameObject> pooledBullets;
    public List<GameObject> pooledShotGunBullets;
    public GameObject bulletToPool;
    public GameObject shotgunBulletToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledBullets = new List<GameObject>();
        GameObject tmpBullets;
        for(int i = 0; i < amountToPool; i++)
        {
            tmpBullets = Instantiate(bulletToPool);
            tmpBullets.SetActive(false);
            pooledBullets.Add(tmpBullets);
        }        

        pooledShotGunBullets = new List<GameObject>();
        GameObject tmpShotGunBullets;
        for(int i = 0; i < amountToPool; i++)
        {
            tmpShotGunBullets = Instantiate(shotgunBulletToPool);
            tmpShotGunBullets.SetActive(false);
            pooledShotGunBullets.Add(tmpShotGunBullets);
        }         
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

    public GameObject GetPooledShotGunBullet()
    {
        for(int i = 0; i < amountToPool; i++) {
            if(!pooledShotGunBullets[i].activeInHierarchy) {
                return pooledShotGunBullets[i];
            }
        }
        return null;
    }     
}
