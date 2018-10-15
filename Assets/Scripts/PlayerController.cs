using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using CnControls;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Ship PlayerShip;
    public float MaxHorizontalPosition;
    public float MaxVerticalPosition;
    public float SpeedKof;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(((transform.position.x + CnInputManager.GetAxis("Horizontal") * PlayerShip.speed * SpeedKof > - MaxHorizontalPosition) &&
            (transform.position.x + CnInputManager.GetAxis("Horizontal") * PlayerShip.speed * SpeedKof < MaxHorizontalPosition) ) 
            ? transform.position.x + CnInputManager.GetAxis("Horizontal") * PlayerShip.speed * SpeedKof : transform.position.x,
             ((transform.position.y + CnInputManager.GetAxis("Vertical") * PlayerShip.speed * SpeedKof > - MaxVerticalPosition) && 
             (transform.position.y + CnInputManager.GetAxis("Vertical") * PlayerShip.speed * SpeedKof < MaxVerticalPosition)) ?
             transform.position.y + CnInputManager.GetAxis("Vertical") * PlayerShip.speed * SpeedKof : transform.position.y,
             0);
    }
}
