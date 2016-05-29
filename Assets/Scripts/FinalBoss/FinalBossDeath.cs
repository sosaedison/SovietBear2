using UnityEngine;
using System.Collections;

public class FinalBossDeath : MonoBehaviour {

    public GameObject explosionPrefab;
    float startTime;


    void Start () {
        startTime = Time.time;
	}


    void Update() //this is terrible and i know it
    {
        float elapsedTime = Time.time - startTime; 
        if (elapsedTime >= 30)
        {
            Destroy(gameObject);
        }
        else if (elapsedTime >= 2.1)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
        else if (elapsedTime >= 2)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(10, 10, 0), Quaternion.identity);
        }
        else if (elapsedTime >= 1.5)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(12, -20, 0), Quaternion.identity);
        }
        else if (elapsedTime >= 1)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(-21, 10, 0), Quaternion.identity);
        }
        else if (elapsedTime >= .5)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 30, 0), Quaternion.identity);
        }
    }
}
