using UnityEngine;
using System.Collections;

public class Flamethrowing : Weapon {

	public GameObject prefab;
	public int flameFireCooldown = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	override public void AutoShoot (Vector2 direction)
	{
		if (ammo > 0)
		{
			++flameFireCooldown;
			// Cooldown timer needs to be larger for faster bullets
			if (flameFireCooldown == 7)
			{
                Vector2 flameOffset = bulletOffset;
                Vector2 lowerOffset = new Vector2(1.1f, -0.25f);
                Vector2 middleOffset = new Vector2(0.75f, 0f);
                Vector2 upperOffset = new Vector2(1.1f, 0.25f);
                Vector2 characterVelocity;
                Rigidbody2D rigbod = transform.root.gameObject.GetComponent<Rigidbody2D>();
                if (!rigbod)
                {
                    characterVelocity = Vector2.zero;
                }
                else
                {
                    characterVelocity = rigbod.velocity;
                }
                 
                if (direction.x < 0)
                {
                    flameOffset.x *= -1.0f;
                    lowerOffset.x *= -1.0f;
                    middleOffset.x *= -1.0f;
                    upperOffset.x *= -1.0f;
                    characterVelocity.x *= -1.0f;
                }

                
                GameObject lowerFlame = (GameObject) Instantiate(prefab, (Vector2) transform.position + flameOffset + lowerOffset, Quaternion.identity);
                GameObject middleFlame = (GameObject) Instantiate(prefab, (Vector2) transform.position + flameOffset + middleOffset, Quaternion.identity);
                GameObject upperFlame = (GameObject) Instantiate(prefab, (Vector2) transform.position + flameOffset+ upperOffset, Quaternion.identity);
                GameObject[] flames = { lowerFlame, middleFlame, upperFlame };
                foreach (GameObject flame in flames)
                {
                    flame.GetComponent<FlameScript>().direction = direction;
                    flame.GetComponent<FlameScript>().bulletSpeed = characterVelocity.x + bulletSpeed;
                    flame.transform.rotation = transform.rotation;
                }
                ammo -= 1;
				flameFireCooldown = 0;
			}
		}
	}
}