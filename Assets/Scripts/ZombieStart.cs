using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStart : MonoBehaviour
{
    public int zombies = 1;
    public float radius = 0;
    
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
        for (int i = 0; i < zombies; i++)
        {
            float theta = i * 2 * Mathf.PI / zombies;
            float x = Mathf.Sin(theta)*radius; // rad
            float y = Mathf.Cos(theta)*radius;
        
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
