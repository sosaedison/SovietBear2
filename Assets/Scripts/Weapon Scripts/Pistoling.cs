using UnityEngine;
using System.Collections;

public class Pistoling : Weapon {

    bool canShoot;
    int frameCount;

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (!FindObjectOfType<LevelManager>().paused)
        {
            frameCount++;
            int frameCoolDown = (int)(coolDown * 60f);
            if (frameCount == frameCoolDown)
            {
                canShoot = true;
            }
        }
    }
	
	override public void Shoot (Vector2 direction)
	{
        if (ammo > 0 && canShoot)
		{
            FireBullet(direction);
            canShoot = false;
            frameCount = 0;
		}
	}
}
