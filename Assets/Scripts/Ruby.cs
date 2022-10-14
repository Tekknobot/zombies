using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public GameObject sfx;
    public GameObject[] zombies;

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
            zombies = GameObject.FindGameObjectsWithTag("zombie");
            foreach (GameObject zombie in zombies) {
                zombie.GetComponent<damage>().health += 3f;
            }
            Instantiate(sfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);  
        }       
    }

    IEnumerator WaitForCollider() {
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider2D>().enabled = true;
    }    
}
