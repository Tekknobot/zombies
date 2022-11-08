using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityLineRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go1;
    public GameObject go2;

    [SerializeField]
    LineRenderer lr;
    void OnEnable()
    {
        StartCoroutine(LineDraw());
    }
    IEnumerator LineDraw()
    {
        float t = 0;
        float time = 1;
        Vector3 newpos;
        for (; t < time; t += Time.deltaTime)
        {
            newpos = Vector3.Lerp(go1.transform.position, go2.transform.localPosition, t / time);
            lr.SetPosition(1, newpos);
            yield return null;
        }
    }
}