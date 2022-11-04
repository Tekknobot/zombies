using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public bool playerBullet;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerBullet == true) {
            GetComponent<Rigidbody2D>().velocity = speed * transform.right;
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
