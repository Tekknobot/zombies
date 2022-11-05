﻿ using UnityEngine;
 using System.Collections;
 
public class PlayerGun : MonoBehaviour
{
    public Transform target; //where we want to shoot(player? mouse?)
    public Transform weaponMuzzle; //The empty game object which will be our weapon muzzle to shoot from
    public GameObject[] bullet; //Your set-up prefab
    public float fireRate = 3000f; //Fire every 3 seconds
    public float shootingPower = 20f; //force of projection
    public float range = 10f;
    private float shootingTime; //local to store last time we shot so we can make sure its done every 3s

    float deg;
    public Vector2 dir;
    public float angle;

    public bool pistol;
    public bool shotgun;
    public bool machinegun;
    public bool grenadeLauncher;

    public int magCurrent = 0;
    public int magSize = 5;
    public int shotgunSpreadCount = 3;
    public int offset;
    public bool canShoot = false;

    // Update is called once per frame
    void Update ()
    {
        dir = ((Camera.main.ScreenToWorldPoint(Input.mousePosition)) - this.transform.localPosition);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetButton("Fire1") && pistol == true) {
            FirePistol();            
        }

        if (Input.GetButton("Fire1") && shotgun == true) {
            FireShotgun();            
        }    

        if (Input.GetButton("Fire1") && machinegun == true && canShoot == false) {
            FireMachinegun();           
        }              
    }

    private void FirePistol()
    {
        if (Time.time > shootingTime)
        {
            fireRate = 500;
            shootingPower = 10;
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
            
            GameObject projectile = PoolManagerMode.SharedInstance.GetPooledBullet();
            if (projectile != null) {
                projectile.transform.position = myPos;
                projectile.transform.rotation = Quaternion.identity;
                projectile.SetActive(true);
            }             

            Vector2 direction = myPos - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); //get the direction to the target
            projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction.normalized * shootingPower; //shoot the bullet                
        }
    }      

    private void FireShotgun()
    {
        if (Time.time > shootingTime)
        {
            fireRate = 500;
            shootingPower = 10;
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.localPosition.x, weaponMuzzle.localPosition.y); //our curr position is where our muzzle points    

            deg = 0;

            for (int i = 0; i < shotgunSpreadCount; i++) {
                GameObject projectile = PoolManagerMode.SharedInstance.GetPooledBullet();
                if (projectile != null) {
                    projectile.transform.position = this.transform.position;
                    projectile.transform.rotation = Quaternion.identity;
                    projectile.SetActive(true);
                    deg += 8f;
                    var x = projectile.transform.position.x - dir.x;
                    var y = projectile.transform.position.y - dir.y;                    
                    float spreadAngle = deg;
                    float rotateAngle = spreadAngle + (Mathf.Atan2(y, x) * Mathf.Rad2Deg-offset);
                    var MovementDirection = new Vector2(Mathf.Cos((rotateAngle) * Mathf.Deg2Rad), Mathf.Sin((rotateAngle) * Mathf.Deg2Rad)).normalized;
                    Vector2 direction = MovementDirection; //get the direction to the target
                    projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction.normalized * shootingPower; //shoot the bullet  
                }     
            }
        }
    } 

    private void FireMachinegun()
    {
        if (Time.time > shootingTime)
        {
            fireRate = 100;
            shootingPower = 10;
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
            
            if (magSize > magCurrent) {
                GameObject projectile = PoolManagerMode.SharedInstance.GetPooledBullet();
                if (projectile != null) {
                    projectile.transform.position = myPos;
                    projectile.transform.rotation = Quaternion.identity;
                    projectile.SetActive(true);
                    Vector2 direction = myPos - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); //get the direction to the target
                    projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction.normalized * shootingPower; //shoot the bullet                    
                    magCurrent += 1;
                }             
            }
            else {
                StartCoroutine(Reload());
            }
        }
    }         

    IEnumerator Reload() {
        canShoot = true;
        yield return new WaitForSeconds(2);
        magCurrent = 0;
        canShoot = false;
    }
}