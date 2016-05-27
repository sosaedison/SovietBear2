using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public int xVelocityFactor = 5;
	float xMovement = 0.0f;
	Rigidbody2D rigbod;
    AnimateSprite sprite;
    BoxCollider2D collider;
	public bool canJump = true;
    public bool crouching = false;
	public int jumpPower = 800;
	public int jetpackPower = 16;
	public float jetpackDuration = 2;
	Transform YRotation;
    public GameObject handAnchor;
	public GameObject jetpackFire;

    bool paused;
    Vector2 velocity;

	// Use this for initialization
	void Start ()
	{
		rigbod = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<AnimateSprite>();
        collider = GetComponent<BoxCollider2D>();
	}

	void Update()
    {
        if (!paused)
        {
            xMovement = (Input.GetAxis("Horizontal"));
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                if (!Input.GetButton("Strafe")) transform.rotation = Quaternion.Euler(0, 0, 0);
                if (canJump == true)//on ground
                    sprite.animating = true;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                if (!Input.GetButton("Strafe")) transform.rotation = Quaternion.Euler(0, 180, 0);
                if (canJump == true)//on ground
                    sprite.animating = true;
            }
            else if (Input.GetAxisRaw("Horizontal") == 0f)
            {
                if (canJump == true)//on ground
                    sprite.animating = false;
            }

            if (!canJump && !crouching)
            {
                sprite.animating = false;
                sprite.staticIndex = 1;
                Vector3 newPos = handAnchor.transform.localPosition;
                newPos.y = 0f;
                handAnchor.transform.localPosition = newPos;
            }
            else if (Input.GetButton("Crouch"))
            {
                crouching = true;
                xMovement = 0;
                sprite.staticIndex = 2;
                sprite.animating = false;
                Vector3 newPos = handAnchor.transform.localPosition;
                newPos.y = -0.68f;
                handAnchor.transform.localPosition = newPos;
                collider.offset = new Vector2(0.125f, -0.04f);
                collider.size = new Vector2(3.95f, 4.8f);
            }
            else
            {
                sprite.staticIndex = 0;
                crouching = false;
                Vector3 newPos = handAnchor.transform.localPosition;
                newPos.y = -0.264f;
                handAnchor.transform.localPosition = newPos;
                collider.offset = new Vector2(-0.09f, -0.07f);
                collider.size = new Vector2(3.5f, 5.5f);
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
    }

	void FixedUpdate ()
	{
        if (!paused)
        {
            rigbod.velocity = new Vector2(xMovement * xVelocityFactor, rigbod.velocity.y);

            if (canJump == true && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0)
            {
                rigbod.AddForce(new Vector2(0f, jumpPower));
            }
            else if (canJump == false && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0 && jetpackDuration >= 0)
            {
                rigbod.AddForce(new Vector2(0f, jetpackPower));
                jetpackDuration -= Time.deltaTime;
                jetpackFire.GetComponent<SpriteRenderer>().enabled = true;
            }

           
        }
	}

	//Enables Jumping
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.layer == 8 && !paused) {
			canJump = true;
            
            if (jetpackDuration <= 3) {
				jetpackDuration = 3;
			}
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.layer == 8 && !paused)
			canJump = false;
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