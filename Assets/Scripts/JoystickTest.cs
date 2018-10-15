using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnControls;

public class JoystickTest : MonoBehaviour {

    public Text info;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        info.text = "H: " + CnInputManager.GetAxis("Horizontal") +
            " V: " + CnInputManager.GetAxis("Vertical");

    }
}
