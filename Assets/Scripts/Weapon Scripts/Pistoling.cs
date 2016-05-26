using UnityEngine;
using System.Collections;

public class Pistoling : Weapon {
	
    float nextShotTime = 0f;
	
	override public void Shoot (Vector2 direction)
	{
        if (ammo > 0 && Time.time >= nextShotTime)
		{
            FireBullet(direction);
            nextShotTime = Time.time + coolDown;
		}
	}
}
