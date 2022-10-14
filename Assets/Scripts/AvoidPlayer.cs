using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    public float speed;
    public float range;
    public float stoppingDistance;

    public RuntimeAnimatorController run;
    public RuntimeAnimatorController idle;

    public Transform target;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {       
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach (Collider2D collider in colliders) {
            if (collider.tag == "zombie") {
                target = collider.transform; 
                break;
            }
            else {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            }             
        }

        if (Vector2.Distance(transform.position, target.position) < range) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);
            Animator animator = gameObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = run as RuntimeAnimatorController;
        }
        else {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = idle as RuntimeAnimatorController;
        }
        mySpriteRenderer.flipX = target.position.x < this.transform.position.x;       
    }    
}
