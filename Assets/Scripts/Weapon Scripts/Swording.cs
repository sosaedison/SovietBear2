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
	void Shoot ()
	{
		if (CanSwing == true)
		{
			CanSwing = false;
			SwordSwing.Play();
			Invoke("Reset",.6f);
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Nazi" && CanSwing == false)
		{
			Destroy(other.gameObject);
		}
	}
	void Reset ()
	{
		CanSwing = true;
	}
}