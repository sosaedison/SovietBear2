using UnityEngine;
using System.Collections;

public class PlayerDetectionAI : MonoBehaviour {

    public GameObject playerInCone = null;
    public bool playerVisible = false;
    public GameObject noticedPlayer = null;
    public float lastSeenTime = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void FixedUpdate ()
    {
        if (playerInCone != null)
        {
            Vector2 playerPosition = playerInCone.transform.position;
            Vector2 enemyPosition = transform.position;
            Vector2 rayDirection = playerPosition - enemyPosition;
            RaycastHit2D hit = Physics2D.Raycast(enemyPosition, rayDirection);
            Debug.DrawRay(enemyPosition, rayDirection);
            if (hit.collider != null && hit.collider.gameObject == playerInCone)
            {
                playerVisible = true;
                noticedPlayer = playerInCone;
                //Debug.Log("Player Visible!");
            }
            else
            {
                playerVisible = false;
                lastSeenTime = Time.time;
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
            playerInCone = null;
            playerVisible = false;
            //Debug.Log("Left Cone!");
        }
    }
}
