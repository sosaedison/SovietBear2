using UnityEngine;
using System.Collections;

public class LMGShooting : Weapon {
	public GameObject Bullet;
	bool CanShoot = true;
	float CoolDown = .09f;
	void Start () 
	{
	}

	// Update is called once per frame
	void Update () 
	{

	}
	override public void AutoShoot (Vector2 direction)	
	{
		if (ammo > 0 && CanShoot == true)
		{
			Vector2 tempBulletOffset = bulletOffset;
			if (direction.x < 0)
			{
				tempBulletOffset.x *= -1.0f;
			}
			GameObject bullet = (GameObject) Instantiate(Bullet, (Vector2) transform.position + tempBulletOffset, Quaternion.identity);
			BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
			bulletMotion.direction = direction;
			bulletMotion.speed = 30f;
			bulletMotion.Activate();
			ammo--;
			CanShoot = false;
			Invoke("Reset", CoolDown);
		}
	}
	void Reset()
	{
		CanShoot = true;
	}
}
