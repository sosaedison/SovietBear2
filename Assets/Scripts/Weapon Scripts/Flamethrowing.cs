using UnityEngine;
using System.Collections;

public class Flamethrowing : Weapon {

	public GameObject prefab;
	public int ammo = 1200;
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
                Vector2 flameOffset = new Vector2(5.2f, 0.55f);
                Vector2 lowerOffset = new Vector2(1.1f, -0.25f);
                Vector2 middleOffset = new Vector2(0.75f, 0f);
                Vector2 upperOffset = new Vector2(1.1f, 0.25f);
                if (direction.x < 0)
                {
                    flameOffset.x *= -1.0f;
                    lowerOffset.x *= -1.0f;
                    middleOffset.x *= -1.0f;
                    upperOffset.x *= -1.0f;
                }
                
                GameObject lowerFlame = (GameObject) Instantiate(prefab, (Vector2) transform.root.position + flameOffset + lowerOffset, Quaternion.identity);
                GameObject middleFlame = (GameObject) Instantiate(prefab, (Vector2) transform.root.position + flameOffset + middleOffset, Quaternion.identity);
                GameObject upperFlame = (GameObject) Instantiate(prefab, (Vector2) transform.root.position + flameOffset+ upperOffset, Quaternion.identity);
                lowerFlame.GetComponent<FlameScript>().direction = direction;
                middleFlame.GetComponent<FlameScript>().direction = direction;
                upperFlame.GetComponent<FlameScript>().direction = direction;
                ammo -= 3;
				flameFireCooldown = 0;
			}
		}
	}
}