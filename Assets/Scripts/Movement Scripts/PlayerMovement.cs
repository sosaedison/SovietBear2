using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public int xVelocityFactor = 5;
	float xMovement = 0.0f;
	Rigidbody2D rigbod;
	public bool canJump = true;
	public int jumpPower = 800;
	public int jetpackPower = 16;
	float jetpackDuration = 9;
	Transform YRotation;
	bool LookingRight = true;

	// Use this for initialization
	void Start ()
	{
		rigbod = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if (canJump == false) {
			jetpackDuration -= Time.deltaTime;
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		xMovement = (Input.GetAxis("Horizontal"));
		rigbod.velocity = new Vector2(xMovement*xVelocityFactor, rigbod.velocity.y);
		if (Input.GetAxisRaw("Horizontal")>0f)
		{
			transform.rotation = Quaternion.Euler(0,0,0);
			LookingRight = true;
		}
		else if (Input.GetAxisRaw("Horizontal")<0f)
		{
			transform.rotation = Quaternion.Euler(0,180,0);
			LookingRight = false;
		}

		if (canJump == true && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical")>0)
		{
			rigbod.AddForce(new Vector2(0f, jumpPower));
		}
		else if(canJump == false && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical")>0 && jetpackDuration >= 0)
		{
			rigbod.AddForce(new Vector2(0f, jetpackPower));
		}
	}

	//Enables Jumping
	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.layer == 8) {
			canJump = true;
			rigbod.velocity = new Vector2 (0, 0);
			if (jetpackDuration <= 3) {
				jetpackDuration = 3;
			}
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.layer == 8) {
			canJump = false;
		}
	}
}