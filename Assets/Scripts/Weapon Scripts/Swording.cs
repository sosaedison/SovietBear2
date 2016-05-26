using UnityEngine;
using System.Collections;

public class Swording : Weapon {

	public bool CanSwing = true;
	Animation SwordSwing;
	// Use this for initialization
	void Start () 
	{
		SwordSwing = GetComponent<Animation>();
	}

	override public void Shoot (Vector2 direction)
	{
		if (CanSwing == true)
		{
			CanSwing = false;
			SwordSwing.Play();
			Invoke("Reset", coolDown);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (!other.isTrigger)
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null && CanSwing == false)
            {
                health.current -= damage;
            }
        }
        
	}

	void Reset ()
	{
		CanSwing = true;
	}
}