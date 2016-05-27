using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Management : MonoBehaviour {
	public int WeaponSlot = 0;
	public GameObject[] weapons;

	// Use this for initialization
	void Start () 
	{
		WeaponSlot = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (!LevelManager.isPaused())
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
                weapons[WeaponSlot].GetComponent<SpriteRenderer>().enabled = false;
                weapons[0].GetComponent<Weapon>().equipped = true;
                weapons[0].GetComponent<SpriteRenderer>().enabled = true;
                WeaponSlot = 0;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
                weapons[WeaponSlot].GetComponent<SpriteRenderer>().enabled = false;
                weapons[1].GetComponent<Weapon>().equipped = true;
                weapons[1].GetComponent<SpriteRenderer>().enabled = true;
                WeaponSlot = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
                weapons[WeaponSlot].GetComponent<SpriteRenderer>().enabled = false;
                weapons[2].GetComponent<Weapon>().equipped = true;
                weapons[2].GetComponent<SpriteRenderer>().enabled = true;
                WeaponSlot = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
                weapons[WeaponSlot].GetComponent<SpriteRenderer>().enabled = false;
                weapons[3].GetComponent<Weapon>().equipped = true;
                weapons[3].GetComponent<SpriteRenderer>().enabled = true;
                WeaponSlot = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
                weapons[WeaponSlot].GetComponent<SpriteRenderer>().enabled = false;
                weapons[4].GetComponent<Weapon>().equipped = true;
                weapons[4].GetComponent<SpriteRenderer>().enabled = true;
                WeaponSlot = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                weapons[WeaponSlot].GetComponent<Weapon>().equipped = false;
                weapons[WeaponSlot].GetComponent<SpriteRenderer>().enabled = false;
                weapons[5].GetComponent<Weapon>().equipped = true;
                weapons[5].GetComponent<SpriteRenderer>().enabled = true;
                WeaponSlot = 5;
            }
        } 
	}
}