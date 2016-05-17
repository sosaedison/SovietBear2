using UnityEngine;
using System.Collections;

public class Management : MonoBehaviour {
	public int WeaponSlot = 0;
	public GameObject Meelee;
	private Sword Swording;
	GameObject Pistol;
	GameObject AssultRifle;
	GameObject Shotgun;
	//GameObject Flamethrower;
	//private Flamethrower Flamethrowing;

	// Use this for initialization
	void Start () 
	{
		WeaponSlot = 0;
		//Swording = Sword.Swording;

		/*
		Pistol = GameObject.Find("Pistol");
		PScript = Pistol.GetComponent<Pistoling>();
			
		Rifle = GameObject.Find("Assult Rifle");
		RScript = Rifle.GetComponent<Rifleing>();
			
		Shotty = GameObject.Find("Shotgun");
		SScript = Shotty.GetComponent<Shotgunning>();
			
		Flames = GameObject.Find("Flamethrower");
		FScript = Flames.GetComponenet<Flamethrowing>();
		*/
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//This will be meelee, apply appropriate cooldown, no ammo
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			/*
			//Change player model
			if (WeaponSlot == 1)
			{
				PScript.active = false;
			}

			else if (WeaponSlot == 2)
			{
				RScript.active = false;
			}
			else if (WeaponSlot == 3)
			{
				SScript.active = false;
			}
			else if (WeaponSlot == 4)
			{
				//FScript.active = false;
			}
			*/
			Swording.active = true;
			WeaponSlot = 0;
		}
		/*
		//Basic shooty Mcgun gun
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			//Change player model
			if (WeaponSlot == 0)
			{
				MScript.active = false;
			}
			else if (WeaponSlot == 2)
			{
				RScript.active = false;
			}
			else if (WeaponSlot == 3)
			{
				SScript.active = false;
			}
			else if (WeaponSlot == 4)
			{
				//FScript.active = false;
			}
			PScript.active = true;
			WeaponSlot = 1;
		}
		//Burst gun
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			//Change player model
			if (WeaponSlot == 0)
			{
				MScript.active = false;
			}
			else if (WeaponSlot == 1)
			{
				PScript.active = false;
			}
			else if (WeaponSlot == 3)
			{
				SScript.active = false;
			}
			else if (WeaponSlot == 4)
			{
				//FScript.active = false;
			}
			RScript.active = true;
			WeaponSlot = 2;
		}
		//Shotty
		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			//Change player model
			if (WeaponSlot == 0)
			{
				MScript.active = false;
			}
			else if (WeaponSlot == 1)
			{
				PScript.active = false;
			}
			else if (WeaponSlot == 2)
			{
				RScript.active = false;
			}
			else if (WeaponSlot == 4)
			{
				//FScript.active = false;
			}
			SScript.active = true;
			WeaponSlot = 3;

		}
		//Flames of war

		else if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			//Change player model
			if (WeaponSlot == 0)
			{
				MScript.active = false;
			}
			else if (WeaponSlot == 1)
			{
				PScript.active = false;
			}
			else if (WeaponSlot == 2)
			{
				RScript.active = false;
			}
			else if (WeaponSlot == 3)
			{
				SScript.active = false;
			}
			FScript.active = true;
			WeaponSlot = 4;
		}
		*/
	}
}