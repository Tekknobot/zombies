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
        if(other.tag == "soldier" || other.tag == "suicide" || other.tag == "mech") {
            Destroy(this.gameObject);
        }

        if(other.tag == "building") {
            Destroy(this.gameObject);
        }    

        if (this.GetComponent<SpriteRenderer>().sprite.name == "zombie_grenade 0")
        {
            if(other.tag == "landmine") {
                GameObject newObject = Instantiate(explosion, transform.position, Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                Destroy(this.gameObject);
            }  
            else if(other.tag == "suicide") {
                GameObject newObject = Instantiate(explosion, transform.position, Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                Destroy(this.gameObject);
            }  
            else if(other.tag == "mech") {
                GameObject newObject = Instantiate(explosion, transform.position, Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                Destroy(this.gameObject);
            }                                   
        }             
    }    

    void OnBecameInvisible() {
        Destroy(gameObject);
    }    
}
