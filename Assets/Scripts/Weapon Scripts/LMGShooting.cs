using UnityEngine;
using System.Collections;

public class LMGShooting : Weapon {
	bool canShoot = true;

    int frameCount;

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (!LevelManager.isPaused())
        {
            frameCount++;
            int frameCoolDown = (int)(coolDown * 60f);
            if (frameCount == frameCoolDown)
            {
                canShoot = true;
            }
        }
    }

    override public void AutoShoot (Vector2 direction)	
	{
		if (ammo > 0 && canShoot == true)
		{
            FireBullet(direction);
			canShoot = false;
            frameCount = 0;
		}
	}
}
