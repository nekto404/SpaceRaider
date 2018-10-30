using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering;

[Serializable]
public class WeaponData
{
    public Transform WeponTransform;
    public GameObject Mislle;
    public float Recharge;
    public float TimeToAvalibility;
}

public class Weapon : MonoBehaviour
{
    public List<WeaponData> WeaponDatas;

    void Update()
    {
        foreach (var weapon in WeaponDatas)
        {
            if (weapon.TimeToAvalibility <= 0)
                return;
            weapon.TimeToAvalibility -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        foreach (var weapon in WeaponDatas)
        {
            if (weapon.TimeToAvalibility > 0) continue;
            weapon.TimeToAvalibility = weapon.Recharge;
            Instantiate(weapon.Mislle, weapon.WeponTransform.position, weapon.WeponTransform.rotation);
        }
    }
}
