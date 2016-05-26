using UnityEngine;
using System.Collections;

public class Rifleing : Weapon {

	int burstFireCooldown = 0;
	bool firing = false;
	bool CanShoot = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	override public void AutoShoot (Vector2 direction)
	{
		if (ammo > 0 && CanShoot == true)
		{
            FireBullet(direction);
			firing = true;
			CanShoot = false;
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
				Invoke("Reset", coolDown);
			}
		}
	}
	void Reset()
	{
		CanShoot = true;
	}
}
