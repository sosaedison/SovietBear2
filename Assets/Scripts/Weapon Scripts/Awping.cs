using UnityEngine;
using System.Collections;

public class Awping : Weapon {

    public int shotsBeforePause = 10;
    public int pauseTimeInFrames = 300;
    public int shotsBeforePauseAlso = 10;
    public int pauseTimeInFramesAlso = 300;
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

    override public void Shoot (Vector2 direction)
	{
		if(ammo > 0 && canShoot == true)
		{
            FireBullet(direction);
            shotsBeforePause = shotsBeforePause - 1;
            canShoot = false;
            frameCount = 0;
        }
	}
}
