﻿using UnityEngine;
using System.Collections;

public class Swording : Weapon {

	public bool canSwing = true;
	Animation SwordSwing;

    bool paused;

    int frameCount;

    void Awake()
    {
        SwordSwing = GetComponent<Animation>();
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (!paused)
        {
            frameCount++;
            int frameCoolDown = (int) (coolDown * 60f);
            if (frameCount == frameCoolDown)
            {
                canSwing = true;
            }
        }
    }

	override public void Shoot (Vector2 direction)
	{
		if (canSwing == true)
		{
			canSwing = false;
			SwordSwing.Play();
            frameCount = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (!canSwing)
        {
            if (!other.isTrigger)
            {
                Health health = other.gameObject.GetComponent<Health>();
                if (health != null && canSwing == false)
                {
                    health.TakeDamage(damage);
                }
            }
            else if (other.CompareTag("Laser"))
            {
                other.transform.rotation = Quaternion.Euler(0, 0, -180f);
                other.GetComponent<Rigidbody2D>().velocity = Vector2.left * other.GetComponent<LaserMotion>().speed;
            }
        }
	}

    void OnPause()
    {
        SwordSwing.enabled = false;
        paused = true;
    }

    void OnUnpause()
    {
        SwordSwing.enabled = true;
        paused = false;
    }

    void OnEnable()
    {
        LevelManager.OnPause += OnPause;
        LevelManager.OnUnpause += OnUnpause;
    }

    void OnDisable()
    {
        LevelManager.OnPause -= OnPause;
        LevelManager.OnUnpause -= OnUnpause;
    }
}