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
    public GameObject handAnchor;
	public GameObject jetpackFire;

	// Use this for initialization
	void Start ()
	{
		rigbod = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		xMovement = (Input.GetAxis("Horizontal"));
		rigbod.velocity = new Vector2(xMovement*xVelocityFactor, rigbod.velocity.y);
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            if (!Input.GetButton("Strafe")) transform.rotation = Quaternion.Euler(0, 0, 0);
            if (canJump == true)//on ground
            {
                GetComponent<AnimateSprite>().animating = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            if (!Input.GetButton("Strafe")) transform.rotation = Quaternion.Euler(0, 180, 0);
            if (canJump == true)//on ground
            {

                GetComponent<AnimateSprite>().animating = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 0f)
        {
            if (canJump == true)//on ground
            {
                GetComponent<AnimateSprite>().animating = false;
            }
        }

		if (canJump == true && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical")>0)
		{
			rigbod.AddForce(new Vector2(0f, jumpPower));
		}
		else if(canJump == false && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical")>0 && jetpackDuration >= 0)
		{
			rigbod.AddForce(new Vector2(0f, jetpackPower));
			jetpackDuration -= Time.deltaTime;
			jetpackFire.GetComponent<SpriteRenderer>().enabled = true;
		}

        if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            GetComponent<PhaseThroughFloor>().DropDown();
        }
		if (Input.GetAxisRaw("Vertical") <= 0 || jetpackDuration <= 0)
		{
			jetpackFire.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	//Enables Jumping
	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.layer == 8) {
			canJump = true;
            GetComponent<AnimateSprite>().staticIndex = 0;
            Vector3 newPos = handAnchor.transform.localPosition;
            newPos.y = -0.264f;
            handAnchor.transform.localPosition = newPos; 
            if (jetpackDuration <= 3) {
				jetpackDuration = 3;
			}
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.layer == 8) {
			canJump = false;
            GetComponent<AnimateSprite>().animating = false;
            GetComponent<AnimateSprite>().staticIndex = 1;
            Vector3 newPos = handAnchor.transform.localPosition;
            newPos.y = 0f;
            handAnchor.transform.localPosition = newPos;
        }
	}
}