using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float throwForce = 10;

    // Start is called before the first frame update
    void Start () {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2) * throwForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
