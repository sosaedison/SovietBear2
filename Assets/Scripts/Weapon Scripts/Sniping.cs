using UnityEngine;
using System.Collections;

public class Sniping : Weapon {

	bool canShoot = true;
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
		if(ammo > 0 && canShoot == true)
		{
            FireBullet(direction);
            canShoot = false;
            frameCount = 0;
        }
	}
}
