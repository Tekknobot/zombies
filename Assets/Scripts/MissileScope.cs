using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScope : MonoBehaviour
{
    public GameObject explosion;
    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
       if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().zombieCount.Length == 50 && flag == false) {
            GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(TargetHorde());        
       }
    }

    IEnumerator TargetHorde() {
        flag = true;
        yield return new WaitForSeconds(5);
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().enabled = false;
        
    }
}
