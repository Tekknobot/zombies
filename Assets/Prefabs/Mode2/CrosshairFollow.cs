using UnityEngine;
using System.Collections;

public class CrosshairFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float heading = Mathf.Atan2(Input.GetAxis("Joystick Y"),Input.GetAxis("Joystick X")) * Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0f,0f,heading);
	}
}