using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damage : MonoBehaviour
{
    public float health = 90;
    public float maxHealth = 100;
    public GameObject blood;

    public AudioClip zombieGrowlSFX;
    public AudioSource audioSource_growl;

    private bool hasPlayed = false;

    public BoxCollider2D boxCol;
    public BoxCollider2D boxCol2; 

    public GameObject healthbar;
       

    // Start is called before the first frame update
    void Start()
    {
        audioSource_growl.GetComponent<AudioSource>().clip = zombieGrowlSFX;
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
                audioSource_growl.PlayOneShot(zombieGrowlSFX);
                hasPlayed = true;

                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<FollowPlayer>().speed = 0f;

                boxCol.enabled = false;
                boxCol2.enabled = false;

                if (gameObject.tag == "zombie") {
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>().zombieDeaths += 1;
                }   

                StartCoroutine(WaitForAnim());
            }
        }

        healthbar.GetComponent<HealthBarHandler>().SetHealthBarValue(health/maxHealth);
    }    

    IEnumerator WaitForAnim()
    {
        Instantiate(blood, transform.position, Quaternion.identity);  
        Animator animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = gameObject.GetComponent<FollowPlayer>().death as RuntimeAnimatorController;           
        yield return new WaitForSeconds(0.91f);
        Destroy(gameObject);
    }
}
