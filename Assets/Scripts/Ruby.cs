using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public GameObject sfx;
    public GameObject[] zombies;
    public GameObject zombie;

    public bool zombieheart = false;
    public int zombieGift = 9;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCollider());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "zombie") {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xp += 1;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().barXP += 1;
            other.GetComponent<damage>().health = other.GetComponent<damage>().maxHealth;
            Instantiate(sfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);  
        }  

        if(other.tag == "zombie" && zombieheart == true) {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xp += 1;
            other.GetComponent<damage>().health = other.GetComponent<damage>().maxHealth;
            for (int i = 0; i < zombieGift; i++) {
                GameObject zombie = PoolManager.SharedInstance.GetPooledZombie();
                zombie.transform.position = transform.position;
                zombie.transform.rotation = Quaternion.identity;
                zombie.SetActive(true);
                zombie.GetComponent<damage>().health = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().zombieMaxHealth;            
            }
            Destroy(this.gameObject);  
        }              
    }

    IEnumerator WaitForCollider() {
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider2D>().enabled = true;
    }    
}
