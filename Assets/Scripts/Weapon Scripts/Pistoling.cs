using UnityEngine;
using System.Collections;

public class Pistoling : Weapon {
	public GameObject Bullet;
	public float coolDown = .35f;
    float nextShotTime = 0f;
	void Start () 
	{
		
	}
	
	// Update is called once per frame

	override public void Shoot (Vector2 direction)
	{
        if (ammo > 0 && Time.time >= nextShotTime)
		{
            Vector2 tempBulletOffset = bulletOffset;
            if (direction.x < 0)
            {
                tempBulletOffset.x *= -1.0f;
            }
            GameObject bullet = (GameObject) Instantiate(Bullet, (Vector2) transform.position + tempBulletOffset, Quaternion.identity);
			BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
			bulletMotion.direction = direction;
			bulletMotion.speed = 30;
			bulletMotion.Activate();
            ammo--;
            nextShotTime = Time.time + coolDown;
		}
	}
}
