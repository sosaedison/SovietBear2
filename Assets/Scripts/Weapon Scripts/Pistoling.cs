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
	override public void Shoot (Vector2 direction)
	{
		if (ammo > 0 && CanShoot == true)
		{
            Vector2 bulletOffset = new Vector2(2.8f, 0.3f);
            if (direction.x < 0)
            {
                bulletOffset.x *= -1.0f;
            }
            GameObject bullet = (GameObject) Instantiate(Bullet, (Vector2) transform.root.position + bulletOffset, Quaternion.identity);
			BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
			bulletMotion.direction = direction;
			bulletMotion.speed = 500f;
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
