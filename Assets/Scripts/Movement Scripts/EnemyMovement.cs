using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    PlayerDetectionAI playerDetectionAI;

	// Use this for initialization
	void Start () {
        playerDetectionAI = GetComponent<PlayerDetectionAI>();
	
	}

    void Walk()
    {

    }

    void Jump()
    {

    }
    void DropDown()
    {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (playerDetectionAI.noticedPlayer != null)
        {
            //chase player
            if (playerDetectionAI.playerVisible)
            {
                Vector2 direction = transform.position - playerDetectionAI.noticedPlayer.transform.position;
                GetComponentInChildren<Weapon>().Shoot(direction);
                GetComponentInChildren<Weapon>().AutoShoot(direction);
                if (playerDetectionAI.noticedPlayer.transform.position.y > transform.position.y + 3)
                {
                    Jump();
                }
                else if (playerDetectionAI.noticedPlayer.transform.position.y < transform.position.y - 3)
                {
                    DropDown();
                }
            }
            Walk();
        }
        else
        {
            //normal patrol
        }
	}
}
