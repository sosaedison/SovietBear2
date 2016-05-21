﻿using UnityEngine;
using System.Collections;

public class Flamethrowing : Weapon {

	public GameObject prefab;
	public int ammo = 1200;
	public int flameFireCooldown = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	override public void AutoShoot (Vector2 direction)
	{
		if (ammo > 0)
		{
			++flameFireCooldown;
			// Cooldown timer needs to be larger for faster bullets
			if (flameFireCooldown == 7)
			{
				Instantiate(prefab, new Vector2(transform.position.x + 1.1f, transform.position.y -.25f), Quaternion.identity);
				ammo = ammo - 1;
				Instantiate(prefab, new Vector2(transform.position.x + .75f, transform.position.y), Quaternion.identity);
				ammo = ammo - 1;
				Instantiate(prefab, new Vector2(transform.position.x + 1.1f, transform.position.y + .25f), Quaternion.identity);
				ammo = ammo - 1;
				flameFireCooldown = 0;
			}
		}
	}
}