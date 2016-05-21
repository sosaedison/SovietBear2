using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject[] enemies;

    public void SpawnRandomEnemy()
    {
        int index = Random.Range(0, enemies.Length - 1);
        Instantiate(enemies[index], transform.position, transform.rotation);
    }
}
