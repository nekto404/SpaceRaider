using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : EnemyShip
{
    [SerializeField] private float ramSpeedKof;
    [SerializeField] private float playerFindKof;
    [SerializeField] private float ramDamage;

    public override void ShipLogic(float deltaTime)
    {
        var player = PlayerController.Instance;
        if (!player) return;
        var directionToPlayer = Vector3.Normalize( player.transform.position - transform.position);
        var shipDirection = Vector3.Normalize(Quaternion.AngleAxis(transform.rotation.eulerAngles.z , Vector3.down) * Vector3.down * ramSpeedKof + playerFindKof * directionToPlayer);
        transform.position += new Vector3(ShipSpeedCalculation(shipDirection.x), ShipSpeedCalculation(shipDirection.y));
        transform.rotation = Quaternion.Euler(0,0,VectorToAngle(shipDirection));
        //VectorToAngle(directionToPlayer);
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "PlayerWeapon":
                var missle = collider.gameObject.GetComponent<Missle>();
                if (!missle)
                    return;
                Damage(missle.GetDamage());
                break;
            case "Border":
                Destroy(gameObject);
                break;
            case "Meteor":
                DestroyThis();
                break;
            case "Player":
                PlayerController.Instance.Damage(ramDamage);
                DestroyThis();
                break;
        }
    }
}
