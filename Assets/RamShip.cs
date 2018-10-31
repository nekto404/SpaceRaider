using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : EnemyShip
{
    [SerializeField] private float ramSpeedKof;
    [SerializeField] private float playerFindKof;

    public override void ShipLogic(float deltaTime)
    {
        var player = PlayerController.Instance;
        if (!player) return;
        var directionToPlayer = Vector3.Normalize( player.transform.position - transform.position);
        var shipDirection = Vector3.Normalize(Quaternion.AngleAxis(transform.rotation.eulerAngles.z,Vector3.down)*Vector3.down* ramSpeedKof + playerFindKof * directionToPlayer);
        transform.position += new Vector3(ShipSpeedCalculation(shipDirection.x), ShipSpeedCalculation(shipDirection.y));
    }
}
