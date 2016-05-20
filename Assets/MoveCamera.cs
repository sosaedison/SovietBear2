using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
	public Vector3 startPos;
	public Vector3 endPos;
	public float startTime = 0;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		startPos = this.transform.position;
		endPos = this.transform.position;
	}
	// Update is called once per frame
	void Update ()
	{
		if (this.transform.position != endPos) {
			Vector3 currentPos = this.transform.position;
			endPos.z = currentPos.z;
			float totalDistance = Vector3.Distance (startPos, endPos);
			float distanceTravelled = (Time.time - startTime) * speed;
			this.transform.position = Vector3.Lerp (currentPos, endPos, distanceTravelled / totalDistance);
		}

	
	}
}
