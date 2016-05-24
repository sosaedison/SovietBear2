using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HUDInteraction : MonoBehaviour {

	Health playerHealth;
	public GameObject Player;
	List<GameObject> HeartPieces;
	int LastHeartPlaced = 3;
	public GameObject TLQuarter;
	public GameObject BLQuarter;
	public GameObject BRQuarter;
	public GameObject TRQuarter;
	// From TL counter clockwise

	// Use this for initialization
	void Start () 
	{
		playerHealth = Player.GetComponent<Health>();
		for(int i=0; i < playerHealth.max; i++)
		{
           
		}
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
	// TL to BL is x,y-15. BL to BR is (x+15,y). BR to TR (is x,y+15). TR to TL is (x+23,y)
	void AddHealth ()
	{
		
	}
}
