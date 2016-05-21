using UnityEngine;
using System.Collections;

public class Pistoling : Weapon {
	public GameObject Bullet;
	public int ammo = 100;
	bool CanShoot = true;
	float CoolDown = .35f;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void Shoot (Vector2 direction)
	{
		if (ammo > 0 && CanShoot == true)
		{
            GameObject bullet = (GameObject) Instantiate(Bullet, new Vector2(transform.position.x + 1.0f, transform.position.y), Quaternion.identity);
            bullet.GetComponent<BulletMotion>().direction = direction;
            bullet.GetComponent<BulletMotion>().Activate();
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
