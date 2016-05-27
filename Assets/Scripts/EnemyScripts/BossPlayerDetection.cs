using UnityEngine;
using System.Collections;

public class BossPlayerDetection : PlayerDetectionAI {

	// Use this for initialization
	void Start () {
        playerVisible = true;
        playerInCone = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        currentTarget = playerInCone.transform.position;
	}
}
