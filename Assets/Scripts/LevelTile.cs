using UnityEngine;
using System.Collections;

public class LevelTile : MonoBehaviour {

    public GameObject[] adjacentTiles; //0 left, 1 up, 2 right, 3 down
    public int minY = -1; //negative for no min/max
    public int maxY = -1;
    public bool isDeadEnd = false;
    public bool isBossRoom = false;
    public Vector2 coordinates = Vector2.zero;

    public GameObject[] enemySpawners;
    public bool enemiesSpawned;

    public void SpawnEnemies()
    {
        foreach (GameObject spawner in enemySpawners)
        {
            spawner.GetComponent<EnemySpawner>().SpawnRandomEnemy();
            Destroy(spawner);
        }
        enemiesSpawned = true;
        Debug.Log("Spawned");
    }
}
