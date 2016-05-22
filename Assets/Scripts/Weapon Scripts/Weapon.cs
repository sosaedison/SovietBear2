using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public bool equipped = false;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	void FixedUpdate () 
	{
        if (transform.root.CompareTag("Player"))
        {
			if (Input.GetButtonDown("Fire1") && equipped == true && transform.root.transform.rotation.eulerAngles.y == 0)
            {
				this.Shoot(Vector2.right);
            }
			else if (Input.GetButtonDown("Fire1") && equipped == true && transform.root.transform.rotation.eulerAngles.y != 0)
			{
				this.Shoot(Vector2.left);
			}
			else if (Input.GetButton("Fire1") && equipped == true && transform.root.rotation.eulerAngles.y == 0)
            {
				this.AutoShoot(Vector2.right);
            }
			else if (Input.GetButton("Fire1") && equipped == true && transform.root.transform.rotation.eulerAngles.y != 0)
			{
				this.AutoShoot(Vector2.left);
			}
        }
	}
	virtual public void Shoot (Vector2 direction)
	{
		//override in subclasses
	}
	virtual public void AutoShoot (Vector2 direction)
	{
        //override in subclasses
    }
}
