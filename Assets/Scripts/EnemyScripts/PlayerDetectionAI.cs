using UnityEngine;
using System.Collections;

public class PlayerDetectionAI : MonoBehaviour {

    public bool playerVisible = false;
    public Vector3 currentTarget;
    public GameObject playerInCone = null;

    LevelManager levelManager;
    int sightingIndex = 0;
    



    // Use this for initialization
    void Start () {
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void FixedUpdate ()
    {
        if (playerVisible == false)
        {
            if (currentTarget != Vector3.zero)
            {
                Vector3 distance = transform.position - currentTarget;
                if (Mathf.Abs(distance.magnitude) < 5)
                {
                    sightingIndex++;
                    if (sightingIndex >= levelManager.bearSightings.Count)
                    {
                        currentTarget = Vector3.zero;
                        sightingIndex--;
                    }
                    else
                    {
                        currentTarget = levelManager.bearSightings[sightingIndex];
                    }

                }
            }
            else if (sightingIndex < levelManager.bearSightings.Count)
            {
                currentTarget = levelManager.bearSightings[sightingIndex];
            }

        }

        if (playerInCone != null)
        {
            Vector2 playerPosition = playerInCone.transform.position;
            Vector2 enemyPosition = transform.position + Vector3.up * GetComponent<BoxCollider2D>().bounds.extents.y / 2;
            Vector2 rayDirection = playerPosition - enemyPosition;
            RaycastHit2D hit = Physics2D.Raycast(enemyPosition, rayDirection);
            Debug.DrawRay(enemyPosition, rayDirection);
            if (hit.collider != null && hit.collider.gameObject == playerInCone)
            {
                if (playerVisible == false)
                {
                    playerVisible = true;
                    sightingIndex = levelManager.bearSightings.Count;
                    levelManager.bearSightings.Add(playerInCone.transform.position);
                    currentTarget = playerInCone.transform.position;
                }
                
            }
            else
            {
                if (playerVisible == true)
                {
                    playerVisible = false;
                    sightingIndex = levelManager.bearSightings.Count;
                    levelManager.bearSightings.Add(playerInCone.transform.position);
                    currentTarget = playerInCone.transform.position;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInCone = other.gameObject;
            //Debug.Log("In Cone!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerVisible = false;
            sightingIndex = levelManager.bearSightings.Count;
            levelManager.bearSightings.Add(playerInCone.transform.position);
            currentTarget = playerInCone.transform.position;
            playerInCone = null;
            //Debug.Log("Left Cone!");
        }
    }
}
