using UnityEngine;
using System.Collections;

public class MoveToNextArea : MonoBehaviour
{
	public GameObject camera;
	private GameObject player;
	private BoxCollider2D playerCol;
	private Vector3 currentPos;
	public int direction;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("player"); 
		camera = GameObject.Find ("Main Camera");
		playerCol = GameObject.Find ("player").GetComponent<BoxCollider2D> ();
	}

	void FixedUpdate ()
	{
		//currentPos = player.transform.position;
	}
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		MoveCamera moveCamera = camera.GetComponent<MoveCamera> ();
		moveCamera.endPos = this.GetComponentInParent<LevelTile> ().adjacentTiles [direction].transform.position;
		moveCamera.startPos = camera.transform.position;
		moveCamera.startTime = Time.time;
			
	}


}
