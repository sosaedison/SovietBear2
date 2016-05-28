using UnityEngine;
using System.Collections;

public class TankCombat : BossCombat {

    public float chargeSpeed;
    public int chargeDamage;

    Weapon cannon;
    EnemyMovement movement;

    bool charging;
    bool returning;
    float startX;

    new void Start () {
        base.Start();
        cannon = GetComponent<Weapon>();
        mainAttacks = 1;
        nearDeathAttacks = 2;
        movement = GetComponent<EnemyMovement>();
        movement.useMovementAI = false;
	}

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (charging)
        {
            movement.Walk(-chargeSpeed, false);
            if (movement.FindWall())
            {
                charging = false;
                returning = true;
            }
        }
        else if (returning)
        {
            movement.Walk(chargeSpeed / 2, true);
            if (transform.position.x >= startX)
            {
                returning = false;
                attacking = false;
            }
        }
        else
        {
            movement.Walk(0.0f,true);
        }
    }

    override protected void Attack(bool nearDeath)
    {
        base.Attack(nearDeath);
        if (!attacking && movement.canJump)
        {
            if (attackIndex == 0)
            {
                Vector2 direction = player.transform.position - transform.position;
                cannon.FireBullet(direction);
            }
            else if (attackIndex == 1)
            {
                startX = transform.position.x;
                attacking = true;
                charging = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (charging && health)
        {
            health.TakeDamage(chargeDamage);
        }
    }
}
