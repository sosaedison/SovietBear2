using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	//	public int yVelocityFactor = 500;
	public int xVelocityFactor = 5;
	float xMovement = 0.0f;
	Rigidbody2D rigbod;
	public bool canJump = true;
	int jumpPower = 30;
	int jetpackPower = 5;
	float jetpackDuration = 3;

	// Use this for initialization
	void Start ()
	{
		rigbod = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		jetpackDuration -= Time.deltaTime;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		xMovement = (Input.GetAxis ("Horizontal"));
		rigbod.velocity = new Vector2 (xMovement * xVelocityFactor, rigbod.velocity.y);

		if (canJump == true && Input.GetKey (KeyCode.W)) {
			rigbod.AddForce (new Vector2 (0f, jumpPower));
		} else if (canJump == false && Input.GetKey (KeyCode.W) && jetpackDuration >= 0) {
			rigbod.AddForce (new Vector2 (0f, jetpackPower));
			Debug.Log ("Jetpacking");
		}
	}

	//Enables Jumping
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == 8) {
			canJump = true;
			rigbod.velocity = new Vector2 (0, 0);
			if (jetpackDuration <= 3) {
				jetpackDuration = 3;
			}
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.layer == 8) {
			canJump = false;
		}
	}
}