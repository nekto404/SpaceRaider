using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Vector2 direction;
	
	void Update () {
	    transform.position += new Vector3(MeteorSpeedCalculation(direction.x),
	        MeteorSpeedCalculation(direction.y));
    }

    public float MeteorSpeedCalculation(float koef)
    {
        return koef * GameController.Incstance.SpeedKof * speed * Time.deltaTime;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
