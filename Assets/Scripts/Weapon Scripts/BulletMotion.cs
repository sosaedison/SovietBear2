using UnityEngine;
using System.Collections;

public class BulletMotion : MonoBehaviour 
{
	Rigidbody2D rigbody;
    public Vector2 direction;
	public float speed;
	public bool canCollat = false;
	private int collat = 3;
	// Use this for initialization
	void Start () 
	{
		rigbody = GetComponent<Rigidbody2D>();
			
	}

    public void Activate()
    {
 		if (rigbody == null) {
			rigbody = GetComponent<Rigidbody2D>();
		}
        float angle = Vector2.Angle(direction.normalized, Vector2.right);
        if (angle > 45 && angle < 135) Destroy(gameObject);
        float sign = 1.0f;
        if (direction.y < 0) sign = -1.0f;
        angle *= sign;
		Vector2 velocity = new Vector2(Mathf.Cos(angle / 180 * Mathf.PI) * speed, Mathf.Sin(angle / 180 * Mathf.PI) * speed);

        rigbody.velocity = velocity;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
	
	void OnCollisionEnter2D (Collision2D collision)
	{
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.current -= 4;
        }
        if (canCollat) 
		{
            collat--;
            if (collat < 0)
            {
                Destroy(gameObject);
            }
		}
		else 
		{
			Destroy(gameObject);
		}

	}

}