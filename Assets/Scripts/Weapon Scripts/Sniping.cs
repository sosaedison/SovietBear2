using UnityEngine;
using System.Collections;

public class Sniping : Weapon {

	public GameObject prefab;
	public int ammo = 10;
	bool CanShoot = true;
	float CoolDown = 1.2f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	override public void Shoot (Vector2 direction)
	{
		if(ammo > 0 && CanShoot == true)
		{
            Vector2 bulletOffset = new Vector2(3.55f, 0.97f);
            if (direction.x < 0)
            {
                bulletOffset.x *= -1.0f;
            }
            GameObject bullet = (GameObject) Instantiate(prefab, (Vector2)transform.position + bulletOffset, Quaternion.identity);
			BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
			bulletMotion.direction = direction;
			bulletMotion.speed = 54f;
			bulletMotion.canCollat = true;
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
