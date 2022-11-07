using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FollowZombies : MonoBehaviour
{
    public float speed;
    public float range = 10;
    public float stoppingDistance;

    public Transform target;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Awake() {
        target = GameObject.Find("PlayerPrefab").transform;
        Invoke("GetTarget", 0.1f);            
    }

    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(transform.position, target.position) < range) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }   

        if (target.GetComponent<DamageMode>().health <= 0) {
            GetTarget();
        }
    }

    void FixedUpdate() {
        
    }

    void GetTarget() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders) {
            if (collider.tag == "ZombieA") {
                target = collider.transform;
                FaceTarget();
                break;
            }  
            else {
                target = GameObject.Find("PlayerPrefab").transform;
            }
        }        
    }

    void FaceTarget()
    {
        Vector3 difference = target.transform.position - transform.position;
        float rot2 = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rot2);

        if(rot2 < 90 &&  rot2 > -90)
        {
            Debug.Log("Facing right");
            GetComponent<SpriteRenderer>().flipX = false; 
        }
        else
        {
            Debug.Log("Facing left");
            GetComponent<SpriteRenderer>().flipX = true; 
        }    
    }
}