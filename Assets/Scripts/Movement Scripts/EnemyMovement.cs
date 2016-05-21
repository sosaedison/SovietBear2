using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    PlayerDetectionAI playerDetectionAI;
    Rigidbody2D rigbod;
    public float movementSpeed = 5.0f;
    public bool canJump = false;
    public float jumpPower = 100;

    // Use this for initialization
    void Start () {
        playerDetectionAI = GetComponent<PlayerDetectionAI>();
        rigbod = GetComponent<Rigidbody2D>();
    }

    void Walk(float speed)
    {
        
        rigbod.velocity = new Vector2(speed, rigbod.velocity.y);
        if (speed < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (speed > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Jump()
    {
        if (canJump == true)
        {
            rigbod.AddForce(new Vector2(0f, jumpPower));
        }
        
    }
    void DropDown()
    {
        GetComponent<PhaseThroughFloor>().DropDown();
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
                if (playerDetectionAI.noticedPlayer.transform.position.y > transform.position.y + 20)
                {
                    Jump();
                }
                else if (playerDetectionAI.noticedPlayer.transform.position.y < transform.position.y - 20)
                {
                    DropDown();
                }
            }
            if (playerDetectionAI.noticedPlayer.transform.position.x < transform.position.x - 3)
            {
                Walk(-movementSpeed);
            }
            else if (playerDetectionAI.noticedPlayer.transform.position.x > transform.position.x + 3)
            {
                Walk(movementSpeed);
            }
            
        }
        else
        {
            //normal patrol
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            canJump = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            canJump = false;
        }
    }
}
