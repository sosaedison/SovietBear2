using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	public bool active = false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(active == true)
		{
			Debug.Log("Switched to sword");
		}
	}
}
