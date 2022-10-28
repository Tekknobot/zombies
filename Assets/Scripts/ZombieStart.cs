using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForPool());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForPool() {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 5; i++) {
            GameObject zombie = PoolManager.SharedInstance.GetPooledZombie();
            zombie.transform.position = transform.position;
            zombie.transform.rotation = Quaternion.identity;
            zombie.SetActive(true);  
        }         
    }
}
