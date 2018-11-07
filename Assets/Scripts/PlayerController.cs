using CnControls;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ship PlayerShip;
    public Weapon Weapon;
    public static PlayerController Instance;

    void Start()
    {
        if (Instance) return;
        Instance = this;
    }

	void Update () {
        NewShipPosition(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
	    if (Input.GetButton("Submit"))
	    {
	        Fire();
	    }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Meteor":
                var meteor = collider.GetComponent<Meteor>();
                if (!meteor) return;
                var damage = meteor.GetDamage();
                Damage(damage);
                meteor.DestroyThis();
                break;
            case "EnemyWeapon":
                var missle = collider.gameObject.GetComponent<Missle>();
                if (!missle)
                    return;
                Damage(missle.GetDamage());
                Destroy(missle.gameObject);
                break;
        }
    }

    public void Damage(float damage)
    {
        PlayerShip.curent_hp -= damage;
        if (PlayerShip.curent_hp <= 0)
        {
            DestroyThis();
        }
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    void NewShipPosition(float horizontal, float vertical)
    {
        transform.position += new Vector3(
            ((transform.position.x + PlayerSpeedCalculation(horizontal) >
              -GameController.Incstance.MaxHorizontalPosition) &&
             (transform.position.x + PlayerSpeedCalculation(horizontal) <
              GameController.Incstance.MaxHorizontalPosition))
                ? PlayerSpeedCalculation(horizontal)
                : 0,
            ((transform.position.y + PlayerSpeedCalculation(vertical) >
              -GameController.Incstance.MaxVerticalPosition) &&
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
        return SpeedKof * PlayerShip.speed * GameController.Incstance.SpeedKof * Time.deltaTime;
    }
}
