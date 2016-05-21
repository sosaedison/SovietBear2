using UnityEngine;
using System.Collections;

public class BulletMotion : MonoBehaviour 
{
	Rigidbody2D rigbody;
    public Vector2 direction;
	// Use this for initialization
	void Start () 
	{
		rigbody = GetComponent<Rigidbody2D>();
			
	}

    public void Activate()
    {
        float angle = Vector2.Angle(Vector2.right, direction.normalized);
        Vector2 force = new Vector2(Mathf.Cos(angle) * 500f, Mathf.Sin(angle) * 500f);

        rigbody.AddForce(force);
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		Destroy(gameObject);
	}

}