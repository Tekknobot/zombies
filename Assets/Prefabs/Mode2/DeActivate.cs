using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivate : MonoBehaviour
{
    public float time = 0.25f;

    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("DestroyObject", time);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void DestroyObject() {
        gameObject.SetActive(false); 
    }
}
