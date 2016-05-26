using UnityEngine;
using System.Collections;

public class Sniping : Weapon {

	bool CanShoot = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	override public void Shoot (Vector2 direction)
	{
		if(ammo > 0 && CanShoot == true)
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
