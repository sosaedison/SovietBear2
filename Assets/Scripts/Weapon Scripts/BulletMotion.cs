using UnityEngine;
using System.Collections;

public class BulletMotion : MonoBehaviour 
{
	Rigidbody2D rigbody;
	// Use this for initialization
	void Start () 
	{
		rigbody = GetComponent<Rigidbody2D>();
		rigbody.AddForce(new Vector2(500f, 0f));	
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