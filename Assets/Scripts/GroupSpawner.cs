using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GroupSpawner : MonoBehaviour
{
    public GameObject[] group;
    public GameObject cameraObject;
    public float timeBtwSpawn;
    public float startTimeBtwSpawn = 5;
    public float decreaseTime;
    public int spawnSide;
    void Start()
    {
        spawnSide = Random.Range(0, 4);
    }
 
    void Update()
    {
        if(timeBtwSpawn <= 0) {
            if(spawnSide == 0) {
                Instantiate(group[Random.Range(0,group.Length)], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[Random.Range(0,group.Length)], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[Random.Range(0,group.Length)], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[Random.Range(0,group.Length)], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}