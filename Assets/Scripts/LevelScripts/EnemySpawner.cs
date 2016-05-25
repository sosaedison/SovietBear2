using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemySpawner : MonoBehaviour {
    public GameObject[] enemies;
    public bool spawnPack;


    public void SpawnRandomEnemy()
    {
        if (spawnPack)
        {
            int spawnNumber = Random.Range(2, 4);
            List<BoxCollider2D> alreadySpawned = new List<BoxCollider2D>();
            int index = Random.Range(0, enemies.Length - 1);
            for (int i = 0; i < spawnNumber; i++)
            {
                GameObject newEnemy = (GameObject)Instantiate(enemies[index], transform.position + (Vector3.right * Random.Range(-3, 3)), transform.rotation);
                BoxCollider2D newCollider = newEnemy.GetComponent<BoxCollider2D>();
                foreach (Collider2D collider in alreadySpawned)
                {
                    Physics2D.IgnoreCollision(collider, newCollider, true);
                }
                alreadySpawned.Add(newCollider);
            }
        }
        else
        {
            int index = Random.Range(0, enemies.Length - 1);
            Instantiate(enemies[index], transform.position, transform.rotation);
        }
        
    }
}
