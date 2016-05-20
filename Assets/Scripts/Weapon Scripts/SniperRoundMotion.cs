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

	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == "Nazi")
		{
			++Collat;
		}
		else if (Collat >= 3 || collision.gameObject.tag != "Nazi")
		{
			Destroy(gameObject);
		}
	}
}
