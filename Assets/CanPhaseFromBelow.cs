using UnityEngine;
using System.Collections;

public class CanPhaseFromBelow : MonoBehaviour
{
	private BoxCollider2D playerCollider;
	public BoxCollider2D groundCollider;
	public BoxCollider2D groundTrigger;
	// Use this for initialization
	void Start ()
	{
		playerCollider = GameObject.Find ("player").GetComponent<BoxCollider2D> ();
		Physics2D.IgnoreCollision (groundCollider, groundTrigger, true);


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "player") {
			Physics2D.IgnoreCollision (groundCollider, playerCollider, true);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "player") {
			Physics2D.IgnoreCollision (groundCollider, playerCollider, false);
		}
	}
	
	// Update is called once per frame

}
