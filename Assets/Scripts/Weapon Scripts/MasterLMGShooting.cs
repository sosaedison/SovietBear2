using UnityEngine;
using System.Collections;

public class MasterLMGShooting : Weapon {

    public int shotsBeforePause = 50;
    public int pauseTimeInFrames = 420;
    public int shotsBeforePauseAlso = 50;
    public int pauseTimeInFramesAlso = 420;

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
            shotsBeforePause = shotsBeforePause - 1;
            canShoot = false;
            frameCount = 0;
		}
	}
}
