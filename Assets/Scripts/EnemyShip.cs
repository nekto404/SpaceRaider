using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public abstract class EnemyShip : MonoBehaviour
{
    [SerializeField] private Ship ship;
    [SerializeField] private Weapon weapon;


    public virtual void Update()
    {
        ShipLogic(Time.deltaTime);
    }

    public virtual void ShipLogic(float deltaTime)
    {
        
    }

    public virtual void Fire()
    {
        weapon.Fire();
    }

    public virtual void Damage(float damage)
    {
        ship.curent_hp -= damage;
        if (ship.curent_hp <= 0)
        {
            DestroyThis();
        }
    }

    public virtual void DestroyThis()
    {
        Destroy(gameObject);
    }

    public float ShipSpeedCalculation(float speedKof)
    {
        return speedKof * ship.speed * GameController.Incstance.SpeedKof * Time.deltaTime;
    }

    public float VectorToAngle(Vector3 vector)
    {
        var normVector = Vector3.Normalize(vector);
        var angle = normVector.x > 0 ? Mathf.Rad2Deg * (Mathf.Acos(-normVector.y)) : 
            - Mathf.Rad2Deg * (Mathf.Acos(-normVector.y));     
        return angle;
    }

    public Vector3 AngleDegToVector(float angle)
    {
        var vector = new Vector3();
        vector.x = Mathf.Sin(Mathf.Deg2Rad * angle);
        vector.y = - Mathf.Cos(Mathf.Deg2Rad * angle);
        return vector;
    }

    public Vector3 AngleRadToVector(float angle)
    {
        var vector = new Vector3();
        vector.x = Mathf.Sin(angle);
        vector.y = - Mathf.Cos(angle);
        return vector;
    }

    public float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle < -180F)
        {
            angle += 360F;
        }
        if (angle > 180F)
        {
            angle -= 360F;
        }
        return angle;
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "PlayerWeapon":
                var missle = collider.gameObject.GetComponent<Missle>();
                if (!missle) return;
                Damage(missle.GetDamage());
                break;
            case "Border":
                Destroy(gameObject);
                break;
            case "Meteor":
                DestroyThis();
                break;
        }
    }
}
