using UnityEngine;
using System.Collections;

public class ThrowingCombat : EnemyCombat {

    EnemyMovement movement;

    override protected void Start()
    {
        base.Start();
        movement = GetComponent<EnemyMovement>();
    }

    override public void Attack()
    {
        Vector2 distance = playerDetectionAI.playerInCone.transform.position - transform.position;
        if (distance.magnitude > 20)
        {
            GetComponentInChildren<Weapon>().Shoot(distance);
            movement.useMovementAI = true;
        }
        else
        {
            movement.useMovementAI = false;
            movement.Walk(-1 * distance.normalized.x * movement.movementSpeed, true);
        }
    }
}
