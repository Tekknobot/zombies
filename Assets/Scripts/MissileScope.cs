using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScope : MonoBehaviour
{
    public GameObject explosion;
    public bool flag;

    public AudioSource audioData;
    public int i = 0;

    public Transform target;
    public float range = 10;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) < range) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

       if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().currentXPLevel > i && flag == false) {
            GetComponent<SpriteRenderer>().enabled = true;
            audioData.Play();
            StartCoroutine(TargetHorde());        
       }
    }

    IEnumerator TargetHorde() {
        flag = true;
        i++;
        yield return new WaitForSeconds(5);
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().enabled = false;
        audioData.Stop();
        flag = false;        
    }
}
