using UnityEngine;
using System.Collections;

public class Rifleing : Weapon {

	public GameObject prefab;
	public int ammo = 100;
	public int burstFireCooldown = 0;
	public bool firing = false;
	bool CanShoot = true;
	float CoolDown = .6f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	override public void AutoShoot (Vector2 direction)
	{
		if (ammo > 0 && CanShoot == true)
		{
            Vector2 bulletOffset = new Vector2(2.65f, 0.73f);
            if (direction.x < 0)
            {
                bulletOffset.x *= -1.0f;
            }
            GameObject bullet = (GameObject) Instantiate(prefab, (Vector2)transform.position + bulletOffset, Quaternion.identity);
			BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
			bulletMotion.direction = direction;
			bulletMotion.speed = 500f;
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
                Vector2 bulletOffset = new Vector2(2.65f, 0.73f);
                if (direction.x < 0)
                {
                    bulletOffset.x *= -1.0f;
                }
                GameObject bullet = (GameObject)Instantiate(prefab, (Vector2)transform.position + bulletOffset, Quaternion.identity);
				BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
				bulletMotion.direction = direction;
				bulletMotion.speed = 500f;
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
