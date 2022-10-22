using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageSoldier : MonoBehaviour
{
    public float health = 90;
    public GameObject blood;

    public AudioClip soldierScreamSFX;
    public AudioSource audioSource_scream;

    private bool hasPlayed = false;

    public BoxCollider2D boxCol;
    public BoxCollider2D boxCol2;   

    public GameObject zombie; 
    public GameObject gem;
    public GameObject screamSFX;

    public GameObject healthbar;

    // Start is called before the first frame update
    void Start()
    {
        audioSource_scream.GetComponent<AudioSource>().clip = soldierScreamSFX;
    }

    void Damage(float dmg) 
    {
        health -= dmg;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) 
        {
            if(!hasPlayed)
            {
                audioSource_scream.PlayOneShot(soldierScreamSFX);
                hasPlayed = true;

                Instantiate(blood, transform.position, Quaternion.identity);
                Instantiate(zombie, transform.position, Quaternion.identity);
                Instantiate(gem, transform.position, Quaternion.identity);
                Instantiate(screamSFX, transform.position, Quaternion.identity);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<FollowPlayer>().speed = 0f;
                boxCol.enabled = false;
                boxCol2.enabled = false;

                if (gameObject.tag == "soldier") {
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>().soldierDeaths += 1;
                }

                if (gameObject.tag == "civilian") {
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>().civilianDeaths += 1;
                }                

                StartCoroutine(WaitForSFX());
            }
        }

        healthbar.GetComponent<HealthBarHandler>().SetHealthBarValue(health/100);
    }    

    IEnumerator WaitForSFX()
    {
        yield return new WaitForSeconds(0f);
        Destroy(gameObject);
    }
}
