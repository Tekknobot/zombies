using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public GameObject gun;
    public GameObject laserParticles;
    private LineRenderer _lineRenderer;
    public Transform target;
    public int range = 10;

    // Use this for initialization
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource laserSFX = gameObject.GetComponent<AudioSource>();
        
        _lineRenderer.SetPosition(0, transform.position);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders) { 
            if (collider.tag == "zombie") {
                target = collider.transform;
                _lineRenderer.SetPosition(1, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z));
                //Instantiate(laserParticles, hit.point, Quaternion.identity);
                laserSFX.Play();                                                    
                break;
            }
            else
            {
                _lineRenderer.SetPosition(1, transform.up * 2000);
            }

            if (collider.transform.tag == "soldier") {
                Instantiate(laserParticles, collider.transform.position, Quaternion.identity);
            }             
        }       
    }    
}
