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

    // Update is called once per frame
    void Update ()
    {
        var dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButton("Fire1")) {
            Fire();            
        }
    }

    private void Fire()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
            //GameObject projectile = Instantiate(bullet[Random.Range(1, 6)], myPos, Quaternion.identity); //create our bullet
            
            GameObject projectile = PoolManager2.SharedInstance.GetPooledBullet();
            if (projectile != null) {
                projectile.transform.position = myPos;
                projectile.transform.rotation = Quaternion.identity;
                projectile.SetActive(true);
            }             
            
            Vector2 direction = myPos - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); //get the direction to the target
            projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction * shootingPower; //shoot the bullet
        }
    }      
}