using UnityEngine;
using System.Collections;

public class PhaseThroughFloor : MonoBehaviour
{
    private Collider2D floorCollider;
    public Collider2D activeCollider;
    public Collider2D[] ignoredColliders;
    private Rigidbody2D rigbod;

    // Use this for initialization
    void Start()
    {
        rigbod = GetComponent<Rigidbody2D>();
        
    }

    public void DropDown()
    {
        if (floorCollider != null)
        {
            Physics2D.IgnoreCollision(floorCollider, activeCollider, true);

        }

    }

	void OnTriggerStay2D (Collider2D other)
	{
        if (other.gameObject.CompareTag("PhaseGround"))
        {
            floorCollider = other.gameObject.GetComponents<Collider2D>()[0];
            if (rigbod.velocity.y > 0)
            {
                Physics2D.IgnoreCollision(floorCollider, activeCollider, true);
                foreach (Collider2D collider in ignoredColliders)
                {
                    Physics2D.IgnoreCollision(other, collider, true);
                }
            }
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponents<Collider2D>()[0] == floorCollider && !activeCollider.IsTouching(other))
        {
            Physics2D.IgnoreCollision(floorCollider, activeCollider, false);
            floorCollider = null;
        }
    }
   
}
