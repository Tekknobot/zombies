using UnityEngine;
using System.Collections;

public class CrosshairFollow : MonoBehaviour {

    public bool controller = true;
    public GameObject crosshair;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Joystick X") != 0 || (Input.GetAxis("Joystick Y") != 0)) {
            controller = true;
        }
        if (Input.GetAxis("Mouse X") != 0 || (Input.GetAxis("Mouse Y") != 0)) {
            controller = false;
        }        

        if (controller == true) {
            crosshair.GetComponent<SpriteRenderer>().enabled = true;
            float heading = Mathf.Atan2(Input.GetAxis("Joystick Y"),Input.GetAxis("Joystick X")) * Mathf.Rad2Deg;
            transform.rotation=Quaternion.Euler(0f,0f,heading);
        }
        else {
            crosshair.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}