using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {

    public float swordSpeed = 8f;
    public int swordLife = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ++swordLife;
        transform.Translate(Vector3.right * swordSpeed * Time.deltaTime);
        if (swordLife == 10)
        {
            Destroy(gameObject);
        }
    }
}
