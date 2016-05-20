using UnityEngine;
using System.Collections;

public class Sniping : Weapon {

	public GameObject Bullet;
	public int ammo = 10;
	bool CanShoot = true;
	float CoolDown = 1.2f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Shoot ()
	{
		if(ammo > 0 && CanShoot == true)
		{
			Instantiate(Bullet, new Vector2(transform.position.x + 1.0f, transform.position.y), Quaternion.identity);
			ammo = ammo - 1;
			CanShoot = false;
			Invoke("Reset", CoolDown);
		}
	}
	void Reset()
	{
		CanShoot = true;
	}
}
