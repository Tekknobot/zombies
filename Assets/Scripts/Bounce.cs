using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D rigidbodyObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        if((screenPosition.y > Screen.height) || (screenPosition.y < 0f) || (screenPosition.x > Screen.width) || (screenPosition.x <0f))
        {   
            screenPosition.x = Mathf.Clamp(screenPosition.x, 0f, Screen.width);
            screenPosition.y = Mathf.Clamp(screenPosition.y, 0f, Screen.height);
            Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            this.transform.position = new Vector2(newWorldPosition.x, newWorldPosition.y);
            Move();
        }
    }    

    private void Move()
    {
        velocity *= -1f;
        rigidbodyObject.velocity = velocity;
    }    
}
