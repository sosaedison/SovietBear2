using UnityEngine;
using System.Collections;

public class LMGShooting : Weapon {
	bool CanShoot = true;



	// Update is called once per frame
	void Update () 
	{

	}
	override public void AutoShoot (Vector2 direction)	
	{
		if (ammo > 0 && CanShoot == true)
		{
            FireBullet(direction);
			CanShoot = false;
			Invoke("Reset", coolDown);
		}
	}
	void Reset()
	{
		CanShoot = true;
	}
}
