﻿using UnityEngine;
using System.Collections;
using random = UnityEngine.Random;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelBuilder : MonoBehaviour
{
    public delegate void FinishedGeneration();
    public static event FinishedGeneration OnFinishedGeneration;
    public static event FinishedGeneration OnFailedGeneration;

	GameObject[,] map;
	List<GameObject> potentialBossRooms;
    [System.Serializable]
    public class TileSet
    {
        public GameObject[] tiles;
    }
	public TileSet[] tileSets;
	//Array of all tiles that can be generated (prefabs)
	public GameObject starterTile;

    [System.NonSerialized]
    public bool doneGenerating;

	int tilesSinceDeadEnd = 0;
	int tilesGenerated = 0;
	bool deadEndMode = false;
    int attempts = 0;

	bool CheckCompatibility (GameObject tile1, int direction, GameObject tile2)
	{
		int oppositeDirection = direction - 2;
		if (oppositeDirection < 0) {
			oppositeDirection += 4;
		}
		string tile1tag = tile1.GetComponent<LevelTile> ().adjacentTiles [direction].tag;
		string tile2tag = tile2.GetComponent<LevelTile> ().adjacentTiles [oppositeDirection].tag;

		return tile1tag == tile2tag;
		//return tile1.GetComponent<LevelTile>().adjacentTiles[direction].CompareTag(tile2.GetComponent<LevelTile>().adjacentTiles[oppositeDirection].tag);

	}

	GameObject[] GenerateAdjacentTiles (GameObject tile)
	{
		GameObject[] tilesToGenerate = tile.GetComponent<LevelTile> ().adjacentTiles;
		List<GameObject> generatedTiles = new List<GameObject> ();

		for (int i = 0; i < tilesToGenerate.Length; i++) {
			if (tilesToGenerate [i].CompareTag ("Placeholder")) { // only generate on placeholders
				Vector2 newCoords = tile.GetComponent<LevelTile> ().coordinates;
				switch (i) {
				case 0:
					newCoords.x -= 1;
					break;
				case 1:
					newCoords.y += 1;
					break;
				case 2:
					newCoords.x += 1;
					break;
				case 3:
					newCoords.y -= 1;
					break;
				default:
					newCoords = Vector2.zero;
					break;
				}
				bool tileGenerated = false;
                GameObject potentialTile = null;
                GameObject tile0 = map[(int)newCoords.x - 1, (int)newCoords.y];
                GameObject tile1 = map[(int)newCoords.x, (int)newCoords.y + 1];
                GameObject tile2 = map[(int)newCoords.x + 1, (int)newCoords.y];
                GameObject tile3 = map[(int)newCoords.x, (int)newCoords.y - 1];
                GameObject[] testingTiles = { tile0,
					tile1,
					tile2,
					tile3
				};
				while (!tileGenerated) {
                    attempts++;
                    if (attempts > 1000)
                    {
                        return null;
                    }
					int index = Random.Range (0, tileSets[i].tiles.Length);
					float newX = (newCoords.x - 25f) * 98.6f;
					float newY = (newCoords.y - 25f) * 48.96f;
					potentialTile = (GameObject)Instantiate (tileSets[i].tiles [index], new Vector3 (newX, newY, 0.3f), Quaternion.Euler (270, 0, 0));
                    potentialTile.transform.parent = transform;
                    tileGenerated = true;
                    
					//check compatiblity
					int minY = potentialTile.GetComponent<LevelTile> ().minY;
					int maxY = potentialTile.GetComponent<LevelTile> ().maxY;

					if (minY >= 0) {
                        if (newCoords.y < minY)
                            tileGenerated = false;
                        
					}

					if (maxY >= 0) {
                        if (newCoords.y > maxY)
                            tileGenerated = false;
                    }

					if (potentialTile.GetComponent<LevelTile> ().isDeadEnd && !deadEndMode) {
						if (tilesSinceDeadEnd <= 5)
                            tileGenerated = false; //attempt to prevent short levels
							
					}

					if (!tileGenerated) {
						Destroy (potentialTile);
						continue;
					} //save some time
					for (int j = 0; j < testingTiles.Length; j++) {
						if (testingTiles [j] != null) {
                            if (!CheckCompatibility(potentialTile, j, testingTiles[j]))
                                tileGenerated = false;
								
							if (tileGenerated) {
								potentialTile.GetComponent<LevelTile> ().adjacentTiles [j] = testingTiles [j];
							} else {
								break;
							}
						}
					}
					if (deadEndMode) { //prevent open ended rooms when level is too large
						GameObject[] connectedTiles = potentialTile.GetComponent<LevelTile> ().adjacentTiles;
						for (int k = 0; k < connectedTiles.Length; k++) {
							if (connectedTiles [k].CompareTag ("Placeholder"))
								tileGenerated = false;
						}
					}

					if (!tileGenerated)
						Destroy (potentialTile);

				}
                attempts = 0;
				potentialTile.GetComponent<LevelTile> ().coordinates = newCoords;
				for (int l = 0; l < testingTiles.Length; l++) {
					if (testingTiles [l] != null) {
						int oppositeDirection = l - 2;
						if (oppositeDirection < 0) {
							oppositeDirection += 4;
						}
						testingTiles [l].GetComponent<LevelTile> ().adjacentTiles [oppositeDirection] = potentialTile;
					}
                    
				}
				map [(int)newCoords.x, (int)newCoords.y] = potentialTile;
				tilesGenerated++;
				if (potentialTile.GetComponent<LevelTile> ().isDeadEnd) { //don't bother generating around dead ends
					tilesSinceDeadEnd = 0;
					potentialBossRooms.Add (potentialTile);
				} else {
					tilesSinceDeadEnd++;
					generatedTiles.Add (potentialTile);
				}
			}
		}
		return generatedTiles.ToArray ();
	}

	IEnumerator GenerateNewLevel (GameObject startingTile)
	{
		tilesGenerated = 0;
		tilesSinceDeadEnd = 0;
		deadEndMode = false;
		map = new GameObject[50, 50];
		potentialBossRooms = new List<GameObject> ();
		Vector2 startingCoords = startingTile.GetComponent<LevelTile> ().coordinates;
		map [(int)startingCoords.x, (int)startingCoords.y] = startingTile;
		List<GameObject> generationQueue = new List<GameObject> ();
		generationQueue.Add (startingTile);
        
		while (generationQueue.Count > 0) {
			deadEndMode = tilesGenerated > 20;
			GameObject[] newTiles = GenerateAdjacentTiles (generationQueue [0]);
            if (newTiles == null)
            {
                if (OnFailedGeneration != null) 
                    OnFailedGeneration();
                break;
            }
			generationQueue.AddRange (newTiles.ToList ());
			generationQueue.RemoveAt (0);
            yield return null;
		}
        if (potentialBossRooms.Count == 0)
        {
            if (OnFailedGeneration != null)
                OnFailedGeneration();
        }
        else
        {
            int bossRoom = Random.Range(0, potentialBossRooms.Count);
            potentialBossRooms[bossRoom].GetComponent<LevelTile>().isBossRoom = true;
            if (OnFinishedGeneration != null)
                OnFinishedGeneration();
        }
	}

	void printMap (GameObject[,] map)
	{
		for (int i = 0; i < map.GetLength (1); i++) {
			string row = "";
			for (int j = 0; j < map.GetLength (0); j++) {
				if (map [j, i] == null) {
					row += "  -  ";
				} else {
					row += j.ToString ();
					row += ".";
					row += map [j, i].name;
					row += " ";
				}

			}
			Debug.Log (row);
		}
	}

    void Awake()
    {
        GameObject firstTile = (GameObject)Instantiate(starterTile, Vector3.zero + Vector3.forward * .3f, Quaternion.Euler(270, 0, 0));
        firstTile.transform.parent = transform;
        StartCoroutine(GenerateNewLevel(firstTile));
		//printMap(newLevel);
	}
}
