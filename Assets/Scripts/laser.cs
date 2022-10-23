using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public GameObject gun;
    public GameObject blood;
    private LineRenderer _lineRenderer;
    public Transform target;
    public int range = 10;
    public AudioClip laserSFX;
    public bool flag = false; 
    public float timeLeft = 0.1f;  
    public float dmg;

    // Use this for initialization
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        
        _lineRenderer.SetPosition(0, transform.position);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders) { 
            if (collider.tag == "zombie" && flag == false) {
                target = collider.transform;
                this._lineRenderer.enabled = true;
                this._lineRenderer.SetPosition(1, new Vector3(target.transform.position.x, target.transform.position.y, 0));
                audio.clip = laserSFX;
                audio.Play(); 
                collider.GetComponent<flash>().FlashRed();
                collider.GetComponent<flash>().SendMessage("Damage", dmg); 
                flag = true;
                break; 
            }   
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            flag = false;
            timeLeft = 0.1f;
            this._lineRenderer.enabled = false;
        }    
    }
}
