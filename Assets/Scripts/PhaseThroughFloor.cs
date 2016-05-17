using UnityEngine;
using System.Collections;

public class PhaseThroughFloor : MonoBehaviour {
    private Collider2D floorCollider;
    public bool isOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (floorCollider != null)
        {
            if (Input.GetKey("s"))
            {
                floorCollider.enabled = false;
            }
            else
            {
                floorCollider.enabled = true;
            }
        }
        if (floorCollider.enabled == false)
        {
            Debug.Log("I'm Off");
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("PhaseGround"))
        {
            floorCollider = coll.gameObject.GetComponent<Collider2D>();
            isOn = true;
        }
        if (floorCollider.enabled == true)
        {
            Debug.Log("I'm so turned on!");
        }

    }
   
}
