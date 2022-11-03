 using UnityEngine;
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

    float tmpVar;

    public bool pistol = true;
    public bool shotgun;
    public bool machinegun;
    public bool grenadeLauncher;

    // Update is called once per frame
    void Update ()
    {
        var dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButton("Fire1") && pistol == true) {
            FirePistol();            
        }

        if (Input.GetButton("Fire1") && shotgun == true) {
            FireShotgun();            
        }        
    }

    private void FirePistol()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
            
            GameObject projectile = PoolManagerMode.SharedInstance.GetPooledBullet();
            if (projectile != null) {
                projectile.transform.position = myPos;
                projectile.transform.rotation = Quaternion.identity;
                projectile.SetActive(true);
            }             
            
            Vector2 direction = myPos - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); //get the direction to the target
            projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction * shootingPower; //shoot the bullet
        }
    }      

    private void FireShotgun()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
            
            tmpVar = -1;
            for (int i = 0; i < 5; i++) {
                GameObject projectile = PoolManagerMode.SharedInstance.GetPooledBullet();
                if (projectile != null) {
                    projectile.transform.position = myPos;
                    projectile.transform.rotation = Quaternion.identity;
                    projectile.SetActive(true);
                    tmpVar += 0.5f;
                }                                            

                Vector2 direction = myPos - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector2(0,tmpVar); //get the direction to the target
                projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction * shootingPower; //shoot the bullet
            }
        }
    }    
}