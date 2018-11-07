using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class RiderShip : EnemyShip
{
    [SerializeField]
    private List<GameObject> shipPath;
    [SerializeField]
    private float fireTime;
    [SerializeField]
    private float rechargeTime;

    private float period;
    private float curentTime;
    private int curentPoint;

    void Start()
    {
        curentTime = 0;
        period = fireTime + rechargeTime;
        curentPoint = 0;
    }

    public override void ShipLogic(float deltaTime)
    {
        curentTime += deltaTime;
        if (curentTime > period)
        {
            curentTime -= period;
        }

        if (curentTime > rechargeTime)
        {
            Fire();
        }

        if (Vector3.Distance(transform.position, shipPath[curentPoint].transform.position) < 0.1)
        {
            if (curentPoint + 1 < shipPath.Count)
            {
                curentPoint++;
            }
            else
            {
                curentPoint = 0;
            }
        }

        var shipDirection = Vector3.Normalize(shipPath[curentPoint].transform.position - transform.position);
        transform.position += new Vector3(ShipSpeedCalculation(shipDirection.x), ShipSpeedCalculation(shipDirection.y));
    }
}