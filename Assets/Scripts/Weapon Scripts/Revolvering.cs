using UnityEngine;
using System.Collections;

public class Revolvering : Weapon {

    public int shotsBeforePause = 7;
    public int pauseTimeInFrames = 120;
    public int shotsBeforePauseAlso = 7;
    public int pauseTimeInFramesAlso = 120;
    bool canShoot;
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
	
	override public void Shoot (Vector2 direction)
	{
        if (ammo > 0 && canShoot)
		{
            FireBullet(direction);
            shotsBeforePause = shotsBeforePause - 1;
            canShoot = false;
            frameCount = 0;
		}
	}
}
