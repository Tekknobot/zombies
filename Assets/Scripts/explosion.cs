using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float dmg = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeScaleRoutine());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "zombie") {
            other.transform.SendMessage("Damage", dmg);
        } 
        if(other.tag == "soldier" || other.tag == "suicide" || other.tag == "mech") {
            other.transform.SendMessage("DamageSoldier", dmg);
        }         
        //Destroy(this.gameObject);
    }   

    IEnumerator TimeScaleRoutine() {
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
    }     
}
