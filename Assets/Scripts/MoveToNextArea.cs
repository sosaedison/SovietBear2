using UnityEngine;
using System.Collections;

public class MoveToNextArea : MonoBehaviour
{
	public GameObject camera;
	public GameObject camHere;
	public BoxCollider2D nextArea;
	public GameObject player;
	private Vector2 currentPos;
	private Vector2 endPos;
	// Use this for initialization
	void Start ()
	{
		endPos = camHere.transform.position; 
	}

	void FixedUpdate ()
	{
		currentPos = player.transform.position;
	}
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "player") {
			player.GetComponent<PlayerMovement> ().enabled = false;
			camera.transform.position = Vector2.Lerp (endPos, currentPos, 0.1F * Time.deltaTime);
		}
	
	}

	void OnTriggerExit2D (Collider2D other)
	{
		player.GetComponent<PlayerMovement> ().enabled = true;
	}
}
