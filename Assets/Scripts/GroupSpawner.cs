using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GroupSpawner : MonoBehaviour
{
    public GameObject[] group;
    public GameObject cameraObject;
    public float timeBtwSpawn;
    public float startTimeBtwSpawn = 5;
    //public float decreaseTime;
    public int spawnSide;
    public GameObject[] soldierCount;

    void Start()
    {
        spawnSide = Random.Range(0, 4);
    }
 
    void Update()
    {
        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 0) {
            if(spawnSide == 0) {
                Instantiate(group[0], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[0], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[0], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[0], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 60) {
            if(spawnSide == 0) {
                Instantiate(group[1], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[1], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[1], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[1], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 120) {
            if(spawnSide == 0) {
                Instantiate(group[2], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[2], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[2], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[2], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 180) {
            if(spawnSide == 0) {
                Instantiate(group[3], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[3], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[3], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[3], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 240) {
            if(spawnSide == 0) {
                Instantiate(group[4], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[4], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[4], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[4], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }   

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 300) {
            if(spawnSide == 0) {
                Instantiate(group[5], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[5], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[5], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[5], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }    

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 360) {
            if(spawnSide == 0) {
                Instantiate(group[6], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[6], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[6], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[6], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }                             

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 420) {
            if(spawnSide == 0) {
                Instantiate(group[7], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[7], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[7], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[7], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        } 

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 480) {
            if(spawnSide == 0) {
                Instantiate(group[8], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[8], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[8], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[8], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }   

        if(timeBtwSpawn <= 0 && GameObject.Find("Timer").GetComponent<Timer>().timeElapsed > 540) {
            if(spawnSide == 0) {
                Instantiate(group[9], new Vector3(cameraObject.transform.position.x+(-18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 1) {
                Instantiate(group[9], new Vector3(cameraObject.transform.position.x+(18f), cameraObject.transform.position.y+(Random.Range(-18f, 18f)), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 2) {
                Instantiate(group[9], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+18f, cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            else if(spawnSide == 3) {
                Instantiate(group[9], new Vector3(cameraObject.transform.position.x+(Random.Range(-18f, 18f)), cameraObject.transform.position.y+(-18f), cameraObject.transform.position.z+0f), Quaternion.identity);
                spawnSide = Random.Range(0, 4);
            }
            timeBtwSpawn = startTimeBtwSpawn;
        } 
        else {
            timeBtwSpawn -= Time.deltaTime;
        }              

        soldierCount = GameObject.FindGameObjectsWithTag("soldier");
    }
}