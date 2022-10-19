using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiebullet : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "soldier" || other.tag == "civilian") {
            Destroy(this.gameObject);
        }

        if(other.tag == "building") {
            Destroy(this.gameObject);
        }    

        if (this.GetComponent<SpriteRenderer>().sprite.name == "zombie_grenade 0")
        {
            if(other.tag == "soldier" || other.tag == "civilian") {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            if(other.tag == "building" || other.tag == "landmine") {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            } 
        }             
    }    

    void OnBecameInvisible() {
        Destroy(gameObject);
    }    
}
