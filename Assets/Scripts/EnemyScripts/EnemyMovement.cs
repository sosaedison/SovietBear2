using UnityEngine;
using System.Collections;


public class EnemyMovement : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public bool canJump = false;
    public float jumpPower = 100;
    public int startingDirection;
    public float distanceToStop = 10f;

    PlayerDetectionAI playerDetectionAI;
    Rigidbody2D rigbod;

    int turns = 0;
    int currentDirection = 1;
    bool searchingForJump = false;
    

    // Use this for initialization
    void Start () {
        playerDetectionAI = GetComponent<PlayerDetectionAI>();
        rigbod = GetComponent<Rigidbody2D>();
        currentDirection = startingDirection / Mathf.Abs(startingDirection); //just to be safe
    }

    bool FindEdge()
    {
        Vector2 lineCastPos = transform.position + transform.right * GetComponent<BoxCollider2D>().bounds.extents.x + Vector3.down * GetComponent<BoxCollider2D>().bounds.extents.y;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        return !Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down);
        
    }

    bool FindJumpablePlatform()
    {
        Vector2 lineCastPos = transform.position + transform.right * GetComponent<BoxCollider2D>().bounds.extents.x - Vector3.down * GetComponent<BoxCollider2D>().bounds.extents.y;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.up * 5);
        RaycastHit2D hit = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.up * 5);
        if (hit)
        {
            return hit.collider.gameObject.CompareTag("PhaseGround");
        }
        else
        {
            return false;
        }
    }

    bool FindWall()
    {
        Vector2 lineCastPos = transform.position + transform.right * GetComponent<BoxCollider2D>().bounds.extents.x;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.right * currentDirection);
        return Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.right * currentDirection);
    }

    void Walk(float speed)
    {
        if (speed < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            GetComponent<AnimateSprite>().animating = true;
        }
        else if (speed > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<AnimateSprite>().animating = true;
        }
        else
        {
            GetComponent<AnimateSprite>().animating = false;
        }
        if (FindEdge())
        {
            speed = 0;
            GetComponent<AnimateSprite>().animating = false;
        }
        rigbod.velocity = new Vector2(speed, rigbod.velocity.y);
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

    void Patrol()
    {
        Walk(movementSpeed * currentDirection);
        if (FindEdge() && canJump || FindWall())
        {
            currentDirection *= -1;
            turns++;
        }
    }

    void NormalMotion()
    {
        Patrol(); // override this in subclasses
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (playerDetectionAI.currentTarget != Vector3.zero)
        {
            //chase player
            if (playerDetectionAI.currentTarget.y > transform.position.y + 1)
            {
                if (!searchingForJump)
                {
                    searchingForJump = true;
                    turns = 0;
                }
                
                if (FindJumpablePlatform())
                {
                    Jump();
                }
                else
                {
                    Patrol();
                    if (turns >= 2)
                    {
                        DropDown();
                    }
                }
            }
            else if (playerDetectionAI.currentTarget.y < transform.position.y - 1)
            {
                Patrol();
                DropDown();
            }
            else if(playerDetectionAI.currentTarget.x < transform.position.x - distanceToStop)
            {
                currentDirection = -1;
                Walk(-movementSpeed);
            }
            else if (playerDetectionAI.currentTarget.x > transform.position.x + distanceToStop)
            {
                currentDirection = 1;
                Walk(movementSpeed);
            }
            else
            {
                Walk(0.0f);
            }


        }
        else
        {
            NormalMotion();
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
            GetComponent<AnimateSprite>().animating = false;
        }
    } 
}
