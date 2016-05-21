﻿using UnityEngine;
using System.Collections;

public class PhaseThroughFloor : MonoBehaviour
{
    private Collider2D floorCollider;
    public Collider2D collider;
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
            Physics2D.IgnoreCollision(floorCollider, collider, true);
        }

    }

	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.gameObject.CompareTag("PhaseGround"))
        {
            Debug.Log("enter");
            floorCollider = other.gameObject.GetComponents<Collider2D>()[0];
            if (rigbod.velocity.y > 0)
            {
                Physics2D.IgnoreCollision(floorCollider, collider, true);

            }
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponents<Collider2D>()[0] == floorCollider)
        {
            Debug.Log("exit");
            Physics2D.IgnoreCollision(floorCollider, collider, false);
            floorCollider = null;
        }
    }
   
}