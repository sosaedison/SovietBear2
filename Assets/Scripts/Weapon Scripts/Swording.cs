using UnityEngine;
using System.Collections;

public class Swording : Weapon {

	public GameObject sword;
	public bool CanSwing = true;
	public float swingCooldown = .6f;
	HingeJoint2D hinge;
	JointMotor2D motor;
	float MSpeed = 180f;
	bool Swinging = false;
	// Use this for initialization
	void Start () 
	{
		motor.motorSpeed = 0;
		hinge = GetComponent<HingeJoint2D>();
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
	void Shoot (Vector2 direction)
	{
		if (CanSwing == true)
		{
			motor.motorSpeed = MSpeed;
			Invoke("Backswing",.5f);
		}
	}
	void Reset()
	{
		motor.motorSpeed = 0;
		CanSwing = true;
	}
	void Backswing ()
	{
		motor.motorSpeed = -2*MSpeed;
		Invoke("Reset",.25f);
	}
}
