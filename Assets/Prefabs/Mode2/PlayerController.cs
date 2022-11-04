using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    new Rigidbody2D rigidbody2D;

    public float movementSpeed = 1000.0f;
    public bool facingRight = true;

    void Awake()
    {
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        FaceMouse();

        // Handle user input
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Move(targetVelocity); 
    }

    void Move(Vector2 targetVelocity)
    {        
        // Set rigidbody velocity
        rigidbody2D.velocity = (targetVelocity * movementSpeed) * Time.deltaTime; // Multiply the target by deltaTime to make movement speed consistent across different framerates
    }

    private void Flip()
    {
        // Rotate the player
        if (transform.localEulerAngles.y != 180 && !facingRight)
            transform.Rotate(0f, 180f, 0f);
        else if(transform.localEulerAngles.y != 0 && facingRight)
                transform.Rotate(0f, -180f, 0f);

        // player flip point of attck also flip is direction
        //transform.Rotate(0f, 180f, 0f);
    }

    void FaceMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
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