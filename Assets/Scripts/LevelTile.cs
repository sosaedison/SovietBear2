using UnityEngine;
using System.Collections;

public class LevelTile : MonoBehaviour {

    public GameObject[] adjacentTiles; //0 left, 1 up, 2 right, 3 down
    public int minY = -1; //negative for no min/max
    public int maxY = -1;
    public bool isDeadEnd = false;
    public Vector2 coordinates = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
