using UnityEngine;
using System.Collections;

public class Rifleing : Weapon {

	int burstFireCooldown = 0;
	bool firing = false;
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
			firing = true;
			canShoot = false;
		}
		if (firing == true)
		{
			//The intervals for firing need to be shorter is the bullet is moving faster
			++burstFireCooldown;
			if (burstFireCooldown == 10 || burstFireCooldown == 19)
			{
                FireBullet(direction);
			}
			else if (burstFireCooldown == 21)
			{
				burstFireCooldown = 0;
				firing = false;
                frameCount = 0;
			}
		}
	}
}
