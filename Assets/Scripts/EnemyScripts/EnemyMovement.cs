using UnityEngine;
using System.Collections;


public class EnemyMovement : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public bool canJump = false;
    public float jumpPower = 100;
    public int startingDirection;
    public float distanceToStop = 10f;
    public bool useMovementAI = true;
    public GameObject handAnchor;

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

    public void Walk(float speed, bool strafing)
    {
        if (speed < 0)
        {
            if (!strafing) transform.rotation = Quaternion.Euler(0, 180, 0);
            GetComponent<AnimateSprite>().animating = true;
        }
        else if (speed > 0)
        {
            if (!strafing) transform.rotation = Quaternion.Euler(0, 0, 0);
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

    public void Jump()
    {
        if (canJump == true)
        {
            rigbod.AddForce(new Vector2(0f, jumpPower));

        }
        
    }

    public void DropDown()
    {
        GetComponent<PhaseThroughFloor>().DropDown();
    }

    public void Patrol()
    {
        Walk(movementSpeed * currentDirection, false);
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
        if (useMovementAI)
        {
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
                        searchingForJump = false;
                    }
                    else
                    {
                        Patrol();
                        if (turns >= 2)
                        {
                            DropDown();
                            searchingForJump = false;
                        }
                    }
                }
                else if (playerDetectionAI.currentTarget.y < transform.position.y - 1)
                {
                    Patrol();
                    DropDown();
                }
                else if (playerDetectionAI.currentTarget.x < transform.position.x - distanceToStop)
                {
                    currentDirection = -1;
                    Walk(-movementSpeed, false);
                }
                else if (playerDetectionAI.currentTarget.x > transform.position.x + distanceToStop)
                {
                    currentDirection = 1;
                    Walk(movementSpeed, false);
                }
                else
                {
                    Walk(0.0f, false);
                }


            }
            else
            {
                NormalMotion();
            }
        }    
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            canJump = true;
            GetComponent<AnimateSprite>().staticIndex = 0;
            if (handAnchor)
            {
                Vector3 newPos = handAnchor.transform.localPosition;
                newPos.y = -0.264f;
                handAnchor.transform.localPosition = newPos;
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            canJump = false;
            GetComponent<AnimateSprite>().animating = false;
            GetComponent<AnimateSprite>().staticIndex = 1;
            if (handAnchor)
            {
                Vector3 newPos = handAnchor.transform.localPosition;
                newPos.y = 0f;
                handAnchor.transform.localPosition = newPos;
            }
        }
    } 
}
