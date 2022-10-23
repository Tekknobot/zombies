using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierflash : MonoBehaviour
{
    public float flashTime;
    Color origionalColor;
    public SpriteRenderer thisRenderer;

    float damageTime = 0.25f; //How often you want to damage to be done to the player
    //change to 0.25f for every quarter second/0.5f for half
    float currentDamageTime; 

    public float dmg = 5f;   
    public GameObject blood;

    public float bulletDmg;

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
        if(col.tag == "zombiebullet") {
            FlashRed();
            this.transform.SendMessage("Damage", bulletDmg);
        }                           
    }    

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "zombie") {
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
