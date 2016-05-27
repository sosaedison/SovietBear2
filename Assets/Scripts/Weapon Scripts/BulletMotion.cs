using UnityEngine;
using System.Collections;

public class BulletMotion : MonoBehaviour 
{
	Rigidbody2D rigbod;
    public Vector2 direction;
	public float speed;
	public bool canCollat = false;
    public int damage;
	private int collat = 3;

    bool paused;
    Vector2 velocity;
	// Use this for initialization
	void Start () 
	{
		rigbod = GetComponent<Rigidbody2D>();
			
	}

    public void Activate()
    {
 		if (rigbod == null) {
			rigbod = GetComponent<Rigidbody2D>();
		}
        float angle = Vector2.Angle(direction.normalized, Vector2.right);
        if (angle > 45 && angle < 135) Destroy(gameObject);
        float sign = 1.0f;
        if (direction.y < 0) sign = -1.0f;
        angle *= sign;
		Vector2 velocity = new Vector2(Mathf.Cos(angle / 180 * Mathf.PI) * speed, Mathf.Sin(angle / 180 * Mathf.PI) * speed);

        rigbod.velocity = velocity;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
	
	void OnCollisionEnter2D (Collision2D collision)
	{
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.current -= damage;
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
    void OnPause()
    {
        paused = true;
        velocity = rigbod.velocity;
        rigbod.velocity = Vector2.zero;
        rigbod.isKinematic = true;
    }

    void OnUnpause()
    {
        rigbod.isKinematic = false;
        rigbod.velocity = velocity;
        paused = false;
    }

    void OnEnable()
    {
        LevelManager.OnPause += OnPause;
        LevelManager.OnUnpause += OnUnpause;
    }

    void OnDisable()
    {
        LevelManager.OnPause -= OnPause;
        LevelManager.OnUnpause -= OnUnpause;
    }

}