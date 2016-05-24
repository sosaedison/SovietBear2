using UnityEngine;
using System.Collections;

public class Rifleing : Weapon {

	public GameObject prefab;
	public int burstFireCooldown = 0;
	public bool firing = false;
	bool CanShoot = true;
	float CoolDown = 1.2f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
            GameObject bullet = (GameObject) Instantiate(prefab, (Vector2)transform.position + tempBulletOffset, Quaternion.identity);
			BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
			bulletMotion.direction = direction;
			bulletMotion.speed = 30f;
			bulletMotion.Activate();
            ammo--;
			firing = true;
			CanShoot = false;
		}
		if (firing == true)
		{
			//The intervals for firing need to be shorter is the bullet is moving faster
			++burstFireCooldown;
			if (burstFireCooldown == 10 || burstFireCooldown == 19)
			{
                Vector2 tempBulletOffset = bulletOffset;
                if (direction.x < 0)
                {
                    tempBulletOffset.x *= -1.0f;
                }
                GameObject bullet = (GameObject)Instantiate(prefab, (Vector2)transform.position + tempBulletOffset, Quaternion.identity);
				BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
				bulletMotion.direction = direction;
				bulletMotion.speed = 30f;
				bulletMotion.Activate();
                ammo--;
			}
			else if (burstFireCooldown == 21)
			{
				burstFireCooldown = 0;
				firing = false;
				Invoke("Reset", CoolDown);
			}
		}
	}
	void Reset()
	{
		CanShoot = true;
	}
}
