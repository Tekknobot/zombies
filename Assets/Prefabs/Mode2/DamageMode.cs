using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageMode : MonoBehaviour
{
    public float health = 90;
    public float maxHealth = 100;
    public GameObject blood;
    public GameObject gemXP;
    public GameObject explosion;
    public AudioClip objectSFX;
    public AudioSource audioSource_this;
    private bool hasPlayed = false;
    public BoxCollider2D boxCol;
    public BoxCollider2D boxCol2; 
    public GameObject healthbar;
    public RuntimeAnimatorController death;
    public GameObject[] drops;

    public bool zombie;
    public bool explodes;
    public bool helper;
    public GameObject exploder;   

    // Start is called before the first frame update
    void Start()
    {
        audioSource_this.GetComponent<AudioSource>().clip = objectSFX;
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
        //Instantiate(blood, transform.position, Quaternion.identity);
    } 

    IEnumerator WaitForAnim()
    {
        audioSource_this.PlayOneShot(objectSFX);
        Instantiate(blood, transform.position, Quaternion.identity);
        for (int i = 0; i < Random.Range(1,5); i++) {
            Instantiate(gemXP, transform.position, Quaternion.identity);
        }  

        if (explodes == true) {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        foreach (var drop in drops) {
            int calc_dropChance = Random.Range (0, 101);
        
            if (calc_dropChance > drop.GetComponent<Pickup>().dropRarity) {
                Instantiate(drops[Random.Range(0, drops.Length)], transform.position, Quaternion.identity);
            }
            break;
        }
        
        Animator animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = death as RuntimeAnimatorController; 
        boxCol.enabled = false;
        boxCol2.enabled = false;      
        if (GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().exploderOn == true) {
            GameObject tempObj = Instantiate(exploder, transform.position, Quaternion.identity);
            tempObj.GetComponent<ExplodeIntoBullets>().bulletSpreadCount = GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().currentXPLevel*3;
            tempObj.GetComponent<ExplodeIntoBullets>().degrees = 360/(GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().currentXPLevel*3);
        }  
        yield return new WaitForSeconds(0.91f);
        if (zombie == true) {
            this.gameObject.SetActive(false);
        }
        audioSource_this.enabled = false;
        GetComponent<DamageMode>().enabled = false;
        if (helper == true) {
            this.gameObject.SetActive(false);
        }        
        hasPlayed = false;
    }
}