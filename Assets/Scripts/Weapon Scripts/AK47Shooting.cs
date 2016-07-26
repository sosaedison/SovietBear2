using UnityEngine;
using System.Collections;

public class AK47Shooting : Weapon {

    public int shotsBeforePause = 30;
    public int pauseTimeInFrames = 180;
    public int shotsBeforePauseAlso = 30;
    public int pauseTimeInFramesAlso = 180;

    int burstFireCooldown = 0;
	bool firing = false;
	bool canShoot = true;

	Vector2 currentDirection;
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
			if (firing == true)
			{
				//The intervals for firing need to be shorter is the bullet is moving faster
				++burstFireCooldown;
				if (burstFireCooldown == 10 || burstFireCooldown == 19)
				{
					FireBullet(currentDirection);
				}
				else if (burstFireCooldown == 21)
				{
					burstFireCooldown = 0;
					firing = false;
					frameCount = 0;
					currentDirection = Vector2.zero;
				}
			}
        }

        if (shotsBeforePause == 0)
        {
            canShoot = false;
            pauseTimeInFrames = pauseTimeInFrames - 1;
        }
        if (pauseTimeInFrames == 0)
        {
            shotsBeforePause = shotsBeforePauseAlso;
            pauseTimeInFrames = pauseTimeInFramesAlso;
            canShoot = true;
        }
    }

    override public void AutoShoot (Vector2 direction)
	{
		if (ammo > 0 && canShoot == true)
		{
            FireBullet(direction);
			currentDirection = direction;
			firing = true;
            shotsBeforePause = shotsBeforePause - 3;
            canShoot = false;
		}

	}
}
