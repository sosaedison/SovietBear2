﻿using UnityEngine;
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
		if(Input.GetButtonDown("Fire1") && equipped == true)
		{
			Invoke("Shoot", 0);
		}
	}
	void Shoot ()
	{
		
	}
}