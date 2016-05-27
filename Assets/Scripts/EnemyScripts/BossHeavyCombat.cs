using UnityEngine;
using System.Collections;

public class BossHeavyCombat : BossCombat {

    Weapon lmg;
    EnemyMovement movement;

    int attackLength;
    int attackFrameCount;

    new void Start () {
        base.Start();
        lmg = GetComponentInChildren<Weapon>();
        mainAttacks = 2;
        nearDeathAttacks = 3;
        movement = GetComponent<EnemyMovement>();
        movement.useMovementAI = false;
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (!LevelManager.isPaused())
        {
            attackFrameCount++;
            if (attackFrameCount == attackLength)
            {
                attacking = false;
            }
            Vector2 direction = player.transform.position - transform.position;
            if (attacking)
            {
                if (attackIndex == 1) // jump and shoot
                {
                    movement.Jump();
                    Vector2 facing = Vector2.right;
                    if (direction.x < 0)
                        facing = Vector2.left;
                    direction = facing;
                }
                else if (attackIndex == 2) // arc of shots
                {
                    Vector2 facing = Vector2.right;
                    if (direction.x < 0)
                        facing = Vector2.left;
                    direction = Vector2.Lerp(facing, Vector2.up, attackFrameCount / attackLength);
                }
                lmg.AutoShoot(direction);
            }
        }
    }

    override protected void Attack(bool nearDeath)
    {
        base.Attack(nearDeath);
        if (!attacking)
        {
            attacking = true;
            attackFrameCount = 0;
            if (attackIndex == 0) // normal shoot
            {
                int length = Random.Range(1, 5);
                attackLength = (int)(lmg.coolDown * 60f) * length * 5;
            }
            else if (attackIndex == 1) // jump and shoot
            {
                attackLength = (int)(lmg.coolDown * 60f) * 3;
            }
            else if (attackIndex == 2) // arc of shots
            {
                attackLength = (int)(lmg.coolDown * 60f) * 5;
            }
        }
    }
}
