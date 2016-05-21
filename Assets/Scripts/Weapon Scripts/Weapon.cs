using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public bool equipped = false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if (transform.root.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1") && equipped == true)
            {
                Invoke("Shoot", 0);
            }
            else if (Input.GetButton("Fire1") && equipped == true)
            {
                Invoke("AutoShoot", 0);
            }
        }
	}
	public void Shoot (Vector2 direction)
	{
		//override in subclasses
	}
	public void AutoShoot(Vector2 direction)
	{
        //override in subclasses
    }
}
