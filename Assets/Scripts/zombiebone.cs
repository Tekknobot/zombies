using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiebone : MonoBehaviour
{
    public float rotationSpeed = 90;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "soldier" || other.tag == "civilian") {
            Destroy(this.gameObject);
        }

        if(other.tag == "building") {
            Destroy(this.gameObject);
        }        
    }    

    void OnBecameInvisible() {
        Destroy(gameObject);
    }    
}
