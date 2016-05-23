using UnityEngine;
using System.Collections;

public class Swording : Weapon {

	public GameObject sword;
	public bool CanSwing = true;
	Animation SwordSwing;
	// Use this for initialization
	void Start () 
	{
		SwordSwing = GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update () 
	{

	}

	override public void Shoot (Vector2 direction)
	{
		if (CanSwing == true)
		{
			CanSwing = false;
			SwordSwing.Play();
			Invoke("Reset",.6f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        Health health = other.gameObject.GetComponent<Health>();
		if (health != null && CanSwing == false)
		{
            health.current -= 12;
		}
	}

	void Reset ()
	{
		CanSwing = true;
	}
}