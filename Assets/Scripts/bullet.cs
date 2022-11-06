using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public bool bulletDefault;   
    public bool grenade;
    public bool orbiter;
    public Sprite spriteGrenade;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {        
        if (grenade == true) {
            this.GetComponent<Rotate>().enabled = true;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = spriteGrenade;
        }    

        if (bulletDefault == true) {
            this.GetComponent<Rotate>().enabled = false;
            this.GetComponent<Animator>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "zombie") {
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
        }

        if(other.tag == "building") {
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
        } 
        
        if (other.tag == "ZombieA" && grenade == true) {
            Instantiate(explosion, transform.position, Quaternion.identity);
        } 

        if(other.tag == "ZombieA") {
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
        }            
    }    

    void OnBecameInvisible() {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }    
}
