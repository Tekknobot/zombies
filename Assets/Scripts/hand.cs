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
    public float handDmg = 500;
    public int handAmount = 1;

    public RuntimeAnimatorController retreat;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders) { 
            if (collider.tag == "soldier" && flag == false && GameObject.FindGameObjectsWithTag("hand").Length < handAmount) {
                target = collider.transform; 
                collider.GetComponent<FollowPlayer>().speed = 0;  
                collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;            
                StartCoroutine(WaitForAnimation(target));
                //break; 
            }   
            if (collider.tag == "suicide" && flag == false && GameObject.FindGameObjectsWithTag("hand").Length < handAmount) {
                target = collider.transform; 
                collider.GetComponent<FollowPlayer>().speed = 0;  
                collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;            
                StartCoroutine(WaitForAnimation(target));
                //break; 
            }  
            if (collider.tag == "mech" && flag == false && GameObject.FindGameObjectsWithTag("hand").Length < handAmount) {
                target = collider.transform; 
                collider.GetComponent<FollowPlayer>().speed = 0;  
                collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;            
                StartCoroutine(WaitForAnimation(target));
                //break; 
            }                          
        } 
    }

    IEnumerator WaitForAnimation(Transform target) {
        //Instantiate(handObject, target.transform.position, Quaternion.identity);
        var myNewHand = Instantiate(handObject, target.transform.position, Quaternion.identity);
        //myNewHand.transform.parent = target.transform;      
        Instantiate(handSFX, target.transform.position, Quaternion.identity);          
        yield return new WaitForSeconds(2.9f);
        target.GetComponent<FollowPlayer>().speed = 1;
        target.GetComponent<soldierflash>().FlashRed();
        target.transform.SendMessage("DamageSoldier", 500);
        Animator animator = myNewHand.GetComponent<Animator>();
        animator.runtimeAnimatorController = retreat as RuntimeAnimatorController;        
        yield return new WaitForSeconds(2.9f);        
        flag = true;        
    }
}
