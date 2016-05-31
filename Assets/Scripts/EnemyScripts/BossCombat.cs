using UnityEngine;
using System.Collections;

public abstract class BossCombat : MonoBehaviour {

    public int attackCooldown;
    

    protected int attackIndex;
    protected bool attacking;
    protected int mainAttacks;
    protected int nearDeathAttacks;
    protected GameObject player;

    Health health;
    int frameCount;

    protected virtual void Start () {
        health = GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    protected void FixedUpdate () {
        if (!LevelManager.isPaused())
        {
            frameCount++;
            int frameCoolDown = (int)(attackCooldown * 60f);
            if (frameCount >= frameCoolDown)
            {
                Attack(health.current <= health.max / 2);
            }
        }
	}

    virtual protected void Attack(bool nearDeath)
    {
        if (!attacking)
        {
            int maxAttack = mainAttacks;
            if (nearDeath)
                maxAttack = nearDeathAttacks;
            attackIndex = Random.Range(0, maxAttack);
            frameCount = 0;
        }
    }


}
