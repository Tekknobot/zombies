using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject sfx;

    public bool pistol;
    public bool shotgun;
    public bool machinegun;
    public bool grenadeLauncher;

    public float dropRarity;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCollider());
        if (pistol == true) {
            dropRarity = 10f;
        }
        if (shotgun == true) {
            dropRarity = 5f;
        }
        if (machinegun == true) {
            dropRarity = 4f;
        }
        if (grenadeLauncher == true) {
            dropRarity = 3f;
        }                        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerPrefab" && pistol == true) {
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().xp += 1;
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().barXP += 1;
            other.GetComponentInChildren<PlayerGun>().pistol = true;
            other.GetComponentInChildren<PlayerGun>().shotgun = false;
            other.GetComponentInChildren<PlayerGun>().machinegun = false;
            other.GetComponentInChildren<PlayerGun>().grenadeLauncher = false;
            Instantiate(sfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);  
        }             

        if(other.tag == "PlayerPrefab" && shotgun == true) {
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().xp += 1;
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().barXP += 1;
            other.GetComponentInChildren<PlayerGun>().pistol = false;
            other.GetComponentInChildren<PlayerGun>().shotgun = true;
            other.GetComponentInChildren<PlayerGun>().machinegun = false;
            other.GetComponentInChildren<PlayerGun>().grenadeLauncher = false;
            Instantiate(sfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);  
        }  

        if(other.tag == "PlayerPrefab" && machinegun == true) {
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().xp += 1;
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().barXP += 1;
            other.GetComponentInChildren<PlayerGun>().pistol = false;
            other.GetComponentInChildren<PlayerGun>().shotgun = false;
            other.GetComponentInChildren<PlayerGun>().machinegun = true;
            other.GetComponentInChildren<PlayerGun>().grenadeLauncher = false;
            Instantiate(sfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);  
        }  

        if(other.tag == "PlayerPrefab" && grenadeLauncher == true) {
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().xp += 1;
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().barXP += 1;
            other.GetComponentInChildren<PlayerGun>().pistol = false;
            other.GetComponentInChildren<PlayerGun>().shotgun = false;
            other.GetComponentInChildren<PlayerGun>().machinegun = false;
            other.GetComponentInChildren<PlayerGun>().grenadeLauncher = true;
            Instantiate(sfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);  
        }                                
    }

    IEnumerator WaitForCollider() {
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider2D>().enabled = true;
    }    
}
