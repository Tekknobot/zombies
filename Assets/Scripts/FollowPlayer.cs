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
    public RuntimeAnimatorController death;

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

    public GameObject levelupSFX;

    public int zombieLimit = 10;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        if (this.tag == "zombie") {
            zombieCount = GameObject.FindGameObjectsWithTag("zombie");        
            foreach (GameObject zombie in zombieCount) {
                currentXPLevel = zombieCount[0].GetComponent<FollowPlayer>().currentXPLevel;                              
            }            
            GetComponent<damage>().maxHealth = GetComponent<damage>().maxHealth+GetComponent<FollowPlayer>().currentXPLevel*10;
            GetComponent<damage>().health = zombie.GetComponent<damage>().maxHealth;
            GetComponent<ZombieShoot>().fireRate -= 250;
            //GetComponent<FollowPlayer>().speed = Random.Range(2+GetComponent<FollowPlayer>().currentXPLevel, 5+GetComponent<FollowPlayer>().currentXPLevel);;
            GetComponent<FollowPlayer>().speed = 2+GetComponent<FollowPlayer>().currentXPLevel;
            GetComponent<FollowPlayer>().range += 1f;  
            GetComponent<hand>().handAmount = 1+GetComponent<FollowPlayer>().currentXPLevel;   
            GetComponent<hand>().handDmg = 1+GetComponent<FollowPlayer>().currentXPLevel; 
            GetComponent<FollowPlayer>().zombieLimit = zombieCount[0].GetComponent<FollowPlayer>().zombieLimit;      
        }

        if ((this.tag == "soldier" || this.tag == "suicide" ||  this.tag == "mech") && currentXPLevel > 0) {
            speed = Random.Range(1, 2);
            GetComponent<damageSoldier>().maxHealth = GetComponent<FollowPlayer>().currentXPLevel*GetComponent<damageSoldier>().maxHealth;
            GetComponent<damageSoldier>().health = GetComponent<damageSoldier>().maxHealth;
            GetComponent<soldierflash>().dmg = GetComponent<soldierflash>().dmg + GetComponent<FollowPlayer>().currentXPLevel;
            GetComponent<soldierflash>().bulletDmg = GetComponent<soldierflash>().bulletDmg + GetComponent<FollowPlayer>().currentXPLevel;            
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
                if (collider.tag == "soldier" || collider.tag == "suicide" || collider.tag == "mech"  || collider.tag == "gem") {
                    target = collider.transform;
                    break;
                }
                else {
                    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                }
            }
            if (this.tag == "soldier") {
                if (collider.tag == "zombie") {
                    target = collider.transform;
                    break;
                }
                else {
                    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                }
            }          
        }

        if (this.tag == "zombie" && this.GetComponent<damage>().health > 0) 
        {
            if (Vector2.Distance(transform.position, target.position) < range) {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                Animator animator = gameObject.GetComponent<Animator>();
                animator.runtimeAnimatorController = run as RuntimeAnimatorController;
            }
            else {
                Animator animator = gameObject.GetComponent<Animator>();
                animator.runtimeAnimatorController = idle as RuntimeAnimatorController;
            }
        }

        if (this.tag == "soldier" || this.tag == "mech" || this.tag == "suicide" && this.GetComponent<damageSoldier>().health > 0) 
        {
            if (Vector2.Distance(transform.position, target.position) < range) {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                Animator animator = gameObject.GetComponent<Animator>();
                animator.runtimeAnimatorController = run as RuntimeAnimatorController;
            }
            else {
                Animator animator = gameObject.GetComponent<Animator>();
                animator.runtimeAnimatorController = idle as RuntimeAnimatorController;
            }       
        }
        mySpriteRenderer.flipX = target.position.x < this.transform.position.x;

        if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xp >= GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel) {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel+1;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().barXP = 0;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().lastXP = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel;
            GameObject.Find("Player").GetComponent<PlayerMovement>().moveSpeed += 1;
            zombieCount = GameObject.FindGameObjectsWithTag("zombie"); 
            foreach (GameObject zombie in zombieCount) {
                zombie.GetComponent<FollowPlayer>().currentXPLevel += 1;
                zombie.GetComponent<damage>().maxHealth += zombie.GetComponent<FollowPlayer>().currentXPLevel*10;
                zombie.GetComponent<damage>().health = zombie.GetComponent<damage>().maxHealth;
                zombie.GetComponent<ZombieShoot>().fireRate -= 250;
                zombie.GetComponent<FollowPlayer>().speed += 1f;
                zombie.GetComponent<FollowPlayer>().range += 1f;
                zombie.GetComponent<hand>().handAmount += 1;
                zombie.GetComponent<hand>().handDmg += 1;
                zombie.GetComponent<FollowPlayer>().zombieLimit += 10;

            }

            soldierCount = GameObject.FindGameObjectsWithTag("soldier");
            foreach (GameObject soldier in soldierCount) {
                soldier.GetComponent<damageSoldier>().maxHealth += soldier.GetComponent<FollowPlayer>().currentXPLevel*soldier.GetComponent<damageSoldier>().maxHealth;
                //soldier.GetComponent<damageSoldier>().health = soldier.GetComponent<damage>().maxHealth;                
                soldier.GetComponent<soldierflash>().dmg += 1f;
                soldier.GetComponent<soldierflash>().bulletDmg += 1f;
            }
            StartCoroutine(WaitForXPUpdate());

            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel = Mathf.Round((GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel + GameObject.Find("ScoreManager").GetComponent<ScoreManager>().xpNextLevel) * 1.05f);
            Instantiate(zombie, this.transform.position, Quaternion.identity);
            Instantiate(levelupSFX, this.transform.position, Quaternion.identity);
            StartCoroutine(SlowMotionRoutine());
        }

        if (GetComponent<FollowPlayer>().currentXPLevel >= 2) {
            GetComponent<hand>().enabled = true;
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

        GameObject.Find("LevelUpText").GetComponent<Text>().enabled = false;
        GameObject.Find("+1").GetComponent<Text>().enabled = false;
        GameObject.Find("MaxHealthText").GetComponent<Text>().enabled = false;
        //GameObject.Find("PressA").GetComponent<Text>().enabled = false;
    }

    IEnumerator SlowMotionRoutine() {
        GetComponent<SlowMotion>().enabled = true;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        GetComponent<SlowMotion>().enabled = false;
    }
}
