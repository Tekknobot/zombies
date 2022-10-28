using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageSoldier : MonoBehaviour
{
    public float health = 90;
    public float maxHealth = 10;
    public GameObject effect;

    public AudioClip soldierScreamSFX;
    public AudioSource audioSource_scream;

    private bool hasPlayed = false;

    public BoxCollider2D boxCol;
    public BoxCollider2D boxCol2;   

    public GameObject zombie; 
    public GameObject gem;
    public GameObject screamSFX;

    public GameObject healthbar;
    public bool boss;
    public bool laserSoldier;
    public bool projectileSoldier;
    public bool mech;

    public GameObject[] zombieCount;
    public int currentXPLevel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource_scream.GetComponent<AudioSource>().clip = soldierScreamSFX;
    }

    void DamageSoldier(float dmg) 
    {
        health -= dmg;
    }

    // Update is called once per frame
    void Update()
    {
        zombieCount = GameObject.FindGameObjectsWithTag("zombie");
        foreach (GameObject zombie in zombieCount) {
            currentXPLevel = zombieCount[0].GetComponent<FollowPlayer>().currentXPLevel;                                                  
        }

        if(health <= 0) 
        {
            if(!hasPlayed)
            {
                audioSource_scream.PlayOneShot(soldierScreamSFX);
                hasPlayed = true;

                Instantiate(effect, transform.position, Quaternion.identity);        
                if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().zombieCount.Length < GameObject.Find("ScoreManager").GetComponent<ScoreManager>().zombieLimit) {                
                    GameObject zombie = PoolManager.SharedInstance.GetPooledZombie();
                    zombie.transform.position = transform.position;
                    zombie.transform.rotation = Quaternion.identity;
                    zombie.SetActive(true);
                    zombie.GetComponent<damage>().health = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().zombieMaxHealth;
                }                                 
                Instantiate(gem, transform.position, Quaternion.identity);

                if (projectileSoldier == true) {
                    for (int i = 0; i < 2; i++) {
                        Instantiate(gem, transform.position, Quaternion.identity);
                    }
                }
                if (laserSoldier == true) {
                    for (int i = 0; i < 3; i++) {
                        Instantiate(gem, transform.position, Quaternion.identity);
                    }
                }  
                if (boss == true) {
                    for (int i = 0; i < 8; i++) {
                        Instantiate(gem, transform.position, Quaternion.identity);
                    }                                     
                }  
                if (mech == true) {
                    for (int i = 0; i < 13; i++) {
                        Instantiate(gem, transform.position, Quaternion.identity);
                    }                                                            
                }                                              

                if (gameObject.tag == "soldier") {
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>().soldierDeaths += 1;
                }

                if (gameObject.tag == "civilian") {
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>().civilianDeaths += 1;
                }                

                Instantiate(screamSFX, transform.position, Quaternion.identity);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<FollowPlayer>().speed = 0f;
                boxCol.enabled = false;
                boxCol2.enabled = false;

                StartCoroutine(WaitForSFX());
            }
        }

        healthbar.GetComponent<HealthBarHandler>().SetHealthBarValue(health/this.maxHealth);

        if (projectileSoldier == true) {
            healthbar.GetComponent<HealthBarHandler>().SetHealthBarValue(health/this.maxHealth);
        }        

        if (laserSoldier == true) {
            healthbar.GetComponent<HealthBarHandler>().SetHealthBarValue(health/this.maxHealth);
        }

        if (boss == true) {
            healthbar.GetComponent<HealthBarHandler>().SetHealthBarValue(health/this.maxHealth);
        }

        if (mech == true) {
            healthbar.GetComponent<HealthBarHandler>().SetHealthBarValue(health/this.maxHealth);
        }        
    }    

    IEnumerator WaitForSFX()
    {
        yield return new WaitForSeconds(0.1f);
        hasPlayed = false;
        Destroy(gameObject);
    }
}
