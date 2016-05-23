using UnityEngine;
using System.Collections;

public class Pistoling : Weapon {
	public GameObject Bullet;
	public int ammo = 100;
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
            Vector2 bulletOffset = new Vector2(0.84f, 0.34f);
            if (direction.x < 0)
            {
                bulletOffset.x *= -1.0f;
            }
            GameObject bullet = (GameObject) Instantiate(Bullet, (Vector2) transform.position + bulletOffset, Quaternion.identity);
			BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
			bulletMotion.direction = direction;
			bulletMotion.speed = 30;
			bulletMotion.Activate();
            ammo--;
            nextShotTime = Time.time + coolDown;
		}
	}
}
