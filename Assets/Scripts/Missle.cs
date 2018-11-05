using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private bool isPlayerMilles;

    public void Start()
    {
        direction = direction.normalized;
    }

    void Update()
    {
        transform.position += new Vector3(MissleSpeedCalculation(direction.x),
            MissleSpeedCalculation(direction.y));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Border":
                Destroy(gameObject);
                break;
            case "Meteor":
                Destroy(gameObject);
                break;
        }
    }

    public float MissleSpeedCalculation(float koef)
    {
        return koef * GameController.Incstance.SpeedKof * speed * Time.deltaTime;
    }

    public float GetDamage()
    {
        return damage;
    }
}