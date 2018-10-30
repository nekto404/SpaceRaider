using Assets;
using CnControls;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ship PlayerShip;
    public Weapon Weapon;

	void Update () {
        NewShipPosition(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
	    if (Input.GetButton("Fire1"))
	    {
	        Fire();
	    }
	}

    void NewShipPosition(float horizontal, float vertical)
    {
        transform.position += new Vector3(
            ((transform.position.x + PlayerSpeedCalculation(horizontal) >
              -GameData.Incstance.MaxHorizontalPosition) &&
             (transform.position.x + PlayerSpeedCalculation(horizontal) <
              GameData.Incstance.MaxHorizontalPosition))
                ? PlayerSpeedCalculation(horizontal)
                : 0,
            ((transform.position.y + PlayerSpeedCalculation(vertical) >
              -GameData.Incstance.MaxVerticalPosition) &&
             (transform.position.y + PlayerSpeedCalculation(vertical) < 0))
                ? PlayerSpeedCalculation(vertical)
                : 0,
            0);
    }

    public void Fire()
    {
       Weapon.Fire();
    }

    public float PlayerSpeedCalculation(float SpeedKof)
    {
        return SpeedKof * PlayerShip.speed * GameData.Incstance.SpeedKof * Time.deltaTime;
    }
}
