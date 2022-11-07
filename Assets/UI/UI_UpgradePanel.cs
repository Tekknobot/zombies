using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpgradePanel : MonoBehaviour
{
    public GameObject green;
    public GameObject yellow;
    public GameObject red;
    public GameObject orange;
    public GameObject blue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString != "") Debug.Log(Input.inputString);
        
        if (Input.GetAxis("DPAD_h") == 1) {
            green.GetComponent<Button>().Select();
        }
    }
}
