using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour {

    public GameObject explosion;

    void Start() {
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(WaitTenthSec());
    }

    void Update() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f); 
        foreach (Collider2D collider in colliders) {
            if (collider.tag == "building") {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);            
            }
        }               
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "zombie" || col.tag == "ZombieA") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if(col.tag == "soldier" || col.tag == "PlayerPrefab") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }   

        if(col.tag == "building") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }        

        if(col.GetComponent<SpriteRenderer>().sprite.name == "zombie_grenade 0") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }             
    } 

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "building") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }     
    }   

    IEnumerator WaitTenthSec() {
        yield return new WaitForSeconds(0.1f);
        GetComponent<BoxCollider2D>().enabled = true;
    }    
}
