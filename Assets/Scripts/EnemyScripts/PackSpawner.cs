using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PackSpawner : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {
        int spawnNumber = Random.Range(2, 4);
        List<BoxCollider2D> alreadySpawned = new List<BoxCollider2D>();
        for (int i = 0; i < spawnNumber; i++)
        {
            GameObject newEnemy = (GameObject)Instantiate(prefab, transform.position + (Vector3.right * Random.Range(-3, 3)), transform.rotation);
            BoxCollider2D newCollider = newEnemy.GetComponent<BoxCollider2D>();
            foreach (Collider2D collider in alreadySpawned)
            {
                Physics2D.IgnoreCollision(collider, newCollider, true);
            }
            alreadySpawned.Add(newCollider);
        }
        Destroy(gameObject);
    }
	
}
