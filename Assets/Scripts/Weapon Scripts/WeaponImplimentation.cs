using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {
	int WeaponSlot = 0;
	// Use this for initialization
	void Start () 
	{
		WeaponSlot = 0;
	}
	

	void FixedUpdate () 
	{
		//This will be meelee, apply appropriate cooldown, no ammo
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			//Change player model
			WeaponSlot = 0;
		}
		//Basic shooty Mcgun gun
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			//Change player model
			WeaponSlot = 1;
		}
		//Burst gun
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			//Change player model
			WeaponSlot = 2;
		}
		//Shotty
		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			//Change player model
			WeaponSlot = 3;

		}
		//Flames of war
		else if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			//Change player model
			WeaponSlot = 4;

		}

	}

}
