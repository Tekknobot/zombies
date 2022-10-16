using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "levelup") {
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            Destroy(this.gameObject, 5.0f);
        }

        if (tag == "fireup") {
            //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            //Destroy(this.gameObject, 5.0f);
        }
    }
}
