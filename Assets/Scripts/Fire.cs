using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject vfx;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "zombie") {
            var tempFire = Instantiate(vfx, col.transform.position, Quaternion.identity);
            tempFire.transform.parent = col.transform;
            col.GetComponent<FollowPlayer>().onFire = true;
            StartCoroutine(StopFire(col));
            //Destroy(this.gameObject);
        }

        if(col.tag == "soldier") {
            //Instantiate(vfx, transform.position, Quaternion.identity);
            //Destroy(this.gameObject);
        }        
    } 
    
    IEnumerator StopFire(Collider2D col) {
        yield return new WaitForSeconds(5);
        col.GetComponent<FollowPlayer>().onFire = false;
    }
}
