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

    void Update () {
        healthbar.GetComponent<HealthBarHandler>().SetHealthBarValue(health/maxHealth);
        if(health <= 0 && hasPlayed == false) {
            StartCoroutine(WaitForAnim());
            hasPlayed = true;
        }        
    }

    void Damage(float dmg) 
    {
        health -= dmg;
    } 

    IEnumerator WaitForAnim()
    {
        audioSource_growl.PlayOneShot(zombieGrowlSFX);
        Instantiate(blood, transform.position, Quaternion.identity);  
        Animator animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = gameObject.GetComponent<FollowPlayer>().death as RuntimeAnimatorController;          
        yield return new WaitForSeconds(0.91f);
        this.gameObject.SetActive(false);
        hasPlayed = false;
    }
}