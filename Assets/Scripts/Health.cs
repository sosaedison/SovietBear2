using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int current = 0;
    public int max = 0;

	// Use this for initialization
	void Start () {
        current = max;
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (current <= 0)
        {
            if (CompareTag("Player"))
            {
                //gameover
            }
            Destroy(gameObject);
        }
        if (current > max) current = max;
	}
}
