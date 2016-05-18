using UnityEngine;
using System.Collections;

public class GenerationTesting : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		int RoomExits = Random.Range(1,11);
		int ExitPlacement = Random.Range(1,5);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log(""+RoomExits.ToString()+","+ExitPlacement.ToString());
		}
	}
}
