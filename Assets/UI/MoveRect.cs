using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRect : MonoBehaviour
{
    //Declare RectTransform in script
    RectTransform target;
    //The new position of your target
    public Vector3 newPos = new Vector3(0, 300f, 0);
    public Vector3 oldPos = new Vector3(0, -100f, 0);
    //Reference value used for the Smoothdamp method
    private Vector3 buttonVelocity = Vector3.zero;
    //Smooth time
    public float smoothTime = 0.5f;

    public bool hasTargetMoved;
 
    void Start()
    {
        //Get the RectTransform component
        target = GetComponent<RectTransform>();
        hasTargetMoved = false;
    }
    
    void Update()
    {
        //Update the localPosition towards the newPos
        if (hasTargetMoved == false) {
            target.localPosition = Vector3.SmoothDamp(target.localPosition, newPos, ref buttonVelocity, smoothTime);
            StartCoroutine(MoveRectPosition());
        }    
        if (hasTargetMoved == true) {
            target.localPosition = Vector3.SmoothDamp(target.localPosition, oldPos, ref buttonVelocity, smoothTime);
        }
    }

    IEnumerator MoveRectPosition() {
        yield return new WaitUntil(() => hasTargetMoved == true);
    }
}