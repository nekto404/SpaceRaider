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

    public void InitValues(Vector2 directon, float speed, float damage, bool isPlayerMilles)
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

}