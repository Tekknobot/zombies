using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FollowPlayerMode : MonoBehaviour
{
    public float speed;
    public float range = 10;
    public float stoppingDistance;

    public RuntimeAnimatorController death;

    public Transform target;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("PlayerPrefab").GetComponent<Transform>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();            
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("PlayerPrefab").GetComponent<Transform>();

        mySpriteRenderer.flipX = target.position.x < this.transform.position.x;
        if (Vector2.Distance(transform.position, target.position) < range) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Animator animator = gameObject.GetComponent<Animator>();
        }
        else {
            Animator animator = gameObject.GetComponent<Animator>();
        }

        mySpriteRenderer.flipX = target.position.x < this.transform.position.x;
    }
}