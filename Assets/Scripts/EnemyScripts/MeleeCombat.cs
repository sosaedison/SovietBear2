using UnityEngine;
using System.Collections;

public class MeleeCombat : EnemyCombat {

	// Use this for initialization
	override public void Attack()
    {
        Vector2 distance = playerDetectionAI.playerInCone.transform.position - transform.position;
        if (distance.magnitude < 8)
        {
            GetComponentInChildren<Weapon>().Shoot(distance);
        }
    }
}
