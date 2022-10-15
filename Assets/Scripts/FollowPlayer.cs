using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public float range = 10;
    public float stoppingDistance;

    public RuntimeAnimatorController run;
    public RuntimeAnimatorController idle;

    public Transform target;
    private SpriteRenderer mySpriteRenderer;

    public GameObject levelUp;
    public GameObject[] zombieCount;
    public GameObject[] soldierCount;

    public int index;

    public int currentXPLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        if (this.tag == "zombie") {
            speed = Random.Range(2+GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel, GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel+5);
            range = 10+GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel;
            GetComponent<damage>().health = 100+GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel;
            GetComponent<flash>().dmg = 5+GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel; 
        }
        
        if (this.tag == "soldier") {
            speed = Random.Range(2, 5);
        }        
    }

    // Update is called once per frame
    void Update()
    {   
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach (Collider2D collider in colliders) {
            if (this.tag == "zombie") {
                if (collider.tag == "civilian" || collider.tag == "soldier") {
                    target = collider.transform; 
                    break;                    
                }
                else {
                    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                }                
            }
            if (this.tag == "soldier") {
                if (collider.tag == "zombie" && this.tag == "soldier") {
                    target = collider.transform; 
                    break;
                }
                else {
                    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                }
            }            
        }

        if (Vector2.Distance(transform.position, target.position) < range) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Animator animator = gameObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = run as RuntimeAnimatorController;
        }
        else {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = idle as RuntimeAnimatorController;
        }
        mySpriteRenderer.flipX = target.position.x < this.transform.position.x;    


        if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xp >= GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel) {
            this.currentXPLevel += 1;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel = this.currentXPLevel;
            range += 1;
            speed += 1;
            GetComponent<damage>().health += 1;
            GetComponent<flash>().dmg += 1;
            zombieCount = GameObject.FindGameObjectsWithTag("zombie");
            
            StartCoroutine(WaitForXPUpdate());

            soldierCount = GameObject.FindGameObjectsWithTag("soldier");
            foreach (GameObject soldier in soldierCount) {
                soldier.GetComponent<damageSoldier>().health += 1;
                soldier.GetComponent<soldierflash>().dmg += 1;
            }

            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel = Mathf.Round((GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel + GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel) * 1.1f);
            GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn -= 0.1f; 
        }   

        zombieCount = GameObject.FindGameObjectsWithTag("zombie");
        if (zombieCount.Length <= 3) {
            GameObject.Find("Main Camera").GetComponent<CameraFollowPlayer>().target = zombieCount[0];
        }   

        if (Input.GetButton("Right Bumper")) {
            GameObject.Find("Player").transform.position = zombieCount[index++].transform.position;
            if (index >= zombieCount.Length) {
                index = 0;
            }
        }             
    }    

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5);
    }

    IEnumerator WaitForXPUpdate() {
        foreach (GameObject zombie in zombieCount) {
        yield return new WaitForSeconds(0.0f);
        Instantiate(levelUp, zombie.transform.position, Quaternion.identity);
        }
    }
}
