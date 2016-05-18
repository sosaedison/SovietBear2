using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{

	public int yVelocityFactor = 500;
	public int xVelocityFactor = 10;
	float xMovement = 0.0f;
	float yMovement = 0.0f;
	Rigidbody2D rigbod;
	public bool canJump = false;
	int JumpPower = 800;

	// Use this for initialization
	void Start ()
	{
		rigbod = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		yMovement = (Input.GetAxis ("Vertical"));
		xMovement = (Input.GetAxis ("Horizontal"));
		rigbod.velocity = new Vector2 (xMovement * xVelocityFactor, rigbod.velocity.y);

		if (canJump == true && Input.GetButton ("Jump")) {
			rigbod.AddForce (new Vector2 (0f, JumpPower));
		}
	}

	//Enables Jumping
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == 8) {
			canJump = true;
			Debug.Log ("should be able to jump");
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.layer == 8) {
			canJump = false;
		}
	}
}
