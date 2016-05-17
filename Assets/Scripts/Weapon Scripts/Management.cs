using UnityEngine;
using System.Collections;

public class Management : MonoBehaviour {
	public int WeaponSlot = 0;
	public GameObject[] weapons;
	//GameObject Pistol;
	//GameObject AssultRifle;
	//GameObject Shotgun;
	//GameObject Flamethrower;
	//private Flamethrower Flamethrowing;

	// Use this for initialization
	void Start () 
	{
		WeaponSlot = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
			weapons[0].GetComponent<Weapon>().equipped = true;
			WeaponSlot = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
			weapons[1].GetComponent<Weapon>().equipped = true;
			WeaponSlot = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
			weapons[2].GetComponent<Weapon>().equipped = true;
			WeaponSlot = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
			weapons[3].GetComponent<Weapon>().equipped = true;
			WeaponSlot = 3;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
			weapons[4].GetComponent<Weapon>().equipped = true;
			WeaponSlot = 4;
		}
	}
}