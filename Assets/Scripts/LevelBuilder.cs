using UnityEngine;
using System.Collections;
using random = UnityEngine.Random;

public class LevelBuilder : MonoBehaviour {
    GameObject[][] map;

    public GameObject[] tiles;
    public GameObject[] deadEnds;

    int tilesSinceDeadEnd = 0;
    int tilesGenerated = 0;

    bool CheckCompatibility(GameObject tile1, int direction, GameObject tile2)
    {
        int oppositeDirection = direction - 2;
        if (oppositeDirection < 0)
        {
            oppositeDirection += 4;
        }

        return tile1.GetComponent<LevelTile>().adjacentTiles[direction].CompareTag(tile2.GetComponent<LevelTile>().adjacentTiles[oppositeDirection].tag);

    }

    void GenerateAdjacentTiles(GameObject tile)
    {
        GameObject[] tilesToGenerate = tile.GetComponent<LevelTile>().adjacentTiles;

        for (int i = 0; i < tilesToGenerate.Length; i++)
        {
            if (tilesToGenerate[i].CompareTag("Placeholder"))
            {
                Vector2 newCoordinates = tile.GetComponent<LevelTile>().coordinates;
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
                GameObject potentialTile = null;
                GameObject[] testingTiles = { map[(int)newCoordinates.x - 1][(int)newCoordinates.y],
                                              map[(int)newCoordinates.x][(int)newCoordinates.y + 1],
                                              map[(int)newCoordinates.x + 1][(int)newCoordinates.y],
                                              map[(int)newCoordinates.x][(int)newCoordinates.y - 1] };
                while (!tileGenerated)
                {
                    int index = Random.Range(0, tiles.Length);
                    potentialTile = tiles[index];
                    tileGenerated = true;
                    //check compatiblity

                    int minY = potentialTile.GetComponent<LevelTile>().minY;
                    int maxY = potentialTile.GetComponent<LevelTile>().maxY;

                    tileGenerated = newCoordinates.y >= minY && minY >= 0;
                    tileGenerated = newCoordinates.y <= maxY && maxY >= 0; 

                    if (potentialTile.GetComponent<LevelTile>().isDeadEnd)
                    {
                        tileGenerated = tilesSinceDeadEnd > 5;
                    }

                    if (!tileGenerated) continue;
                    for (int j = 0; i <= testingTiles.Length; i++)
                    {
                        if (testingTiles[j] != null)
                        {
                            tileGenerated = CheckCompatibility(potentialTile, j, testingTiles[j]);
                            if (tileGenerated)
                            {
                                potentialTile.GetComponent<LevelTile>().adjacentTiles[j] = testingTiles[j];
                            }
                        }
                    }

                }
                potentialTile.GetComponent<LevelTile>().coordinates = newCoordinates;
                tile.GetComponent<LevelTile>().adjacentTiles[i] = potentialTile;
                map[(int)newCoordinates.x][(int)newCoordinates.y] = potentialTile;
                tilesGenerated++;
                if (potentialTile.GetComponent<LevelTile>().isDeadEnd)
                {
                    tilesSinceDeadEnd = 0;
                }
                else
                {
                    tilesSinceDeadEnd++;
                }
            }
        }
    }

    void GenerateLevel()
    {

    }
}
