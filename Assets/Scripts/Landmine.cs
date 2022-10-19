using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour {

    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "zombie") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if(col.tag == "soldier") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }   

        if(col.GetComponent<SpriteRenderer>().sprite.name == "zombie_grenade 0") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }             
    } 
}
