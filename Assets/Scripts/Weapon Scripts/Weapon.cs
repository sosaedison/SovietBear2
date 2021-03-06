﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    public GameObject Bullet;
    public Vector2 bulletOffset;
    public bool equipped = false;
	public int ammo;
	public int maxAmmo;
    public int damage;
    public float bulletSpeed;
    public float coolDown;
    public bool canCollat;
    public bool shouldShoot;
    public bool shouldAutoShoot;
	// Use this for initialization
	void Start () 
	{
		ammo = maxAmmo;
	}

    public void FireBullet(Vector2 direction)
    {
        Vector2 tempBulletOffset = bulletOffset;
        if (direction.x < 0)
        {
            tempBulletOffset.x *= -1.0f;
        }
        GameObject bullet = (GameObject)Instantiate(Bullet, transform.position + (Vector3) tempBulletOffset + Vector3.back * .1f, Quaternion.identity);
        BulletMotion bulletMotion = bullet.GetComponent<BulletMotion>();
        bulletMotion.direction = direction;
        bulletMotion.speed = bulletSpeed;
        bulletMotion.damage = damage;
        bulletMotion.canCollat = canCollat;
        bulletMotion.Activate();
        ammo--;
    }

    protected void Update()
    {
        if (equipped)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shouldShoot = true;
            }
            if (Input.GetButton("Fire1"))
            {
                shouldAutoShoot = true;
            }
        }
    }
	
	protected void FixedUpdate () 
	{
		if (ammo > maxAmmo) ammo = maxAmmo;
        if (transform.root.CompareTag("Player") && !LevelManager.isPaused())
        {
			if (shouldShoot && equipped == true && transform.root.transform.rotation.eulerAngles.y == 0)
            {
				this.Shoot(Vector2.right);
            }
			else if (shouldShoot && equipped == true && transform.root.transform.rotation.eulerAngles.y != 0)
			{
				this.Shoot(Vector2.left);
			}
			else if (shouldAutoShoot && equipped == true && transform.root.rotation.eulerAngles.y == 0)
            {
                this.AutoShoot(Vector2.right);
            }
			else if (shouldAutoShoot && equipped == true && transform.root.transform.rotation.eulerAngles.y != 0)
			{
				this.AutoShoot(Vector2.left);
			}
            shouldShoot = false;
            shouldAutoShoot = false;
        }
	}
	virtual public void Shoot (Vector2 direction)
	{
		//override in subclasses
	}
	virtual public void AutoShoot (Vector2 direction)
	{
        //override in subclasses
    }
}
