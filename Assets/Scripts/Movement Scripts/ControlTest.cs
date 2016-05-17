using UnityEngine;
using System.Collections;

public class ControlTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetButtonDown("Jump"))
		{
			Debug.Log("jump");
		}
		else if(Input.GetButtonDown("Vertical"))
		{
			Debug.Log("Vertical");
		}
	}
}
