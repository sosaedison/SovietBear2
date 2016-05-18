using UnityEngine;
using System.Collections;
using random = UnityEngine.Random;

public class LevelBuilder : MonoBehaviour {
    GameObject[][] map;

    public GameObject[] tiles;
    public GameObject[] deadEnds;

    int tilesSinceDeadEnd = 0;
    int tilesGenerated = 0;

    bool CheckCompatibility(int direction, GameObject tile)
    {
        int oppositeDirection = direction - 2;
        if (oppositeDirection < 0)
        {
            oppositeDirection += 4;
        }

        return !tile.GetComponent<LevelTile>().adjacentTiles[oppositeDirection].CompareTag("Blocker");
    }

    void GenerateAdjacentTiles(GameObject tile, Vector2 tileCoordinates)
    {
        GameObject[] tilesToGenerate = tile.GetComponent<LevelTile>().adjacentTiles;

        for (int i = 0; i < tilesToGenerate.Length; i++)
        {
            if (tilesToGenerate[i].CompareTag("Placeholder"))
            {
                Vector2 newCoordinates = tileCoordinates;
                switch (i)
                {
                    case 0:
                        newCoordinates.x -= 1;
                        break;
                    case 1:
                        newCoordinates.y += 1;
                        break;
                    case 2:
                        newCoordinates.x += 1;
                        break;
                    case 3:
                        newCoordinates.y -= 1;
                        break;
                    default:
                        newCoordinates = Vector2.zero;
                        break;
                }
                bool tileGenerated = false;
                while (!tileGenerated)
                {
                    int index = Random.Range(0, tiles.Length);
                    GameObject potentialTile = tiles[index];
                    //check compatiblity

                }
            }
        }
    }

    void GenerateLevel()
    {

    }
}
