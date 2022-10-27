using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    public GameObject handObject;
    public GameObject handSFX;
    public Transform target;
    public int range = 10;
    public bool flag = false;   
    public float dmg = 1;
    public int handAmount = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders) { 
            if ((collider.tag == "soldier" || collider.tag == "suicide" || collider.tag == "mech") && flag == false
                && GameObject.FindGameObjectsWithTag("hand").Length < handAmount) {
                target = collider.transform;               
                StartCoroutine(WaitForAnimation(target));
                //break; 
            }   
        } 
    }

    IEnumerator WaitForAnimation(Transform target) {
        var myNewHand = Instantiate(handObject, target.transform.position, Quaternion.identity);
        myNewHand.transform.parent = target.transform;      
        Instantiate(handSFX, target.transform.position, Quaternion.identity);  
        yield return new WaitForSeconds(1f);
        //flag = true;
        target.GetComponent<soldierflash>().FlashRed();
        target.GetComponent<soldierflash>().SendMessage("Damage", dmg);        
    }
}
