using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeIntoBullets : MonoBehaviour
{
    public GameObject bullet;
    public int bulletSpreadCount = 12;
    float deg;
    public Vector2 dir;
    public float angle; 
    public float shootingPower = 10f; //force of projection   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForObject());
    }

    // Update is called once per frame
    public void ExplodeIntoBulletsFunction()
    {
        dir = ((Camera.main.ScreenToWorldPoint(Input.mousePosition)) - this.transform.localPosition);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;  

        for (int i = 0; i < bulletSpreadCount; i++) {
            GameObject projectile = PoolManagerMode.SharedInstance.GetPooledBullet();
            if (projectile != null) {
                projectile.transform.position = this.transform.position;
                projectile.transform.rotation = Quaternion.identity;
                projectile.SetActive(true);
                deg += 30f;
                var x = projectile.transform.position.x - dir.x;
                var y = projectile.transform.position.y - dir.y;                    
                float spreadAngle = deg;
                float rotateAngle = spreadAngle + (Mathf.Atan2(y, x) * Mathf.Rad2Deg);
                var MovementDirection = new Vector2(Mathf.Cos((rotateAngle) * Mathf.Deg2Rad), Mathf.Sin((rotateAngle) * Mathf.Deg2Rad)).normalized;
                Vector2 direction = MovementDirection; //get the direction to the target
                projectile.GetComponent<Rigidbody2D>().velocity = -1 * direction.normalized * shootingPower; //shoot the bullet  
            }     
        }               
    }

    IEnumerator WaitForObject() {
        yield return new WaitForSeconds(0.1f);
        ExplodeIntoBulletsFunction();
    }
}
