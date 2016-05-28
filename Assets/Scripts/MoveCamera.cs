using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
	public Vector3 startPos;
	public Vector3 endPos;
	public float startTime = 0;
	public float speed;
    LevelManager levelManager;
    bool moving;
    float totalDistance;
    float lerpTime;

	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;
		endPos = transform.position;
        
	}
	// Update is called once per frame
	void Update ()
	{
        if (!levelManager)
            levelManager = FindObjectOfType<LevelManager>();
        endPos.z = startPos.z;
        if (!moving && Vector3.Distance(transform.position, endPos) > .1)
        {
            moving = true;
            levelManager.Pause();
            startPos = transform.position;
            totalDistance = Vector3.Distance(startPos, endPos);
            lerpTime = totalDistance / speed;
            startTime = Time.time;
        }

		float currentTime = Time.time - startTime;
        if (currentTime > lerpTime && moving)
        {
            moving = false;
            levelManager.Unpause();
            transform.position = endPos;
        }
        if (moving)
        {
            transform.position = Vector3.Lerp(startPos, endPos, currentTime / lerpTime);
        }
	
	}
}
