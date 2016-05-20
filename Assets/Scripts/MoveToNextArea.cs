using UnityEngine;
using System.Collections;

public class MoveToNextArea : MonoBehaviour
{
	public GameObject camera;
	private GameObject camHere;
	public BoxCollider2D nextArea;
	public BoxCollider2D comeBack;
	private GameObject player;
	private BoxCollider2D playerCol;
	private Vector2 currentPos;
	private Vector2 endPos;
	// Use this for initialization
	void Start ()
	{
<<<<<<< HEAD
		//endPos = camHere.transform.position;
		//playerCol = GameObject.Find ("player").GetComponent<BoxCollider2D> ();
=======
		camHere = GameObject.FindWithTag ("CamHere"); 
		player = GameObject.Find ("player"); 
		endPos = camHere.transform.position;
		playerCol = GameObject.Find ("player").GetComponent<BoxCollider2D> ();
>>>>>>> movement
		Physics2D.IgnoreCollision (comeBack, playerCol, true);
	}

	void FixedUpdate ()
	{
		//currentPos = player.transform.position;
	}
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "player") {
			player.GetComponent<PlayerMovement> ().enabled = false;
<<<<<<< HEAD
			//camera.transform.position = Vector2.Lerp (endPos, currentPos, 0.1F * Time.deltaTime);
=======
		}
		if (Vector2.Distance (player.transform.position, camHere.transform.position) <= 53) {
			camera.transform.position = Vector2.Lerp (endPos, currentPos, 0.1F * Time.deltaTime);
>>>>>>> movement
		}

			
	}

	void OnTriggerExit2D (Collider2D other)
	{
		player.GetComponent<PlayerMovement> ().enabled = true;
		Physics2D.IgnoreCollision (nextArea, playerCol, true);
		Physics2D.IgnoreCollision (comeBack, playerCol, false);

	}
}
