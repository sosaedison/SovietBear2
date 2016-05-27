using UnityEngine;
using System.Collections;

public class AnimalCombat : EnemyCombat {

    AnimateSprite sprite;
    EnemyMovement movement;
    float timeCount;
    bool pouncing;
    bool landing;
    public int baseDamage;
    public int pounchDamage;
    public float waitTime;

	// Use this for initialization
	new void Start () {
        base.Start();
        sprite = GetComponent<AnimateSprite>();
        movement = GetComponent<EnemyMovement>();
    }

    override public void Attack()
    {
        Vector2 distance = playerDetectionAI.playerInCone.transform.position - transform.position;

        if (distance.magnitude < 20 && !pouncing)
        {
            movement.useMovementAI = false;
            movement.Walk(-1 * distance.normalized.x * movement.movementSpeed, true);
        }
        else if (distance.magnitude < 25 && !pouncing)
        {
            movement.useMovementAI = false;
            movement.Walk(0.0f, false);
            pouncing = true;
            timeCount = 0;
            sprite.staticIndex = 2;
        }
        
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
        if (!LevelManager.isPaused())
        {
            timeCount += Time.deltaTime;
            if (timeCount >= waitTime)
            {
                if (pouncing == true)
                {
                    sprite.staticIndex = 1;
                    float Vx = 20f;
                    if (transform.rotation.eulerAngles.y != 0) Vx *= -1;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(Vx, 5f);
                }
                else if (landing == true)
                {
                    landing = false;
                    movement.useMovementAI = true;
                    sprite.staticIndex = 0;
                }

            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8 && !LevelManager.isPaused())
        {
            if (pouncing)
            {
                movement.Walk(0.0f, false);
                sprite.staticIndex = 3;
                pouncing = false;
                landing = true;
                timeCount = 0;
            }
        }
        else
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                if (pouncing)
                {
                    health.current -= pounchDamage;
                } 
                else
                {
                    health.current -= baseDamage;
                }
                
            }
        }

    }
}
