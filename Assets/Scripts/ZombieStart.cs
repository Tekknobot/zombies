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
    
    void InstantiateCircle () 
    {
        for (int i = 0; i < 5; i++)
        {
            float theta = i * 2 * Mathf.PI / 5;
            float x = Mathf.Sin(theta)*1; // rad
            float y = Mathf.Cos(theta)*1;
        
            GameObject ob = PoolManager.SharedInstance.GetPooledZombie();
            ob.transform.parent = transform;
            ob.transform.position = new Vector3(x, y, 0);  
            ob.SetActive(true); 
        }
    } 

    IEnumerator WaitForPool() {
        yield return new WaitForSeconds(0.1f);
        InstantiateCircle();
    } 
}
