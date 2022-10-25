using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject zombie;

    public int index;

    public int currentXPLevel = 0;
    public bool onFire = false;
    public bool justLeveledUp = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        if (this.tag == "zombie") {
            speed = Random.Range(2+GetComponent<FollowPlayer>().currentXPLevel, 5+GetComponent<FollowPlayer>().currentXPLevel);
            zombieCount = GameObject.FindGameObjectsWithTag("zombie");
            foreach (GameObject zombie in zombieCount) {
                currentXPLevel = zombieCount[0].GetComponent<FollowPlayer>().currentXPLevel;
                //fireRate -= 250;
                range += GetComponent<FollowPlayer>().currentXPLevel;                
            }
        }

        if (this.tag == "soldier") {
            speed = Random.Range(2, 5);
            GetComponent<soldierflash>().dmg = GetComponent<soldierflash>().dmg + GetComponent<FollowPlayer>().currentXPLevel;
            GetComponent<soldierflash>().bulletDmg = GetComponent<soldierflash>().bulletDmg + GetComponent<FollowPlayer>().currentXPLevel;            
        }

        if (this.tag == "soldier" && GetComponent<damageSoldier>().boss == true) {
            speed = 2;
        } 

        if (this.tag == "soldier" && GetComponent<damageSoldier>().mech == true) {
            speed = 1;
        }               
    }

    // Update is called once per frame
    void Update()
    {
        zombieCount = GameObject.FindGameObjectsWithTag("zombie");
        if (Input.GetButton("Right Bumper")) {
            GameObject.Find("Player").transform.position = zombieCount[index++].transform.position;
            if (index >= zombieCount.Length) {
                index = 0;
            }
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach (Collider2D collider in colliders) {
            if (this.tag == "zombie") {
                if (Input.GetButton("Fire1")) {
                    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                    break;
                }
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
            if (this.tag == "soldier" && GetComponent<damageSoldier>().mech == true) {
                if (collider.tag == "zombie" && this.tag == "soldier") {
                    target = collider.transform;
                    break;
                }
                else {
                    //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel+1;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().barXP = 0;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().lastXP = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel;
            zombieCount = GameObject.FindGameObjectsWithTag("zombie"); 
            foreach (GameObject zombie in zombieCount) {
                zombie.GetComponent<FollowPlayer>().currentXPLevel += 1;
                zombie.GetComponent<damage>().health = GetComponent<damage>().maxHealth;
                zombie.GetComponent<ZombieShoot>().fireRate -= 250;
                zombie.GetComponent<FollowPlayer>().speed += 1f;
                zombie.GetComponent<FollowPlayer>().range += 1f;
            }

            soldierCount = GameObject.FindGameObjectsWithTag("soldier");
            foreach (GameObject soldier in soldierCount) {
                soldier.GetComponent<soldierflash>().dmg += 1;
                soldier.GetComponent<soldierflash>().bulletDmg += 1;
            }
            StartCoroutine(WaitForXPUpdate());

            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel = Mathf.Round((GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel + GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel) * 1.05f);
            Instantiate(zombie, this.transform.position, Quaternion.identity);
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
            //Time.timeScale = 0f;
            StartCoroutine(UnPause());
        }
    }

    IEnumerator UnPause() {
        GameObject.Find("LevelUpText").GetComponent<Text>().enabled = true;
        GameObject.Find("+1").GetComponent<Text>().enabled = true;
        GameObject.Find("MaxHealthText").GetComponent<Text>().enabled = true;
        //GameObject.Find("PressA").GetComponent<Text>().enabled = true;

        yield return new WaitForSeconds(3);

        // while(!Input.GetButtonDown("Fire1"))
        // {
        //     yield return null;
        // }

        //Time.timeScale = 1f;
        GameObject.Find("LevelUpText").GetComponent<Text>().enabled = false;
        GameObject.Find("+1").GetComponent<Text>().enabled = false;
        GameObject.Find("MaxHealthText").GetComponent<Text>().enabled = false;
        //GameObject.Find("PressA").GetComponent<Text>().enabled = false;
    }
}
