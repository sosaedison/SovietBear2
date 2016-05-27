using UnityEngine;
using System.Collections;


public class EnemySpawner : MonoBehaviour {
    [System.Serializable]
    public class enemySet
    {
        public GameObject[] enemies;
    }
    public enemySet[] enemies;


    public void SpawnRandomEnemy()
    {
        int levelIndex = FindObjectOfType<LevelManager>().levelNumber;
        int index = Random.Range(0, enemies[levelIndex].enemies.Length);
        Instantiate(enemies[levelIndex].enemies[index], transform.position, transform.rotation);
    }
}
