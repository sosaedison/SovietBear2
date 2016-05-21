using UnityEngine;
using System.Collections;

public class BulletMotion : MonoBehaviour 
{
	Rigidbody2D rigbody;
    public Vector2 direction;
	public float speed;
	public bool canCollat = false;
	private int collat;
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
        float angle = Vector2.Angle(Vector2.right, direction.normalized);
		Vector2 force = new Vector2(Mathf.Cos(angle / 180 * Mathf.PI) * speed, Mathf.Sin(angle / 180 * Mathf.PI) * speed);

        rigbody.AddForce(force);
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (canCollat) 
		{
			if(collision.gameObject.tag == "Nazi" && collat <= 3)
			{
				++collat;
				if (collat == 3)
				{
					Destroy(gameObject);
				}
				Destroy(collision.gameObject);
			}
			if (collision.gameObject.tag != "Nazi")
			{
				Destroy(gameObject);
			}
		}
		else 
		{
			if (collision.gameObject.tag == "Nazi")
			{
				Destroy(collision.gameObject);
			}
			Destroy(gameObject);
		}

	}

}