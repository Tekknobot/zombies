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
        if(col.tag == "zombie" && col.GetComponent<FollowPlayer>().onFire == false) {
            FlashRed();
            this.transform.SendMessage("Damage", dmg);
        } 
        if(col.tag == "zombie" && col.GetComponent<FollowPlayer>().onFire == true) {
            FlashRed();
            this.transform.SendMessage("Damage", dmg+10);
        }    

        if(col.tag == "zombiebullet") {
            FlashRed();
            this.transform.SendMessage("Damage", dmg);
        }                           
    }    

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "zombie" && col.GetComponent<FollowPlayer>().onFire == false) {
            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime)
            {
                FlashRed();
                currentDamageTime = 0.0f;
                this.transform.SendMessage("Damage", dmg);
            }    
        }
        if(col.tag == "zombie" && col.GetComponent<FollowPlayer>().onFire == true) {
            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime)
            {
                FlashRed();
                currentDamageTime = 0.0f;
                this.transform.SendMessage("Damage", dmg+10);
            }    
        }        
    }           
}
