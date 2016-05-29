using UnityEngine;
using System.Collections;

public class MoveToNextArea : MonoBehaviour
{
	public GameObject cam;
	private Vector3 currentPos;
	public int direction;
	// Use this for initialization
	void Start ()
	{
		cam = GameObject.Find ("Main Camera");
	}

	void FixedUpdate ()
	{
		//currentPos = player.transform.position;
	}
	// Update is called once per frame
	void OnTriggerExit2D (Collider2D other)
	{
        if (other.CompareTag("Player"))
        {
            MoveCamera moveCamera = cam.GetComponent<MoveCamera>();
            GameObject adjacentTile = this.GetComponentInParent<LevelTile>().adjacentTiles[direction];

            moveCamera.endPos = adjacentTile.transform.position;
            if (!adjacentTile.GetComponent<LevelTile>().enemiesSpawned)
            {
                adjacentTile.GetComponent<LevelTile>().SpawnEnemies();
            }
        }
    }


}
