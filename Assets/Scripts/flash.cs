using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    public float flashTime;
    Color origionalColor;
    public SpriteRenderer thisRenderer;

    public GameObject blood;  

    public float dmg = 5f;
    public float dmgBullet = 25f;
    public float dmgFire = 1f;

    float damageTime = 0.25f; //How often you want to damage to be done to the player
    //change to 0.25f for every quarter second/0.5f for half
    float currentDamageTime;     

    void Start()
    {
        origionalColor = thisRenderer.color;
    }

    public void FlashRed()
    {
        thisRenderer.color = Color.red;
        Invoke("ResetColor", flashTime);
        //Debug.Log("Flashing red!");
    }

    void ResetColor()
    {
        thisRenderer.color = origionalColor;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "bullet") {
            FlashRed();
            Instantiate(blood, transform.position, Quaternion.identity);
            this.transform.SendMessage("Damage", dmgBullet);
        }

        if(col.tag == "soldier") {
            FlashRed();
            this.transform.SendMessage("Damage", dmg);
        } 

        if(col.tag == "mech") {
            FlashRed();
            this.transform.SendMessage("Damage", dmg);
        } 

        if(col.tag == "suicide") {
            FlashRed();
            this.transform.SendMessage("Damage", dmg);
        }                   

        if(col.tag == "fire") {
            FlashRed();
            this.transform.SendMessage("Damage", dmgFire);
        }                
    } 

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "soldier") {

            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime)
            {
                FlashRed();
                currentDamageTime = 0.0f;
                this.transform.SendMessage("Damage", dmg);
            }    
        }

        if(col.tag == "suicide") {

            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime)
            {
                FlashRed();
                currentDamageTime = 0.0f;
                this.transform.SendMessage("Damage", dmg);
            }    
        }

        if(col.tag == "mech") {

            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime)
            {
                FlashRed();
                currentDamageTime = 0.0f;
                this.transform.SendMessage("Damage", dmg);
            }    
        }        
    }             
}
