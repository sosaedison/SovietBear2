using UnityEngine;
using System.Collections;

public class MoveToNextArea : MonoBehaviour
{
	public GameObject camera;
	private Vector3 currentPos;
	public int direction;
	// Use this for initialization
	void Start ()
	{
		camera = GameObject.Find ("Main Camera");
	}

	void FixedUpdate ()
	{
		//currentPos = player.transform.position;
	}
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.CompareTag("Player"))
        {
            MoveCamera moveCamera = camera.GetComponent<MoveCamera>();
            GameObject adjacentTile = this.GetComponentInParent<LevelTile>().adjacentTiles[direction];

            moveCamera.endPos = adjacentTile.transform.position;
            moveCamera.startPos = camera.transform.position;
            moveCamera.startTime = Time.time;
            if (!adjacentTile.GetComponent<LevelTile>().enemiesSpawned)
            {
                adjacentTile.GetComponent<LevelTile>().SpawnEnemies();
            }
        }
    }


}
