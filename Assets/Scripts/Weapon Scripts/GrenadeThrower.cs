using UnityEngine;
using System.Collections;

public class GrenadeThrower : Weapon {

    public GameObject prefab;
    Grenade grenade;

	// Use this for initialization
	void Start() {
        SpawnGrenade();
	}

    void SpawnGrenade()
    {
        GameObject newGrenade = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
        Physics2D.IgnoreCollision(transform.root.GetComponent<BoxCollider2D>(), newGrenade.GetComponent<BoxCollider2D>(), true);
        grenade = newGrenade.GetComponent<Grenade>();
        grenade.transform.parent = transform;
    }

    override public void Shoot(Vector2 direction)
    {
        if (grenade != null)
        {
            Vector2 velocity = new Vector2(0, 0);
            float angle = Vector2.Angle(direction.normalized, Vector2.right);
            float sign = 1.0f;
            if (direction.y < 0) sign = -1.0f;
            angle *= sign;
            float gravity = -Physics2D.gravity.y * grenade.GetComponent<Rigidbody2D>().gravityScale;
            if (angle > 20 && angle < 160)
            {
                float Vy = Mathf.Sqrt(2 * gravity * Mathf.Abs(direction.y));
                float Vx = direction.x * gravity / Vy;
                velocity = new Vector2(Vx, Vy);

            }
            else
            {
                float Vy = Mathf.Sqrt(gravity * Mathf.Abs(direction.x));
                float Vx = direction.x * gravity / (2 * Vy);
                velocity = new Vector2(Vx, Vy);
            }
            grenade.transform.parent = null;
            grenade.Throw(this, velocity);
            grenade = null;
            ammo--;
        }
        
    }

    public void Reset()
    {
        if (ammo > 0)
        {
            SpawnGrenade();
        }
        
    }
}
