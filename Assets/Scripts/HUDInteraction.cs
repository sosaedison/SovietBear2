using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HUDInteraction : MonoBehaviour {
	
	Health playerHealth;
	public GameObject Player;
	public GameObject HealthUI;
	public Text HUDAmmo;
	public List<GameObject> HeartPieces;
	int LastHeartPlaced = 0;
	public GameObject[] Quarters = new GameObject[4];
	public GameObject PreviousQuarter;
	GameObject NewQuarter;
	Vector3[] DisplacementVectors = {new Vector3(0f,15f,0f), new Vector3(23f,0f,0f), new Vector3(0f,-15f,0f), new Vector3(15f,0f,0f)};
	// From TL counter clockwise

	// Use this for initialization
	void Start () 
	{
		playerHealth = Player.GetComponent<Health>();
		for(int i=0; i<playerHealth.max; i++)
		{
			int index = (LastHeartPlaced + 1) % 4;
			NewQuarter = (GameObject) Instantiate(Quarters[index], (new Vector3(PreviousQuarter.transform.position.x, PreviousQuarter.transform.position.y, 0f))+DisplacementVectors[index], Quaternion.identity);
			NewQuarter.transform.SetParent(HealthUI.transform, true);
			HeartPieces.Add(NewQuarter);
			PreviousQuarter = NewQuarter;
			LastHeartPlaced++;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (playerHealth.current > LastHeartPlaced)
		{
			for(int i=0; i<(playerHealth.current); i++)
			{
				int index = (LastHeartPlaced + 1) % 4;
				NewQuarter = (GameObject) Instantiate(Quarters[index], (new Vector3(PreviousQuarter.transform.position.x, PreviousQuarter.transform.position.y, 0f))+DisplacementVectors[index], Quaternion.identity);
				NewQuarter.transform.SetParent(HealthUI.transform, true);
				HeartPieces.Add(NewQuarter);
				PreviousQuarter = NewQuarter;
				LastHeartPlaced++;
			}
		}
		if (playerHealth.current < LastHeartPlaced)
		{
			Destroy(PreviousQuarter);
			HeartPieces.Remove(HeartPieces.Last());
			LastHeartPlaced--;
			PreviousQuarter = HeartPieces.Last();
		}
		Weapon currentWeapon = Player.GetComponent<Management>().weapons[Player.GetComponent<Management>().WeaponSlot].GetComponent<Weapon>();
		HUDAmmo.text = currentWeapon.ammo.ToString()+"/"+currentWeapon.maxAmmo.ToString();
	}
	// TL to BL is x,y-15. BL to BR is (x+15,y). BR to TR (is x,y+15). TR to TL is (x+23,y)
}
