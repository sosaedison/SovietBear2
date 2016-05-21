using UnityEngine;
using System.Collections;

public class SniperRoundMotion : MonoBehaviour {

	int Collat = 0;
	Rigidbody2D rigbody;
	// Use this for initialization
	void Start () 
	{
		rigbody = GetComponent<Rigidbody2D>();
		rigbody.AddForce(new Vector2(900f, 0f));	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Collat == 3)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == "Nazi" && Collat <= 3)
		{
			++Collat;
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag != "Nazi")
		{
			Destroy(gameObject);
		}
	}
}
