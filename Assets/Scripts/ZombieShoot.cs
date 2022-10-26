using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShoot : MonoBehaviour
{
    public Transform target; //where we want to shoot(player? mouse?)
    public Transform weaponMuzzle; //The empty game object which will be our weapon muzzle to shoot from
    public GameObject[] bullet; //Your set-up prefab
    public float fireRate = 3000f; //Fire every 3 seconds
    public float shootingPower = 20f; //force of projection
    public float range = 10f;

    int choice;
 
    private float shootingTime; //local to store last time we shot so we can make sure its done every 3s

    void Start() {
        // choice = Random.Range(0,2);
        // if (choice == 0) {
        //     this.GetComponent<FollowPlayer>().enabled = true; 
        //     this.GetComponent<ZombieShoot>().enabled = true;
        // }
        // else if (choice == 1){
        //     this.GetComponent<FollowPlayer>().enabled = true; 
        //     this.GetComponent<ZombieShoot>().enabled = false;
        // }        
    }
 
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders) { 
            if (collider.tag == "soldier" && GameObject.FindGameObjectsWithTag("zombiebullet").Length < GameObject.Find("ScoreManager").GetComponent<ScoreManager>().zombieCount.Length) {
                target = collider.transform;                                    
                Fire(); //Constantly fire
                break;
            }
        }
        foreach (Collider2D collider in colliders) { 
            if (collider.tag == "landmine" && GameObject.FindGameObjectsWithTag("grenade").Length == 0) {
                target = collider.transform;
                FireGrenade();
                break;
            }
        }
        foreach (Collider2D collider in colliders) { 
            if (collider.tag == "suicide") {
                target = collider.transform;                                    
                Fire();
                break;
            }  
        }
        foreach (Collider2D collider in colliders) {                    
            if (collider.tag == "mech") {
                target = collider.transform;                                    
                Fire();
                break;
            }  
        }
    }
 
    private void Fire()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
            GameObject projectile = Instantiate(bullet[Random.Range(1, 6)], myPos, Quaternion.identity); //create our bullet
            Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
            projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction * shootingPower; //shoot the bullet
            //GameObject.Find("Main Camera").GetComponent<ShakeBehavior>().TriggerShake();
        }
    }  

    private void FireGrenade()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
            GameObject projectile = Instantiate(bullet[0], myPos, Quaternion.identity); //create our bullet
            Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
            projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction * shootingPower; //shoot the bullet
        }
    }         
}
