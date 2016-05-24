using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HUDInteraction : MonoBehaviour {
	
	Health playerHealth;
	public GameObject Player;
	public GameObject HealthUI;
	List<GameObject> HeartPieces;
	int LastHeartPlaced = 0;
	public GameObject[] Quarters = new GameObject[4];
	public GameObject PreviousQuarter;
	GameObject NewQuarter;
	int xDisplacement = 0;
	int yDistplacement = 15;
	// From TL counter clockwise

	// Use this for initialization
	void Start () 
	{
		playerHealth = Player.GetComponent<Health>();
		for(int i=0; i<(playerHealth.max)/4; i++)
		{
			int index = (LastHeartPlaced + 1) % 4;
			xDisplacement = 0;
			yDistplacement = -15;
			NewQuarter = (GameObject) Instantiate(Quarters[index], new Vector3(PreviousQuarter.transform.position.x + xDisplacement, PreviousQuarter.transform.position.y+ yDistplacement, PreviousQuarter.transform.position.z),Quaternion.identity);
			NewQuarter.transform.SetParent(HealthUI.transform, false);
			PreviousQuarter = NewQuarter;
			LastHeartPlaced++;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (playerHealth.current > LastHeartPlaced)
		{
			//Spawn next piece
		}
	}
	// TL to BL is x,y-15. BL to BR is (x+15,y). BR to TR (is x,y+15). TR to TL is (x+23,y)
}
