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
    private float curentT;

    void Start()
    {
        curentT = 0;
        period = fireTime + rechargeTime;
    }

    public override void ShipLogic(float deltaTime)
    {
        curentT += deltaTime;
        if (curentT > period)
        {
            curentT -= period;
        }

        if (curentT > rechargeTime)
        {
            Fire();
        }
    }
}