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

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x * GameData.Incstance.SpeedKof * speed * Time.deltaTime,
            direction.y * GameData.Incstance.SpeedKof * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

}