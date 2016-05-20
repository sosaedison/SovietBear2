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
	void AutoShoot ()
	{
		if (ammo > 0 && CanShoot == true)
		{
			Instantiate(prefab, new Vector2(transform.position.x + 1.0f, transform.position.y), Quaternion.identity);
			ammo = ammo - 1;
			firing = true;
			CanShoot = false;
		}
		if (firing == true)
		{
			//The intervals for firing need to be shorter is the bullet is moving faster
			++burstFireCooldown;
			if (burstFireCooldown == 10)
			{
				Instantiate(prefab, new Vector3(transform.position.x + 1.0f, transform.position.y), Quaternion.identity);
				ammo = ammo - 1;
			}
			else if (burstFireCooldown == 19)
			{
				Instantiate(prefab, new Vector3(transform.position.x + 1.0f, transform.position.y), Quaternion.identity);
				ammo = ammo - 1;
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
